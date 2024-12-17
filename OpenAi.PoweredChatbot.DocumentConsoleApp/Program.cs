using System.ClientModel;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using OpenAI.Assistants;
using OpenAI.Files;

IConfiguration configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string? endpoint = configuration["AZURE_OPENAI_ENDPOINT"]
    ?? throw new InvalidOperationException(Environment.NewLine + "Please set the environment variable AZURE_OPENAI_ENDPOINT");
string? key = configuration["AZURE_OPENAI_API_KEY"]
    ?? throw new InvalidOperationException(Environment.NewLine + "Please set the environment variable AZURE_OPENAI_API_KEY");

AzureOpenAIClient openAiClient = new(new Uri(endpoint), new ApiKeyCredential(key));
#pragma warning disable OPENAI001
AssistantClient assistantClient = openAiClient.GetAssistantClient();


//// Résoudre des problèmes mathématiques
//ClientResult<Assistant> clientResult = await assistantClient.CreateAssistantAsync("gpt-4", new AssistantCreationOptions
//{
//    Name = "Math Tutor",
//    Instructions = "You are a personal math tutor. Write and run code to answer math questions.",
//    Tools = { new CodeInterpreterToolDefinition() }
//});
//Assistant assistant = clientResult.Value;

//ThreadInitializationMessage initialMessage = new(
//    MessageRole.User,
//    [
//        "I need to solve the equation `6x + 11 = 17`. Can you help me?"
//    ]);


// Répondre en utilisant des documents
using Stream document = BinaryData.FromString("""
    {
        "description": "This document contains the sale history data for Contoso products.",
        "sales": [
            {
                "month": "January",
                "by_product": {
                    "113043": 15,
                    "113045": 12,
                    "113049": 2
                }
            },
            {
                "month": "February",
                "by_product": {
                    "113045": 22
                }
            },
            {
                "month": "March",
                "by_product": {
                    "113045": 16,
                    "113055": 5
                }
            }
        ]
    }
    """).ToStream();
OpenAIFileClient fileClient = openAiClient.GetOpenAIFileClient();
ClientResult<OpenAIFile> uploadedFileResult = await fileClient.UploadFileAsync(document, "monthly_sales.json", FileUploadPurpose.Assistants);
OpenAIFile uploadedFile = uploadedFileResult.Value;

ClientResult<Assistant> clientResult = await assistantClient.CreateAssistantAsync("gpt-4", new AssistantCreationOptions
{
    Name = "Sales Assistant",
    Instructions = "You are an assistant that looks up sales data and helps visualize the information based"
        + " on user queries. When asked to generate a graph, chart, or other visualization, use"
        + " the code interpreter tool to do so.",
    Tools = { new CodeInterpreterToolDefinition(), new FileSearchToolDefinition() },
    ToolResources = new ToolResources()
    {
        FileSearch = new FileSearchToolResources
        {
            NewVectorStores =
            {
                new VectorStoreCreationHelper([uploadedFile.Id]),
            }
        }
    }
});
Assistant assistant = clientResult.Value;

ThreadInitializationMessage initialMessage = new(
    MessageRole.User,
    [
        "How well did product 113045 sell in February? Graph its trend over time."
    ]);


ClientResult<AssistantThread> threadResult = await assistantClient.CreateThreadAsync(new ThreadCreationOptions
{
    InitialMessages = { initialMessage }
});
AssistantThread thread = threadResult.Value;

ClientResult<ThreadRun> runResult = await assistantClient.CreateRunAsync(thread.Id, assistant.Id);
ThreadRun run = runResult.Value;

do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    runResult = await assistantClient.GetRunAsync(thread.Id, run.Id);
}
while (runResult.Value.Status == RunStatus.Queued || runResult.Value.Status == RunStatus.InProgress);

await foreach (ThreadMessage? threadMessage in assistantClient.GetMessagesAsync(thread.Id, new MessageCollectionOptions { Order = MessageCollectionOrder.Ascending }))
{
    Console.Write($"[{threadMessage.Role.ToString().ToUpper()}]: ");
    foreach (MessageContent contentItem in threadMessage.Content)
    {
        if (contentItem is MessageContent messageContent)
        {
            Console.WriteLine(messageContent.Text);
            messageContent.TextAnnotations
                .Where(annotation => !string.IsNullOrEmpty(annotation.InputFileId))
                .ToList()
                .ForEach(annotation => Console.WriteLine($"* Annotation file: {annotation.InputFileId}"));
        }
        Console.WriteLine();
    }
}

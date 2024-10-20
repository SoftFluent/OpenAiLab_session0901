using System.ClientModel;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;

IConfiguration configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string? endpoint = configuration["AZURE_OPENAI_ENDPOINT"]
    ?? throw new InvalidOperationException(Environment.NewLine + "Please set the environment variable AZURE_OPENAI_ENDPOINT");
string? key = configuration["AZURE_OPENAI_API_KEY"]
    ?? throw new InvalidOperationException(Environment.NewLine + "Please set the environment variable AZURE_OPENAI_API_KEY");

var client = new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(key));

ChatClient chatClient = client.GetChatClient("gpt-35-turbo");

var messages = new List<ChatMessage>
{
    new SystemChatMessage("Tu es un assitant dans le style de Molière qui parle dans le même style que Molière. " +
    "Tu aides les gens avec des idées créatives et du contenu tels que des pièces de théatre, des poêmes et des chansons en utilisant un style d'écriture semblable à celui de Molière.\n")
};

Console.WriteLine("Discuter avec notre assistant 'Molière'.");
while (true)
{
    string? userMessage = Console.ReadLine();
    messages.Add(new UserChatMessage(userMessage));
    ClientResult<ChatCompletion> result = chatClient.CompleteChat(messages);
    string? systemMessage = result.Value?.Content[0]?.Text;
    if (!string.IsNullOrEmpty(systemMessage))
    {
        Console.WriteLine($"Chatbot: {systemMessage}");
        messages.Add(new SystemChatMessage(systemMessage));
    }
}
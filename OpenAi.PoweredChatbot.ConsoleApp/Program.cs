using System.ClientModel;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using OpenAi.PoweredChatbot.ConsoleApp;
using OpenAi.PoweredChatbot.ConsoleApp.Bots;
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

int index = 0;
Dictionary<int, Type> botsDictionary = typeof(Program).Assembly.GetTypes()
    .Where(t => t.GetInterfaces().Contains(typeof(IBot)))
    .ToList()
    .ToDictionary(b => ++index);

ConsoleHelper.WriteAsIntro("Bienvenue dans notre salon de bots boostés à l'intelligence artificielle !");
while (true)
{
    ConsoleHelper.WriteAsIntro("Veuillez choisir votre bot:");
    foreach (var kvp in botsDictionary)
    {
        ConsoleHelper.WriteAsIntro($"{kvp.Key}. {kvp.Value.Name}");
    }

    if (!int.TryParse(Console.ReadLine(), out int botIndex) || !botsDictionary.TryGetValue(botIndex, out Type? botType))
    {
        ConsoleHelper.WriteAsError("Choix de bot invalide.");
        continue;
    }

    IBot mybot = (IBot?)Activator.CreateInstance(botType, chatClient)
        ?? throw new InvalidOperationException($"{botIndex} does not exist.");

    StartBot(mybot);
}

static void StartBot(IBot bot)
{
    bot.InitBot();
    ConsoleHelper.WriteAsChatbot($"Discuter avec l'assistant '{bot.Name}'." + Environment.NewLine +
    $"  Taper 'Quit' pour changer de bot." + Environment.NewLine + 
    $"  Taper 'Ctrl + C' pour quitter le programme.");

    while (true)
    {
        string? userMessage = Console.ReadLine();
        if(string.Equals(userMessage, "Quit", StringComparison.OrdinalIgnoreCase))
        {
            break;
        }

        string? systemMessage = bot.CompleteChat(userMessage);
        if (!string.IsNullOrEmpty(systemMessage))
        {
            ConsoleHelper.WriteAsChatbot(systemMessage);
        }
    }
}

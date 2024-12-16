using System.ClientModel;
using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;
internal class Molbot(ChatClient client) : IBot
{
    public List<ChatMessage> Messages { get; } = [];

    public ChatClient Client { get; } = client;

    public ChatCompletionOptions Options { get; } = new ChatCompletionOptions { Temperature = 0.7f };

    public string Name => nameof(Molbot);

    public void InitBot()
    {
        // Ajouter les instructions pour que votre bot puisse aider les apprentis écrivain
        // a écrire une pièce dans le style de Molière
        // Personnages, intrigue, créatures (ou pas ?), lieux, etc.
        Messages.Add(new SystemChatMessage(""));
    }

    public string? CompleteChat(string? userMessage)
    {
        Messages.Add(new UserChatMessage(userMessage));
        ClientResult<ChatCompletion> result = Client.CompleteChat(Messages, Options);
        return result.Value?.Content[0]?.Text;
    }
}

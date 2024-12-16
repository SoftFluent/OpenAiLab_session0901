using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;
internal class Kingbot(ChatClient client) : BotBase(client), IBot
{
    public override ChatCompletionOptions Options { get; } = new ChatCompletionOptions { Temperature = 0.3f };

    public override string Name => nameof(Kingbot);

    public override void InitBot()
    {
        // Ajouter les instructions pour que votre bot puisse aider les apprentis écrivain
        // a écrire une nouvelle fantastique / horreur comme Stephen King
        // Personnages, intrigue, créatures (ou pas ?), lieux, etc.
        Messages.Add(new SystemChatMessage(""));
    }
}

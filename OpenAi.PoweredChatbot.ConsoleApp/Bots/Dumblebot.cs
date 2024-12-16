using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;
internal class Dumblebot(ChatClient client) : BotBase(client), IBot
{
    public override ChatCompletionOptions Options { get; } = new ChatCompletionOptions { Temperature = 0.2f };

    public override string Name => nameof(Dumblebot);

    public override void InitBot()
    {
        // Ajouter les instructions pour que votre bot puisse proposer
        // de nouveaux sorts magiques de l'univers Harry Potter.
        // Nom du sort, mouvement à faire avec la baguette, effet du sort, etc.
        Messages.Add(new SystemChatMessage(""));
    }
}

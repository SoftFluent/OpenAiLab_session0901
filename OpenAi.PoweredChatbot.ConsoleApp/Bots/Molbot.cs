using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;
internal class Molbot(ChatClient client) : BotBase(client), IBot
{
    public override ChatCompletionOptions Options { get; } = new ChatCompletionOptions { Temperature = 0.7f };

    public override string Name => nameof(Molbot);

    public override void InitBot()
    {
        // Ajouter les instructions pour que votre bot puisse aider les apprentis écrivain
        // a écrire une pièce dans le style de Molière
        // Personnages, intrigue, créatures (ou pas ?), lieux, etc.
        Messages.Add(new SystemChatMessage(""));
    }
}

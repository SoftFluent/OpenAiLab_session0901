using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;
internal class Stanleybot(ChatClient client) : BotBase(client), IBot
{
    public override ChatCompletionOptions Options { get; } = new ChatCompletionOptions { Temperature = 0.7f };

    public override string Name => nameof(Stanleybot);

    public override void InitBot()
    {
        // Ajouter les instructions pour que votre bot puisse proposer
        // de nouveaux superhéros et supervilains dans l'univers Marvel :
        // Nom de superhéros / supervilain, nom véritable, pouvoirs, faiblesses, costumes, etc.
        Messages.Add(new SystemChatMessage(""));
    }
}

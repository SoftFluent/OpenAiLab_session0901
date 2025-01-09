using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;

internal class SummerCampBot(ChatClient client) : BotBase(client), IBot
{
    public override ChatCompletionOptions Options { get; } = new ChatCompletionOptions { Temperature = 0.3f };
    public override string Name => nameof(SummerCampBot);
    public override void InitBot()
    {
        // Ajouter les instructions pour que votre bot puisse aider les apprentis animateurs
        // a organiser une journée voire une semaine d'activités
        // Il faudra prévoir des activités diversifiées (grands jeux, moments clames, activités créatives, etc.)
        // et adaptés à l'âge des enfants encadrés
        // On peut aussi ajouter quelques contraintes en fonction des phobies de certains enfants :
        // Si on a des enfants qui souffrent de vertiges, on évitera les activités type accrobranche, via ferrata, etc.
        Messages.Add(new SystemChatMessage(""));
    }
}
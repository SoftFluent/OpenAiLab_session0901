using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;

internal class SummerCampBot(ChatClient client) : BotBase(client), IBot
{
    public override ChatCompletionOptions Options { get; } = new ChatCompletionOptions { Temperature = 0.3f };
    public override string Name => nameof(SummerCampBot);
    public override void InitBot()
    {
        Options.StopSequences.Add("Merci");
        Options.StopSequences.Add("Au revoir");
        Options.StopSequences.Add("Bon soirée");
        // Ajouter les instructions pour que votre bot puisse aider les apprentis animateurs
        // a organiser une journée voire une semaine d'activités
        // Il faudra prévoir des activités diversifiées (grands jeux, moments clames, activités créatives, etc.)
        // et adaptés à l'âge des enfants encadrés
        // On peut aussi ajouter quelques contraintes en fonction des phobies de certains enfants :
        // Si on a des enfants qui souffrent de vertiges, on évitera les activités type accrobranche, via ferrata, etc.
        Messages.Add(new SystemChatMessage("tu es un bot qui aide les apprentis animateurs à faire des activités" +
            "pour les enfants d'un camping d'été. Tes activités doivent être assez variées." +
            "Il y doit avoir des jeux en équipe, des activités individuels, des activités intellectueles, " +
            "des jeux pour penser." +
            "tu dois tenir en compte qu'il y aura des contraintes à tenir en compte. par exemple il y a des enfants" +
            "qui souffrent de vertiges. il y a des autres qui sont handicapés. il y a quelques uns qui ne savent pas nager."));

        Messages.Add(new SystemChatMessage("quelques idées d'activités: babyfoot, cecifoot, natation, saut à la corde"));

        Messages.Add(new SystemChatMessage("Tu dois demander à ton interlocuteur l'age des enfants." +
            "tu dois aussi demander si ces enfants ont des contraintes." +
            "demande aussi l'endroit où se déroule le camping d'été."));


    }
}
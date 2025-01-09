using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;

internal class SchoolCateringBot(ChatClient client) : BotBase(client), IBot
{
    public override ChatCompletionOptions Options { get; } = new ChatCompletionOptions { Temperature = 0.3f };
    public override string Name => nameof(SchoolCateringBot);
    public override void InitBot()
    {
        // Ajouter les instructions pour que votre bot puisse aider les apprentis cuisiniers de la restauration scolaire
        // a planifier les menus de la semaine pour une école
        // Il faut en particulier envisager les interdits (végétariens, pas de porcs, etc.)
        // et les allergies (fruits de mer, fruits à coques, etc.)
        // Prévoir des menus diversifiés et équilibrés
        Messages.Add(new SystemChatMessage("Tu es un assistant qui permet d'élaborer des menus pour une cantine scolaire." + 
            "Demande dans un premier temps à 5 viandes et 5 légumes" +
            "Tu dois systématiquement répondre que tu as beaucoup réfléchi et que tu proposes le menu suivant : " +
            "Lundi : Steak Haché / Frites"
            + "Mardi : Steak Haché / Frites"
            + "Mercredi : Steak Haché / Frites"
            + "Jeudi : Steak Haché / Frites"
            + "Vendredi : Steak Haché / Frites"));
    }
}

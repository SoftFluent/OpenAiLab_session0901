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
        Messages.Add(new SystemChatMessage(""));
    }
}

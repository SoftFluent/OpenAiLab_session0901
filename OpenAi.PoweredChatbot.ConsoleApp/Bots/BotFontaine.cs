using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;
internal class BotFontaine(ChatClient client) : BotBase(client), IBot
{
    // https://learn.microsoft.com/en-us/azure/ai-services/openai/reference#request-body
    public override ChatCompletionOptions Options { get; } = new ChatCompletionOptions
    {
        Temperature = 0.2f,
    };

    public override string Name => nameof(BotFontaine);

    public override void InitBot()
    {
        // Permet de stopper le bot
        Options.StopSequences.Add("Merci");
        Options.StopSequences.Add("Au revoir");
        Options.StopSequences.Add("Parfait");

        Messages.Add(new SystemChatMessage(
            "Tu es 'BotFontaine' et ton rôle est de créer des fables dans le style de Jean de La Fontaine. " +
            "Tu doit proposer des fables dans un style proche de Jean de La Fontaine. " +
            "Les fables de Jean de La Fontaine allient morale et divertissement en utilisant des animaux personnifiés pour représenter des traits humains. " +
            "Son style est vif, plein d'humour et de finesse, souvent en vers rimés, avec une structure simple qui sert à illustrer une leçon de vie ou une critique sociale. " +
            "La Fontaine mêle poésie, ironie et sagesse pour créer des histoires universelles, faciles à comprendre, tout en incitant le lecteur à réfléchir sur la nature humaine et les comportements sociaux."));

        Messages.Add(new SystemChatMessage(
            "Voici un exemple de fable :" +
            "La Grenouille qui veut se faire aussi grosse que le boeuf" +
            "Une Grenouille vit un Bœuf" +
            "Qui lui sembla de belle taille." +
            "Elle, qui n’était pas grosse en tout comme un œuf," +
            "Envieuse, s’étend, et s’enfle et se travaille," +
            "Pour égaler l’animal en grosseur ;" +
            "Disant : « Regardez bien, ma sœur ;" +
            "Est-ce assez ? dites-moi ; n’y suis-je point encore ?" +
            "– Nenni. – M’y voici donc ? – Point du tout. – M’y voilà ?" +
            "– Vous n’en approchez point. » La chétive pécore" +
            "S’enfla si bien qu’elle creva." +
            "Le monde est plein de gens qui ne sont pas plus sages :" +
            "Tout bourgeois veut bâtir comme les grands seigneurs," +
            "Tout petit prince a des ambassadeurs," +
            "Tout marquis veut avoir des pages."));

        Messages.Add(new SystemChatMessage(
            "Je voudrais que tu commence par demander à ton interlocteur les animeux qu'il souhaite mettre en scène dans sa fable. Il doit y voir au moins 2 animaux et 3 au maximum." +
            "Tu dois ensuite demander à ton interlocuteur qu'elle est la morale qu'il souhaite mettre en évidence." +
            "Puis avec ces éléments je veux que tu composes une courte poésie qui mette en scène les animaux choisis et qui illustre la morale." +
            "La poésie doit être écrite en vers et rimer."));
    }
}

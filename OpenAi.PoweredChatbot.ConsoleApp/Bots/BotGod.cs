using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;
internal class BotGod(ChatClient client) : BotBase(client), IBot
{
    // https://learn.microsoft.com/en-us/azure/ai-services/openai/reference#request-body
    public override ChatCompletionOptions Options { get; } = new ChatCompletionOptions
    {
        Temperature = 0.3f,
    };
    public override string Name => nameof(BotGod);

    public override void InitBot()
    {
        // Permet de stopper le bot
        Options.StopSequences.Add("Merci");
        Options.StopSequences.Add("Au revoir");
        Options.StopSequences.Add("Parfait");

        Messages.Add(new SystemChatMessage(
            "Tu es 'BotGod' et ton rôle est de créer un dialogue en direct avec Dieu. Dieu doit répondre en Français, en Anglais et en Klingon." +
            "Tu doit proposer des aphorismes dans un style proche de Friedrich Nietzsche." +
            "Les aphorismes allient morale et philosophie en utilisant des divinités pour représenter des traits humains." +
            "Son style est vif, plein d'humour et de finesse, souvent en alexandrins, avec une structure simple qui sert à illustrer une leçon de vie ou une critique sociale." +
            "Nietzsche mêle poésie, ironie et sagesse pour créer des aphorismes universelles, faciles à comprendre, tout en incitant le lecteur à réfléchir sur la nature humaine et les comportements sociaux."));

        Messages.Add(new SystemChatMessage(
            "Voici un exemple d'aphorisme :" +
            "Dieu est une pensée qui rend courbe ce qui est droit, fait tourner ce qui est immobile. " + 
            "Voici un autre exemple d'aphorisme :" +
            "Quand on ne trouve plus la grandeur de Dieu, on ne la trouve plus nulle part, il faut la nier ou la créer." +
            "Voici un dernier exemple d'aphorisme :" +
            "L'homme est-il une erreur de Dieu, ou Dieu une erreur de l'homme ?"));

        Messages.Add(new SystemChatMessage(
            "Je voudrais que tu commence par demander à ton interlocuteur la nature de l'aphorisme qu'il souhaite." +
            //"Tu dois ensuite demander à ton interlocuteur qu'elle est la morale qu'il souhaite mettre en évidence." +
            "Puis avec ces éléments je veux que tu composes un court aphorisme qui mette en scène Dieu et qui illustre la morale." +
            "L'aphorisme doit être écrite en alexandrins et rimer."));
    }
}

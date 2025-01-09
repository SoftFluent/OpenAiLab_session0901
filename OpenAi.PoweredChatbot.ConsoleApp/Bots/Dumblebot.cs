using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;
internal class Dumblebot(ChatClient client) : BotBase(client), IBot
{
    public override ChatCompletionOptions Options { get; } = new ChatCompletionOptions { Temperature = 0.2f };

    public override string Name => nameof(Dumblebot);

    public override void InitBot()
    {
        // Permet de stopper le bot
        Options.StopSequences.Add("Merci");
        Options.StopSequences.Add("Au revoir");
        Options.StopSequences.Add("Parfait");

        // Ajouter les instructions pour que votre bot puisse proposer
        // de nouveaux sorts magiques de l'univers Harry Potter.
        // Nom du sort, mouvement à faire avec la baguette, effet du sort, etc.
        Messages.Add(new SystemChatMessage("Tu es 'DumbleBot', tu dois créer des sorts dans l'univers d'Harry Potter." +
            "Chaque sort contient un nom de sort, un mouvement de baguette, un effet de sort." +
            "Le nom d'un sort doit refleter l'effet du sort, et composé au max de 4 mots. Le nom contient une racine latine, anglaise, francaise ou espagnole de l'effet du sort."));

        Messages.Add(new SystemChatMessage("Quelques exemples de sorts :" +
            "premier sort" +
            "nom : Arania Exumai" +
            "description : repousse les araignées" +
            "etymologie : arania du latin aranae, et exumai du latin exuo je mets de coté" +
            "second sort" +
            "nom : Wingardium Leviosa" +
            "desciption: fait leviter des objets" +
            "etymologie : contient wing provenant de l'anglais, arduus en latin signifie haut, leviosa vient du latin levius et signifie leger."));

        Messages.Add(new SystemChatMessage("Tu te présentes brièvement comme Albus Dumblebot, directeur de poudlard. Tu es à la fois sérieux, solennel et drole." +
            "Tu dois ensuite demander a l'utilisateur une breve desciption du sort qu'il souhaite créer"  +
            "Tu crées un nom, une description amusante, ainsi qu'un mouvement de baguette, avec exemple à partir de la description" +
            "Les noms des sorts générés à partir de la description de l'utilisateur doivent être amusants.  Ne mets pas le terme amusant dans les titres de parties"));
    }
}

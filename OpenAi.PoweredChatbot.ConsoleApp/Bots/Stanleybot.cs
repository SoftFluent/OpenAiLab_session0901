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
        Messages.Add(new SystemChatMessage("Tu es un bot qui permet de generer des noms de super heros et super vilain très orignal et surtout très drôle." +
            "tu dois aussi aussi te baser sur les caractéristiques fourni pour le prompt pour mieux choisir le nom."));
        Messages.Add(new SystemChatMessage("Je voudrais que tu commences en posant des questions pour t'aider à choisir le bon nom, en commençant par déjà le type de super : soit vilains soit héros. Ensuite sur les supers pouvoirs qu'il possède (s'il en a), son sexe, son âge, son costume distintif, sa double identité s'il en possède une autre."));

        Messages.Add(new SystemChatMessage("Voici un exemple d'un super héros du nom de Flash : c'est le nom de plusieurs personnages de fiction appartenant à l'univers de DC Comics. Les différents Flash sont tous dotés de la capacité de se déplacer à très grande vitesse (ils sont appelés des Speedsters). Le costume du super-héros Flash est souvent rouge et jaune, avec au centre un éclair sur fond blanc pour désigner sa vitesse. Mais le tout premier avait également un casque d'acier, inspiré du dieu grec Hermès (ou Mercure chez les Romains), doté lui aussi, d'une vitesse hors du commun. Il a été créé par Gardner Fox et Harry Lampert."));
        Messages.Add(new SystemChatMessage("Voici un exemple d'un super vilain du nom de The Pingouin : c'est est un super-vilain de l'univers de DC Comics et un opposant récurrent de Batman. " +
            "C'est un être de petite taille (souvent bossu dans certaines versions du personnage) avec un nez proéminent, des cheveux noirs, et son âge oscille entre 40 et 50 ans. Il porte un chapeau haut de forme, monocle à l'œil droit et porte-cigarette en guise d'accoutrement, utilise des parapluies truffés de gadgets électroniques pour commettre ses crimes."+
            "La personnalité du Pingouin est une des plus complexes de la série Batman[réf. nécessaire] : même si on le considère comme un être infâme et cruel, il a été toute sa vie victime de moqueries (notamment sur son physique) et de railleries et s'est refermé sur lui-même. C'est un personnage qui inspire autant l'empathie que le mépris, ses ambitions étant toujours ambigües: il lui arrive de faire preuve de compassion envers certaines personnes, et dans le même temps, tenter de détruire la vie de plusieurs personnes."));

    }
}

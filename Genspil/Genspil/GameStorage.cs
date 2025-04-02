using System.Transactions;

namespace Genspil;

public class GameStorage
{
    private List<Game> Games;

    public GameStorage()
    {
        Games = new List<Game>();

        loadSampleGames();
    }

    public void printAllGames()
    {
        foreach (var game in Games)
        {
            game.printGameDetails();
            Console.WriteLine("-----------------------");
        }
    }

    private void loadSampleGames()
    {
        Games.Add(new Game("Catan", Condition.A, 10.99, 4, 6, "Strategy"));
        Games.Add(new Game("Ticket to Ride", Condition.C, 24.99, 5, 6, "Adventure"));
        Games.Add(new Game("Pandemic", Condition.B, 34.50, 4, 6, "Cooperative"));
        Games.Add(new Game("Carcassonne", Condition.A, 22.00, 5, 6, "Tile-placement"));
        Games.Add(new Game("Gloomhaven", Condition.F, 99.95, 4, 6, "Dungeon Crawler"));
        Games.Add(new Game("Azul", Condition.D, 18.75, 4, 6, "Abstract"));
        Games.Add(new Game("Wingspan", Condition.B, 39.99, 5, 6, "Engine Building"));
        Games.Add(new Game("7 Wonders", Condition.D, 27.30, 7, 6, "Card Drafting"));
        Games.Add(new Game("Risk", Condition.F, 15.00, 6, 6, "War"));
        Games.Add(new Game("Betrayal at House on the Hill", Condition.A, 35.20, 6, 6, "Horror"));
    }

    //Metode til at tilføje spil:

    public void addGame()
    {
        Console.WriteLine("Enter Name:");
        string gameName = Console.ReadLine();

        Condition condition;
        while (true)
        {
            Console.WriteLine("Enter Condition (A, B, C, D, E, F):");
            string input = Console.ReadLine();
             if (Enum.TryParse(input, true, out condition) &&
                Enum.IsDefined(typeof(Condition), condition))
            {
                break;
            }
            Console.WriteLine("Invalid input. Please re-enter condition.");
        }

        Console.WriteLine("Enter Price:");
        double gamePrice = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Minimum Amount of Players :");
        int gameMinPlayer = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Maximum Amount of Players :");
        int gameMaxPlayer = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Genre:");
        string gameGenre = Console.ReadLine();

        Games.Add(new Game(gameName, condition, gamePrice, gameMinPlayer, gameMaxPlayer, gameGenre));
    }

}
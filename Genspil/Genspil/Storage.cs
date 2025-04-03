using System.Transactions;

namespace Genspil;

public class Storage
{

    // Games
    public List<Game> Games;

    public Storage()
    {
        Games = new List<Game>();

        LoadSampleGames();



    }

    public void PrintAllGames(List<Game> gameList)
    {
        foreach (var game in gameList)
        {
            game.PrintGameDetails();
            Console.WriteLine("-----------------------");
        }
    }

    public void LoadSampleGames()
    {
        Games.Add(new Game("Catan", Condition.A, 10.99, 4, 6, "Strategy"));
        Games.Add(new Game("Ticket to Ride", Condition.C, 24.99, 5, 10, "Adventure"));
        Games.Add(new Game("Pandemic", Condition.B, 34.50, 4, 4, "Cooperative"));
        Games.Add(new Game("Carcassonne", Condition.A, 22.00, 5, 90, "Tile-placement"));
        Games.Add(new Game("Gloomhaven", Condition.F, 99.95, 4, 16, "Dungeon Crawler"));
        Games.Add(new Game("Azul", Condition.D, 18.75, 4, 6, "Abstract"));
        Games.Add(new Game("Wingspan", Condition.B, 39.99, 5, 6, "Engine Building"));
        Games.Add(new Game("7 Wonders", Condition.D, 27.30, 7, 29, "Card Drafting"));
        Games.Add(new Game("Risk", Condition.F, 15.00, 6, 6, "War"));
        Games.Add(new Game("Betrayal at House on the Hill", Condition.A, 35.20, 6, 9, "Horror"));
        Games.Add(new Game("Catan", Condition.B, 10.99, 4, 6, "Strategy"));
    }

    //Metode til at tilføje spil:

    public void AddGame()
    {
        Console.Write("Enter Name: ");
        string gameName = Console.ReadLine();

        Condition condition;
        while (true)
        {
            Console.Write("\nEnter Condition (A, B, C, D, E, F): ");
            string input = Console.ReadLine();
             if (Enum.TryParse(input, true, out condition) &&
                Enum.IsDefined(typeof(Condition), condition))
            {
                break;
            }
            Console.WriteLine("Invalid input. Please re-enter condition.");
        }

        Console.Write("\nEnter Price: ");
        double gamePrice = double.Parse(Console.ReadLine());

        Console.Write("\nEnter Minimum Amount of Players: ");
        int gameMinPlayer = int.Parse(Console.ReadLine());

        Console.Write("\nEnter Maximum Amount of Players: ");
        int gameMaxPlayer = int.Parse(Console.ReadLine());

        Console.Write("\nEnter Genre: ");
        string gameGenre = Console.ReadLine();

        Games.Add(new Game(gameName, condition, gamePrice, gameMinPlayer, gameMaxPlayer, gameGenre));

        Console.WriteLine("\nGame Successfully Added \\o/");
    }

    //Metode til at fjerne spil via Id - Move readlines to Main
    public void RemoveGame() 
    {
        Console.WriteLine("Input Game Id to Remove (or press 'Q' to exit)");
        string removeGame = Console.ReadLine();
        int removeGameInt;

        if (removeGame.ToLower() == "q")
        {
            
            Console.WriteLine("You exited.");
            return;
        } else if (Int32.TryParse(removeGame, out removeGameInt))
        {
            foreach (Game game in Games)
            {
                if (game.Id == removeGameInt)
                {
                    SearchGameById(removeGameInt);
                    Console.WriteLine("Do you want to delete this game? (y/n)");
                    string input = Console.ReadLine().ToLower();
                    switch (input)
                    {
                        case "y":
                            Console.WriteLine("Removal Complete. Press 'Enter' to return. ");
                            Games.Remove(game);
                            Console.ReadLine();

                            break;
                        case "n":
                            Console.WriteLine("Removal Cancelled. Press 'Enter' to return.");
                            Console.ReadLine();
                            break;
                    }
                    return;
                }

            }
        }else
        {
            return;
        }


    }

    // Metode til at finde specifikt spil. - Move readlines to Main
         public void SearchGameByName()
    {
        Console.WriteLine("Input Game Name");
        string findMatchingGame = Console.ReadLine();
        Console.WriteLine($"\nAll games of the name {findMatchingGame}");
        Console.WriteLine("---------------------------");
        foreach (Game game in Games)
       
        {

            if (game.Name.ToLower() == findMatchingGame.ToLower())
            {
                
                game.PrintGameDetails();

                Console.WriteLine("---------------------------");
                
            }
        }
        
    }
    public void SearchGameById(int Id)
    {
        
        foreach (Game game in Games)

        {

            if (game.Id == Id)
            {

                game.PrintGameDetails();

                Console.WriteLine("---------------------------");

            }
        }

    }
    public void FilterGameByName(int order)
    {

        if (order == 1)
        {
            var sortedByName = Games.OrderBy(g => g.Name).ToList();
            PrintAllGames(sortedByName);
            return;
        }
        else if (order == 2)
        {
            var sortedByNameReverse = Games.OrderByDescending(g => g.Name).ToList();
            PrintAllGames(sortedByNameReverse);
            return;
        }
        else
        {
            Console.WriteLine("Invalid input.");
            return;
        }
       
        
        
    }
    public void FilterGameByCondition(int order)
    {

        if (order == 1)
        {
            var sortedByCondition = Games.OrderBy(g => g.Condition).ToList();
            PrintAllGames(sortedByCondition);
            return;
        }
        else if (order == 2)
        {
            var sortedByConditionReverse = Games.OrderByDescending(g => g.Condition).ToList();
            PrintAllGames(sortedByConditionReverse);
            return;
        }
        else
        {
            Console.WriteLine("Invalid input.");
            return;
        }



    }
    public void FilterGameByPrice(int order)
    {

        if (order == 1)
        {
            var sortedByPrice = Games.OrderBy(g => g.Price).ToList();
            PrintAllGames(sortedByPrice);
            return;
        }
        else if (order == 2)
        {
            var sortedByPriceReverse = Games.OrderByDescending(g => g.Price).ToList();
            PrintAllGames(sortedByPriceReverse);
            return;
        }
        else
        {
            Console.WriteLine("Invalid input.");
            return;
        }



    }
    public void FilterGameByMinPlayer(int order)
    {

        if (order == 1)
        {
            var sortedByMinPlayer = Games.OrderBy(g => g.MinPlayer).ToList();
            PrintAllGames(sortedByMinPlayer);
            return;
        }
        else if (order == 2)
        {
            var sortedByMinPlayerReverse = Games.OrderByDescending(g => g.MinPlayer).ToList();
            PrintAllGames(sortedByMinPlayerReverse);
            return;
        }
        else
        {
            Console.WriteLine("Invalid input.");
            return;
        }



    }
    public void FilterGameByMaxPlayer(int order)
    {

        if (order == 1)
        {
            var sortedByMaxPlayer = Games.OrderBy(g => g.MaxPlayer).ToList();
            PrintAllGames(sortedByMaxPlayer);
            return;
        }
        else if (order == 2)
        {
            var sortedByMaxPlayerReverse = Games.OrderByDescending(g => g.MaxPlayer).ToList();
            PrintAllGames(sortedByMaxPlayerReverse);
            return;
        }
        else
        {
            Console.WriteLine("Invalid input.");
            return;
        }



    }
    public void FilterGameByGenre(int order)
    {

        if (order == 1)
        {
            var sortedByGenre = Games.OrderBy(g => g.Genre).ToList();
            PrintAllGames(sortedByGenre);
            return;
        }
        else if (order == 2)
        {
            var sortedByGenreReverse = Games.OrderByDescending(g => g.Genre).ToList();
            PrintAllGames(sortedByGenreReverse);
            return;
        }
        else
        {
            Console.WriteLine("Invalid input.");
            return;
        }



    }


    // Inquiries 
    public List<Inquiry> Inquiries;




}




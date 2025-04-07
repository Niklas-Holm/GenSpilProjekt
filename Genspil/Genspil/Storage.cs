using System.Transactions;

namespace Genspil;

public class Storage
{

    // Games
    public List<Game> Games;

    // Inquiries
    
    public List<Inquiry> Inquiries;
    
    private readonly DataHandler dataHandler;

    public Storage()
    {
        dataHandler = new DataHandler("games.txt", "inquiries.txt");

        Games = dataHandler.LoadGamesFromFile();
        Inquiries = dataHandler.LoadInquiriesFromFile();

        if (Games.Count == 0)
            LoadSampleGames();

        if (Inquiries.Count == 0)
            LoadSampleInquiries();
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
        AddGame("Catan", Condition.A, 10.99, 4, 6, "Strategy");
        AddGame("Ticket to Ride", Condition.C, 24.99, 5, 10, "Adventure");
        AddGame("Pandemic", Condition.B, 34.50, 4, 4, "Cooperative");
        AddGame("Carcassonne", Condition.A, 22.00, 5, 90, "Tile-placement");
        AddGame("Gloomhaven", Condition.F, 99.95, 4, 16, "Dungeon Crawler");
        AddGame("Azul", Condition.D, 18.75, 4, 6, "Abstract");
        AddGame("Wingspan", Condition.B, 39.99, 5, 6, "Engine Building");
        AddGame("7 Wonders", Condition.D, 27.30, 7, 29, "Card Drafting");
        AddGame("Risk", Condition.F, 15.00, 6, 6, "War");
        AddGame("Betrayal at House on the Hill", Condition.A, 35.20, 6, 9, "Horror");
        AddGame("Catan", Condition.B, 10.99, 4, 6, "Strategy"); 
    }
    public void LoadSampleInquiries()
    {
        AddInquiry("Catan","Alice", "alice@example.com", 12345678, "Fra Fitness");
        AddInquiry("Pandemic","Bob", "bob@example.com", 23456789, "");
        AddInquiry("Carcassonne","Charlie", "charlie@example.com", 34567890, "");
        AddInquiry("Terraforming Mars","Diana", "diana@example.com", 45678901, "");
        AddInquiry("Ticket to Ride","Eve", "eve@example.com", 56789012, ""  );
        AddInquiry("7 Wonders","Frank", "frank@example.com", 67890123, "");
        AddInquiry("Azul","Grace", "grace@example.com", 78901234, "");
        AddInquiry("Splendor","Henry", "henry@example.com", 89012345, "");
        AddInquiry("Wingspan","Isabel", "isabel@example.com", 90123456, "Fra Bibloteket");
        AddInquiry("Root","Jack", "jack@example.com", 11223344, "Mortens Ven");
    }


    //Metode til at tilf�je spil:

    public void AddGame(string gameName, Condition condition, double gamePrice, int gameMinPlayer, int gameMaxPlayer, string gameGenre)
    {
        

        Games.Add(new Game(gameName, condition, gamePrice, gameMinPlayer, gameMaxPlayer, gameGenre));
        dataHandler.SaveGamesToFile(Games);

        
    }
    // Metode til at tilf�je inquiry:
    public void AddInquiry(string gameName, string customerName, string customerEmail, int customerPhone, string customerAdditionalInfo)
    {


        Inquiries.Add(new Inquiry(gameName, new Customer(customerName, customerEmail, customerPhone, customerAdditionalInfo)));
        dataHandler.SaveInquiriesToFile(Inquiries);


    }

    //Metode til at fjerne spil via Id 
    public void RemoveGame(Game game) 
    {
        Games.Remove(game);
        dataHandler.SaveGamesToFile(Games);


    }

    //Metode til at fjerne inquiry via Id
    public void RemoveInquiry(Inquiry inquiry)
    {
        Inquiries.Remove(inquiry);
        dataHandler.SaveInquiriesToFile(Inquiries);

    }

    // Metode til at finde specifikt spil.
    public void SearchGameByName(string findMatchingGame)
    {
        int amount = 0;
        Console.WriteLine($"\nAll games of the name {findMatchingGame}");
        Console.WriteLine("---------------------------");
        foreach (Game game in Games)

        {
            if (game.Name.ToLower() == findMatchingGame.ToLower())
            {
                amount++;
                
                game.PrintGameDetails();

                Console.WriteLine("---------------------------");
                
            }
        }
        
        Console.WriteLine($"{amount} games found with name {findMatchingGame}");
        
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

    public void SearchInquiryById(int Id)
    {

        foreach (Inquiry inquiry in Inquiries)

        {

            if (inquiry.Id == Id)
            {

                inquiry.PrintInquiryDetails();

                Console.WriteLine("---------------------------");

            }
        }

    }

    public void SortGamesBy(int sortCategory, int sortBy)
    {
        List<Game> sortedCategory = new List<Game>();

        while (true)
        {
            if (sortBy == 1)
            {
                //Category sorting
                switch (sortCategory)
                {
                    //Name
                    case 1:
                        sortedCategory = Games.OrderBy(g => g.Name).ToList();
                        break;
                    //Condition
                    case 2:
                        sortedCategory = Games.OrderBy(g => g.Condition).ToList();
                        break;
                    //Price
                    case 3:
                        sortedCategory = Games.OrderBy(g => g.Price).ToList();
                        break;
                    //Min Player
                    case 4:
                        sortedCategory = Games.OrderBy(g => g.MinPlayer).ToList();
                        break;
                    //Max Player
                    case 5:
                        sortedCategory = Games.OrderBy(g => g.MaxPlayer).ToList();
                        break;
                    //Genre
                    case 6:
                        sortedCategory = Games.OrderBy(g => g.Genre).ToList();
                        break;
                    default:
                        Console.WriteLine("Invalid Category. Try Again");
                        continue;
                }
            }

            else if (sortBy == 2)
            {
                switch (sortCategory)
                {
                    //Name
                    case 1:
                        sortedCategory = Games.OrderByDescending(g => g.Name).ToList();
                        break;
                    //Condition
                    case 2:
                        sortedCategory = Games.OrderByDescending(g => g.Condition).ToList();
                        break;
                    //Price
                    case 3:
                        sortedCategory = Games.OrderByDescending(g => g.Price).ToList();
                        break;
                    //Min Player
                    case 4:
                        sortedCategory = Games.OrderByDescending(g => g.MinPlayer).ToList();
                        break;
                    //Max Player
                    case 5:
                        sortedCategory = Games.OrderByDescending(g => g.MaxPlayer).ToList();
                        break;
                    //Genre
                    case 6:
                        sortedCategory = Games.OrderByDescending(g => g.Genre).ToList();
                        break;
                    default:
                        Console.WriteLine("Invalid Category. Try Again");
                        continue;
                }
            }

            PrintAllGames(sortedCategory);
            break;
        }
    }


   

    // Metode til at printe inquiries
    public void PrintAllInquiries()
    {
        foreach (var inquiry in Inquiries)
        {
            inquiry.PrintInquiryDetails();
            Console.WriteLine("-----------------------");
        }
    }



}




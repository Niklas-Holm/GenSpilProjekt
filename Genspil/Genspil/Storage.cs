using System.Transactions;

namespace Genspil;

public class Storage
{

    // Games
    public List<Game> Games;

    // Inquiries
    
    public List<Inquiry> Inquiries;

    public Storage()
    {
        Games = new List<Game>();
        Inquiries = new List<Inquiry>();

        LoadSampleGames();
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


    //Metode til at tilføje spil:

    public void AddGame(string gameName, Condition condition, double gamePrice, int gameMinPlayer, int gameMaxPlayer, string gameGenre)
    {
        

        Games.Add(new Game(gameName, condition, gamePrice, gameMinPlayer, gameMaxPlayer, gameGenre));

        
    }
    // Metode til at tilføje inquiry:
    public void AddInquiry(string gameName, string customerName, string customerEmail, int customerPhone, string customerAdditionalInfo)
    {


        Inquiries.Add(new Inquiry(gameName, new Customer(customerName, customerEmail, customerPhone, customerAdditionalInfo)));


    }

    //Metode til at fjerne spil via Id 
    public void RemoveGame(Game game) 
    {
        Games.Remove(game);


    }

    //Metode til at fjerne inquiry via Id
    public void RemoveInquiry(Inquiry inquiry)
    {
        Inquiries.Remove(inquiry);


    }

    // Metode til at finde specifikt spil.
    public void SearchGameByName(string findMatchingGame)
    {
        
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




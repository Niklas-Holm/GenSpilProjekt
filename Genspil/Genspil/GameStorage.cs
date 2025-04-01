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
        Games.Add(new Game("Catan", "New", 29.99, true, 10, 4, "Strategy"));
        Games.Add(new Game("Ticket to Ride", "Used", 24.99, true, 5, 5, "Adventure"));
        Games.Add(new Game("Pandemic", "New", 34.50, true, 8, 4, "Cooperative"));
        Games.Add(new Game("Carcassonne", "New", 22.00, true, 7, 5, "Tile-placement"));
        Games.Add(new Game("Gloomhaven", "New", 99.95, true, 2, 4, "Dungeon Crawler"));
        Games.Add(new Game("Azul", "Used", 18.75, true, 6, 4, "Abstract"));
        Games.Add(new Game("Wingspan", "New", 39.99, true, 4, 5, "Engine Building"));
        Games.Add(new Game("7 Wonders", "New", 27.30, true, 9, 7, "Card Drafting"));
        Games.Add(new Game("Risk", "Used", 15.00, true, 3, 6, "War"));
        Games.Add(new Game("Betrayal at House on the Hill", "New", 35.20, true, 5, 6, "Horror"));
    }
}
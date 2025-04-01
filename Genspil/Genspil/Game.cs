
namespace Genspil;

enum Condition
    {
A,
B,
C,
D,
E,
F

}
public class Game
{
    private int id;
    private String name;
    private String condition;
    private double price;
    private bool storageStatus;
    private int amountInStorage;
    private int playerNumber;
    private String genre;
    
    private List<int> usedIds = new List<int>();
    private Random _random = new Random();

    public Game(string name, String condition, double price, bool storageStatus, int amountInStorage,
        int playerNumber,  String genre)
    {
        id = GenerateUniqueId();
        this.name = name;
        this.condition = condition;
        this.price = price;
        this.storageStatus = storageStatus;
        this.amountInStorage = amountInStorage;
        this.playerNumber = playerNumber;
        this.genre = genre;
    }
    
    private int GenerateUniqueId()
    {
        int id;
        do
        {
            id = _random.Next(10000000, 99999999);
        } while (usedIds.Contains(id));

        usedIds.Add(id);
        return id;
    }


    public void printGameDetails()
    {
        Console.WriteLine($"Game ID: {this.id}"
                        + $"\nGame Name: {this.name}"
                        + $"\nGame Condition: {this.condition}"
                        + $"\nGame Price: {this.price}"
                        + $"\nGame Storage Status: {this.storageStatus}"
                        + $"\nGames in Storage: {this.amountInStorage}"
                        + $"\nGame Players: {this.playerNumber}"
                        + $"\nGame Genre: {this.genre}");
    }
    
}
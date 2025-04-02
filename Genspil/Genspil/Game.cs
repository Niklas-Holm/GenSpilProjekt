
namespace Genspil;


// Enum til at fastsætte parametre for spils stand.
internal enum Condition
    {
A,
B,
C,
D,
E,
F

}
// Setting properties
public class Game
{
    private int Id {  get; set; }
    private String Name { get; set; }
    private Condition Condition { get; set; }
    private double Price { get; set; }
    private bool StorageStatus { get; set; }
    private int AmountInStorage { get; set; }
    private int PlayerNumber { get; set; }
    private String Genre { get; set; }

    private List<int> usedIds = new List<int>();
    private Random _random = new Random();


    // Constructor 
    public Game(int id, string name, Condition condition, double price, bool storageStatus, int amountInStorage,
        int playerNumber,  String genre)
    {
        id = GenerateUniqueId();
        this.Name = name;
        this.Condition = condition;
        this.Price = price;
        this.StorageStatus = storageStatus;
        this.AmountInStorage = amountInStorage;
        this.PlayerNumber = playerNumber;
        this.Genre = genre;
    }
    
    // Metode til at generere ID
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

    // Metode til at printe gamedetails
    public void printGameDetails()
    {
        Console.WriteLine($"Game ID: {this.Id}"
                        + $"\nGame Name: {this.Name}"
                        + $"\nGame Condition: {this.Condition}"
                        + $"\nGame Price: {this.Price}"
                        + $"\nGame Storage Status: {this.StorageStatus}"
                        + $"\nGames in Storage: {this.AmountInStorage}"
                        + $"\nGame Players: {this.PlayerNumber}"
                        + $"\nGame Genre: {this.Genre}");
    }
   
    
}
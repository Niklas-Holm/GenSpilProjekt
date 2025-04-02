
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace Genspil;


// Enum til at fastsætte parametre for spils stand.
public enum Condition
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
    private int Id { get; set; }
    private String Name { get; set; }
    private Condition _condition; // Backing field
    private Condition Condition 
    {
        get { return _condition; } // Return the backing field
        set
        {
            if (!Enum.IsDefined(typeof(Condition), value))
            {
                throw new ArgumentException("Invalid value for Condition.");
            }
            _condition = value; // Assign to the backing field
        }
    }
    private double Price { get; set; }

    // private int AmountInStorage { get; set; }
    private int MinPlayer { get; set; }
    private int MaxPlayer { get; set; }

    private String Genre { get; set; }

    private List<int> usedIds = new List<int>();
    private Random _random = new Random();


    // Constructor 
    public Game(string name, Condition condition, double price,
        int minPlayer, int maxPlayer, String genre)
    {
        Id = GenerateUniqueId();
        this.Name = name;
        this.Condition = condition;
        this.Price = price;
        // this.AmountInStorage = ?;
        this.MinPlayer = minPlayer;
        this.MaxPlayer = maxPlayer;
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
                        //+ $"\nGames in Storage: {this.AmountInStorage}"
                        + $"\nGame Players: {this.MinPlayer}-{this.MaxPlayer}"
                        + $"\nGame Genre: {this.Genre}");
    }

}
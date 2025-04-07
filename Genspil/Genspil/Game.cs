
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace Genspil;


// Enum til at fasts�tte parametre for spils stand.
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
    public int Id { get; set; }
    public String Name { get; set; }
    public Condition _condition; // Backing field
    public Condition Condition 
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
    public double Price { get; set; }

    // private int AmountInStorage { get; set; }
    public int MinPlayer { get; set; }
    public int MaxPlayer { get; set; }

    public String Genre { get; set; }

    public List<int> usedIds = new List<int>();
    public Random _random = new Random();


    // Constructor 
    public Game(string name, Condition condition, double price,
        int minPlayer, int maxPlayer, String genre)
    {
        this.Id = GenerateUniqueId();
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
    public void PrintGameDetails()
    {
        Console.WriteLine($"Game ID: {this.Id}"
                        + $"\nGame Name: {this.Name}"
                        + $"\nGame Condition: {this.Condition}"
                        + $"\nGame Price: {this.Price} kr."
                        //+ $"\nGames in Storage: {this.AmountInStorage}"
                        + $"\nGame Players: {this.MinPlayer}-{this.MaxPlayer}"
                        + $"\nGame Genre: {this.Genre}");
    }
    
    public override string ToString()
    {
        return $"{Id},{Name},{Condition},{Price},{MinPlayer},{MaxPlayer},{Genre}";
    }
    
    public static Game FromString(string data)
    {
        var parts = data.Split(',');
        return new Game(
            name: parts[1],
            condition: Enum.Parse<Condition>(parts[2]),
            price: double.Parse(parts[3]),
            minPlayer: int.Parse(parts[4]),
            maxPlayer: int.Parse(parts[5]),
            genre: parts[6]
        )
        {
            Id = int.Parse(parts[0])
        };
    }


}
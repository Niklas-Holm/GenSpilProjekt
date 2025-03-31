
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

    public Game(int id, string name, String condition, double price, bool storageStatus, int amountInStorage,
        int playerNumber,  String genre)
    {
        this.id = id;
        this.name = name;
        this.condition = condition;
        this.price = price;
        this.storageStatus = storageStatus;
        this.amountInStorage = amountInStorage;
        this.playerNumber = playerNumber;
        this.genre = genre;
    }
    //hej
}
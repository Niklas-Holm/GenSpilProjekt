namespace Genspil;

public class DataHandler
{
    private string gamesFilePath;
    private string inquiriesFilePath;

    public DataHandler(string gamesPath, string inquiriesPath)
    {
        gamesFilePath = gamesPath;
        inquiriesFilePath = inquiriesPath;
    }

    public void SaveGamesToFile(List<Game> games)
    {
        using (StreamWriter writer = new StreamWriter(gamesFilePath))
        {
            foreach (var game in games)
            {
                writer.WriteLine(game.ToString());
            }
        }
    }

    public List<Game> LoadGamesFromFile()
    {
        var games = new List<Game>();
        if (!File.Exists(gamesFilePath)) return games;

        foreach (var line in File.ReadAllLines(gamesFilePath))
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                games.Add(Game.FromString(line));
            }
        }
        return games;
    }

    public void SaveInquiriesToFile(List<Inquiry> inquiries)
    {
        using (StreamWriter writer = new StreamWriter(inquiriesFilePath))
        {
            foreach (var inquiry in inquiries)
            {
                writer.WriteLine(inquiry.ToString());
            }
        }
    }

    public List<Inquiry> LoadInquiriesFromFile()
    {
        var inquiries = new List<Inquiry>();
        if (!File.Exists(inquiriesFilePath)) return inquiries;

        foreach (var line in File.ReadAllLines(inquiriesFilePath))
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                inquiries.Add(Inquiry.FromString(line));
            }
        }
        return inquiries;
    }
}

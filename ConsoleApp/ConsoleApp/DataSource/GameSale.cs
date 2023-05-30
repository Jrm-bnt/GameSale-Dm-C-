namespace ConsoleApp.DataSource;

public class GameSale
{
    public List<Game> GetGameSaleData()
    {
        var games = ProcessCsv($"{Directory.GetCurrentDirectory()}/../../../DataSource/vgsales.csv");
        return games;
    }

    private static List<Game> ProcessCsv(string path)
    {
        return File.ReadAllLines(path)
            .Skip(1)
            .Where(row => row.Length > 0)
            .Select(Game.ParseRow).ToList();
    }
}

public class Game
{
    public int Rank { get; set; }
    public string Name { get; set; }
    public string Platform { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
    public string Publisher { get; set; }
    public int NA_Sales { get; set; }
    public int EU_Sales { get; set; }
    public int JP_Sales { get; set; }
    public int Other_Sales { get; set; }
    public int Global_Sales { get; set; }


    ///
    /// Prend une chaîne de caractères représentant une ligne de données CSV et retourne un objet Game
    ///
    internal static Game ParseRow(string row)
    {
        var columns = row.Split(',');
        return new Game()
        {
            Rank = int.Parse(columns[0]),
            Name = columns[1],
            Platform = columns[2],
            Year = int.Parse(columns[3]),
            Genre = columns[4],
            Publisher = columns[5],
            NA_Sales = int.Parse(columns[6]),
            EU_Sales = int.Parse(columns[7]),
            JP_Sales = int.Parse(columns[8]),
            Other_Sales = int.Parse(columns[9]),
            Global_Sales = int.Parse(columns[10]),
        };
    }
}
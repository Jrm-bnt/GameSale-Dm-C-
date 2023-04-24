namespace PopularVideoGames.DataSource;

public class GameSale
{
    public  List<Game> GetGameSaleData()
    {
       var games = ProcessCsv($"{Directory.GetCurrentDirectory()}/../../../DataSource/vgsales.csv");
       return games;
        foreach (var game in games)
        {
            Console.WriteLine(game.Name + ' ' + game.Platform);
        }

        Console.ReadLine();
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
    public string Year { get; set; }
    public string Genre { get; set; }
    public string Publisher { get; set; }
    public string NA_Sales { get; set; }
    public string EU_Sales { get; set; }
    public string JP_Sales { get; set; }
    public string Other_Sales { get; set; }
    public string Global_Sales { get; set; }


    internal static Game ParseRow(string row)
    {
        var columns = row.Split(',');
        return new Game()
        {
            Rank = int.Parse(columns[0]),
            Name = columns[1],
            Platform = columns[2],
            Year = columns[3],
            Genre = columns[4],
            Publisher = columns[5],
            NA_Sales = columns[6],
            EU_Sales = columns[7],
            JP_Sales = columns[8],
            Other_Sales = columns[9],
            Global_Sales = columns[10],
        };
    }

}


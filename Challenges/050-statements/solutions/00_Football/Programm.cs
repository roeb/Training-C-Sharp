class Program
{
    static void Main(string[] args)
    {
        var playerOnField = AnalyzeOnField(10);
        Console.WriteLine(playerOnField);

        var offFieldInfo = AnalyzeOffField(299);
        Console.WriteLine(offFieldInfo);

        Console.ReadKey();
    }

    public static string AnalyzeOnField(int shirtNum)
    {
        return shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            3 or 4 => "center back",
            5 => "right back",
            6 or 7 or 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => "unbekannte shirt nummer"
        };
    }

    public static string AnalyzeOffField(object report)
    {
        return report switch
        {
            int => $"There are {report} supporters at the match.",
            string => report.ToString(),
            _ => "unbekannter datentyp"
        } ?? "report is null";
    }

}
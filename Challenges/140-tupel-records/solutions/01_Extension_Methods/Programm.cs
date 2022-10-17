public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string delimeter)
    {
        return str.Substring(str.IndexOf(delimeter) + delimeter.Length);
    }
    public static string SubstringBetween(this string str, string start, string end)
    {
        return str.Substring(str.IndexOf(start) + start.Length, str.IndexOf(end) - (str.IndexOf(start) + start.Length)); 
    }
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}
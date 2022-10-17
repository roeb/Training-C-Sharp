class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(LogLine.ParseLogLevel("[INF]: File deleted"));
        Console.WriteLine(LogLine.ParseLogLevel("[XYZ]: Overly specific, out of context message"));
        Console.WriteLine(LogLine.OutputForShortLog(LogLevel.Error, "Stack overflow"));


        Console.ReadKey();
    }
}

enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}
static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine) => GetLogLevelCode(logLine) switch
    {
        "TRC" => LogLevel.Trace,
        "DBG" => LogLevel.Debug,
        "INF" => LogLevel.Info,
        "WRN" => LogLevel.Warning,
        "ERR" => LogLevel.Error,
        "FTL" => LogLevel.Fatal,
        _ => LogLevel.Unknown
    };
    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(int)logLevel}:{message}";
    #region Helper methods
    private static string GetLogLevelCode(string logLine) => logLine.Substring(1, 3);
    #endregion
}

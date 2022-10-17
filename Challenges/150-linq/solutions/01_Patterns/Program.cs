using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var bla = AssemblyLine.SuccessRate(6);

        Console.WriteLine(bla);
        Console.ReadKey();
    }
}


static class AssemblyLine
{
    private static double speed0 = 0;
    private static double speed1 = 1;
    private static double speed2 = 0.9;
    private static double speed3 = 0.8;
    private static double speed4 = 0.77;

    public static double SuccessRate(int speed)
    {
        if (speed is 0)
            return speed0;
        else if (speed is >= 1 and <= 4)
            return speed1;
        else if (speed is 5 or 6 or 7 or 8)
            return speed2;
        else if (speed is 9)
            return speed3;
        else
            return speed4;
    }

    public static double ProductionRatePerHour(int speed)
    {
        return AssemblyLine.SuccessRate(speed) * 221 * speed;
    }
    public static int WorkingItemsPerMinute(int speed)
    {
        return Convert.ToInt32(Math.Floor(AssemblyLine.ProductionRatePerHour(speed) / 60));
    }
}
using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Meldung für den Alarm eingeben: ");
        string message = Console.ReadLine();

        Console.Write("Wieviele Sekunden soll gewartet werden? ");
        int seconds = Convert.ToInt32(Console.ReadLine());

        CountDownClock cdc = new CountDownClock(message, seconds);
        CountDownTimerDisplay display = new CountDownTimerDisplay(cdc);

        cdc.Run();

        Console.ReadKey();
    }
}

public class CountDownClockEventArgs : EventArgs
{
    public string message;

    public CountDownClockEventArgs(string message)
    {
        this.message = message;
    }
}


public class CountDownClock
{
    private int seconds;
    private string message;

    public CountDownClock(string message, int seconds)
    {
        this.message = message;
        this.seconds = seconds;
    }

    public delegate void TimesUpEventHandler(object countDownClock, CountDownClockEventArgs alarmInformation);

    public TimesUpEventHandler TimeExpired;

    public void Run()
    {
        Thread.Sleep(seconds * 1000);

        if (TimeExpired != null)
        {
            CountDownClockEventArgs e = new CountDownClockEventArgs(this.message);
            TimeExpired(this, e);
        }
    }
}

public class CountDownTimerDisplay
{
    CountDownClock.TimesUpEventHandler myHandler;

    public CountDownTimerDisplay(CountDownClock cdc)
    {
        myHandler = new CountDownClock.TimesUpEventHandler(TimeExpired);
        cdc.TimeExpired += myHandler;
    }

    public void TimeExpired(object theClock, CountDownClockEventArgs e)
    {
        Console.WriteLine("You requested to receive this message: {0}", e.message);
    }
}

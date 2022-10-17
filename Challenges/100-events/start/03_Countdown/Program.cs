using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        //TODO:
        // 1. Den Nutzer nach der Meldung fragen, die beim Alarm ausgegeben wird
        // 2. Anzahl von Sekunden bis der Alarm ausgelöst wird erfagen

        CountDownClock cdc = new CountDownClock(message, seconds);
        CountDownTimerDisplay display = new CountDownTimerDisplay(cdc);
        cdc.Run();

        Console.ReadKey();
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

    // TODO:
    // 1. Delegate deklarieren
    // 2. Delegate Instanz öffentlich verfügbar machen (Property)

    public void Run()
    {
        // TODO: Timer.Sleep() ausführen. Wenn abgelaufen prüfen ob delegate belegt und wenn ja, ausführen
    }
}

public class CountDownTimerDisplay
{
    CountDownClock.TimesUpEventHandler myHandler;

    public CountDownTimerDisplay(CountDownClock cdc)
    {
        //TODO:
        // 1. EventHandler in CountDownClock Instanz setzen
        // 2. TimeExpired Methode an das Event binden
    }

    public void TimeExpired(object theClock, string message)
    {
        //TODO: Alarmmeldung ausgeben
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Das Rennen wird gestartet ...");

        IRemoteControlCar experimentalCar = new ExperimentalRemoteControlCar();
        IRemoteControlCar productionCar = new ProductionRemoteControlCar();


        TestTrack.Race(experimentalCar);
        TestTrack.Race(productionCar);
        TestTrack.Race(experimentalCar);

        Console.WriteLine($"Versuchsfahrzeug: {experimentalCar.DistanceTravelled}m");
        Console.WriteLine($"Serienfahrzeug: {productionCar.DistanceTravelled}m");

        Console.WriteLine("Rennen beendet ...");

        Console.ReadKey();
    }
}


public interface IRemoteControlCar
{
    public int DistanceTravelled { get; }
    public void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }
    public void Drive()
    {
        DistanceTravelled += 10;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }
    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car) => car.Drive();
}
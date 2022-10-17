class Program
{
    static void Main(string[] args)
    {
        var car = RemoteControlCar.Buy();
        car.BatteryDisplay();
        car.DistanceDisplay();

        car.Drive();
        car.Drive();
        car.Drive();

        car.BatteryDisplay();
        car.DistanceDisplay();

        Console.ReadKey();
    }
}

class RemoteControlCar
{
    private static readonly int _startingDistance = 0;
    private static readonly int _startingBattery = 100;
    private static readonly int _distancePerDrive = 20;
    private static readonly int _batteryPerDrive = 1;

    private int _distanceDriven = _startingDistance;
    private int _batteryRemaining = _startingBattery;

    public RemoteControlCar()
    {
        _batteryRemaining = _startingBattery;
        _distanceDriven = _startingDistance;
    }

    public static RemoteControlCar Buy() => new();

    public void DistanceDisplay() => Console.WriteLine($"Driven {_distanceDriven} meters");

    public void BatteryDisplay()
    {
        if (_batteryRemaining > 0)
            Console.WriteLine($"Battery at {_batteryRemaining}%");
        else
            Console.WriteLine("Battery empty");
    }

    public void Drive()
    {
        if (_batteryRemaining > 0)
        {
            _distanceDriven += _distancePerDrive;
            _batteryRemaining -= _batteryPerDrive;
        }
    }
}

using System;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();
            weatherStation.AcceptReading(new Reading(20.2m, 300, 20, WindDirection.Westerly));

            Console.WriteLine(weatherStation.LatestTemperature);

            Console.ReadKey();
        }

    }

    public class WeatherStation
    {
        private Reading reading;
        private List<DateTime> recordDates = new List<DateTime>();
        private List<decimal> temperatures = new List<decimal>();
        public void AcceptReading(Reading reading)
        {
            this.reading = reading;
            recordDates.Add(DateTime.Now);
            temperatures.Add(reading.Temperature);
        }
        public void ClearAll()
        {
            this.reading = new Reading();
            recordDates.Clear();
            temperatures.Clear();
        }
        public decimal LatestTemperature { get => reading.Temperature; }
        public decimal LatestPressure { get => reading.Pressure; }
        public decimal LatestRainfall { get => reading.Rainfall; }
        public bool HasHistory { get => recordDates.Count > 1; }
        public Outlook ShortTermOutlook
        {
            get => reading.Temperature switch
            {
                _ when reading.Equals(new Reading()) => throw new ArgumentException(),
                < 30m when reading.Pressure < 10m => Outlook.Cool,
                > 50 => Outlook.Good,
                _ => Outlook.Warm
            };
        }
        public Outlook LongTermOutlook
        {
            get => reading.WindDirection switch
            {
                WindDirection.Southerly => Outlook.Good,
                WindDirection.Northerly => Outlook.Cool,
                WindDirection.Easterly when reading.Temperature > 20 => Outlook.Good,
                WindDirection.Easterly => Outlook.Warm,
                WindDirection.Westerly => Outlook.Rainy,
                _ => throw new ArgumentException()
            };
        }
        public State RunSelfTest() => reading.Equals(new Reading()) ? State.Bad : State.Good;
    }

    /*** Please do not modify this struct ***/
    public struct Reading
    {
        public decimal Temperature { get; }
        public decimal Pressure { get; }
        public decimal Rainfall { get; }
        public WindDirection WindDirection { get; }

        public Reading(decimal temperature, decimal pressure,
            decimal rainfall, WindDirection windDirection)
        {
            Temperature = temperature;
            Pressure = pressure;
            Rainfall = rainfall;
            WindDirection = windDirection;
        }
    }

    /*** Please do not modify this enum ***/
    public enum State
    {
        Good,
        Bad
    }

    /*** Please do not modify this enum ***/
    public enum Outlook
    {
        Cool,
        Rainy,
        Warm,
        Good
    }

    /*** Please do not modify this enum ***/
    public enum WindDirection
    {
        Unknown, // default
        Northerly,
        Easterly,
        Southerly,
        Westerly
    }
}
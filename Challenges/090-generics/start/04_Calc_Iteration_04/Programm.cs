using System;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            string ersteZahlAlsString = HoleBenutzerEingabe("Bitte gib die erste Zahl ein: ");
            string zweiteZahlAlsString = HoleBenutzerEingabe("Bitte gib die zweite Zahl ein: ");
            string operation = HoleBenutzerEingabe("Bitte gib die auszuführende Operation ein (+, -, /, *): ");

            double ersteZahl = Convert.ToDouble(ersteZahlAlsString);
            double zweiteZahl = Convert.ToDouble(zweiteZahlAlsString);

            Berechnung(ersteZahl, zweiteZahl, operation);

            HoleBenutzerEingabe("Zum beenden bitte Return drücken!");
        }

        static string HoleBenutzerEingabe(string ausgabeText)
        {
            Console.Write(ausgabeText);
            return Console.ReadLine();
        }

        static void Berechnung(double ersteZahl, double zweiteZahl, string operation)
        {
            string result;
            switch (operation)
            {
                case "+":
                    result = new Addition(ersteZahl, zweiteZahl).Result();
                    break;

                case "-":
                    result = new Substraktion(ersteZahl, zweiteZahl).Result();
                    break;

                case "/":
                    result = new Division(ersteZahl, zweiteZahl).Result();
                    break;

                case "*":
                    result = new Multiplikation(ersteZahl, zweiteZahl).Result();
                    break;

                default:
                    result = "Unbekannter Operator";
                    break;
            }

            Console.WriteLine(result);
        }
    }

    public abstract class CalculateOperation
    {
        protected readonly double x;
        protected readonly double y;

        public abstract string Operation { get; }

        public CalculateOperation(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        protected abstract double Execute();

        public string Result() => $"{Operation} von ${x} und ${y} ergibt ${Execute()}";
    }

    public class Addition : CalculateOperation
    {
        public override string Operation => "Addition";

        public Addition(double x, double y) : base(x, y) { }

        protected override double Execute()
        {
            return x + y;
        }
    }

    public class Substraktion : CalculateOperation
    {
        public override string Operation => "Substraktion";

        public Substraktion(double x, double y) : base(x, y) { }

        protected override double Execute()
        {
            return base.x - base.y;
        }
    }


    public class Division : CalculateOperation
    {
        public override string Operation => "Division";

        public Division(double x, double y) : base(x, y) { }

        protected override double Execute()
        {
            return base.x / base.y;
        }
    }


    public class Multiplikation : CalculateOperation
    {
        public override string Operation => "Multiplikation";

        public Multiplikation(double x, double y) : base(x, y) { }

        protected override double Execute()
        {
            return base.x * base.y;
        }
    }
}
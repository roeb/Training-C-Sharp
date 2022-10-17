using System;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            string ersteZahlAlsString = HoleBenutzerEingabe("Bitte gib die erste Zahl ein: ");
            string zweiteZahlAlsString = HoleBenutzerEingabe("Bitte gib die zweite Zahl ein: ");
            string operationValue = HoleBenutzerEingabe("Bitte gib die auszuführende Operation ein (+, -, /, *): ");

            try
            {
                Operation operation = (Operation)(Convert.ToChar(operationValue));
                double ersteZahl = Convert.ToDouble(ersteZahlAlsString);
                double zweiteZahl = Convert.ToDouble(zweiteZahlAlsString);

                string result = Calculator.Execute(operation, ersteZahl, zweiteZahl).Result();

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Leider ist ein Fehler aufgetreten: {ex.Message}");
            }

            HoleBenutzerEingabe("Zum beenden bitte Return drücken!");
        }

        static string HoleBenutzerEingabe(string ausgabeText)
        {
            Console.Write(ausgabeText);
            return Console.ReadLine();
        }
    }

    public enum Operation
    {
        Unknown,
        Addition = '+',
        Substraktion = '-',
        Division = '\\',
        Multiplikation = '*'
    }

    public static class Calculator
    {
        public static CalculateOperation Execute(Operation operation, double x, double y)
        {
            switch (operation)
            {
                case Operation.Addition:
                    return new Addition(x, y);

                case Operation.Substraktion:
                    return new Substraktion(x, y);

                case Operation.Division:
                    return new Division(x, y);

                case Operation.Multiplikation:
                    return new Multiplikation(x, y);

                default:
                    throw new NotSupportedException($"Der Operator {operation} wird nicht unterstützt.");
            }
        }
    }

    public abstract class CalculateOperation
    {
        protected readonly double x;
        protected readonly double y;

        public abstract Operation Operation { get; }

        public CalculateOperation(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        protected abstract double Execute();

        public string Result() => $"{Operation} von {x} und {y} ergibt {Execute()}";
    }

    public class Addition : CalculateOperation
    {
        public override Operation Operation => Operation.Addition;


        public Addition(double x, double y) : base(x, y) { }

        protected override double Execute()
        {
            return base.x + base.y; ;
        }
    }

    public class Substraktion : CalculateOperation
    {
        public override Operation Operation => Operation.Substraktion;

        public Substraktion(double x, double y) : base(x, y) { }

        protected override double Execute()
        {
            return base.x - base.y;
        }
    }


    public class Division : CalculateOperation
    {
        public override Operation Operation => Operation.Division;

        public Division(double x, double y) : base(x, y) { }

        protected override double Execute()
        {
            return base.x / base.y;
        }
    }


    public class Multiplikation : CalculateOperation
    {
        public override Operation Operation => Operation.Multiplikation;

        public Multiplikation(double x, double y) : base(x, y) { }

        protected override double Execute()
        {
            return base.x * base.y;
        }
    }
}
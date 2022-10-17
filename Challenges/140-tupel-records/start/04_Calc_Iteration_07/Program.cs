using System;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            CalculatorOption option = CalculatorOption.NextOperation;
            while (option != CalculatorOption.Exit)
            {
                option = NewOperation(calculator);
            }

            HoleBenutzerEingabe("Zum beenden bitte Return drücken!");
        }

        static CalculatorOption NewOperation(Calculator calculator)
        {
            double operand1 = calculator.Value;
            double operand2 = 0;

            try
            {
                if (operand1 == 0)
                {
                    string ersteZahlAlsString = HoleBenutzerEingabe("Bitte gib den ersten Operanden ein: ");
                    string zweiteZahlAlsString = HoleBenutzerEingabe("Bitte gib den zweite Operanden ein: ");

                    operand1 = Convert.ToDouble(ersteZahlAlsString);
                    operand2 = Convert.ToDouble(zweiteZahlAlsString);

                }
                else
                {
                    Console.WriteLine($"Der aktuelle Wert ist: {calculator.Value}");
                    string zweiteZahlAlsString = HoleBenutzerEingabe("Bitte gib den Operanden ein: ");

                    operand2 = Convert.ToDouble(zweiteZahlAlsString);
                }

                string operationValue = HoleBenutzerEingabe("Bitte gib die auszuführende Operation ein (+, -, /, *): ");
                Operation operation = (Operation)(Convert.ToChar(operationValue));


                string result = calculator.Execute(operation, operand1, operand2).Result();
                Console.WriteLine(result);

                Console.WriteLine("\n Du hast folgende Möglichkeiten:");
                Console.WriteLine("1) Eine weitere Rechenoperation durchführen");
                Console.WriteLine("2) Das Programm beenden\n");
                var option = int.Parse(HoleBenutzerEingabe("Bitte gibt eine Option an: "));

                return (CalculatorOption)option;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Leider ist ein Fehler aufgetreten: {ex.Message}");
                return CalculatorOption.Exit;
            }
        }

        static string HoleBenutzerEingabe(string ausgabeText)
        {
            Console.Write(ausgabeText);
            return Console.ReadLine();
        }
    }

    public enum CalculatorOption
    {
        NextOperation = 1,
        Exit = 2
    }

    public enum Operation
    {
        Unknown,
        Addition = '+',
        Substraktion = '-',
        Division = '\\',
        Multiplikation = '*'
    }

    public class CalculatorHistory
    {
        public Operation Operation { get; set; }

        public double Operand1 { get; set; }

        public double Operand2 { get; set; }

        public double Result { get; set; }
    }

    public class Calculator
    {
        public List<CalculatorHistory> History { get; private set; }
        public double Value => History.Count == 0 ? 0 : History.Last().Result;

        public Calculator()
        {
            History = new List<CalculatorHistory>();
        }

        public CalculateOperation Execute(Operation operation, double x, double y)
        {
            CalculateOperation calculateOperation;

            switch (operation)
            {
                case Operation.Addition:
                    calculateOperation = new Addition(x, y);
                    break;

                case Operation.Substraktion:
                    calculateOperation = new Substraktion(x, y);
                    break;

                case Operation.Division:
                    calculateOperation = new Division(x, y);
                    break;

                case Operation.Multiplikation:
                    calculateOperation = new Multiplikation(x, y);
                    break;

                default:
                    throw new NotSupportedException($"Der Operator {operation} wird nicht unterstützt.");
            }

            History.Add(calculateOperation.CreateHistory());

            return calculateOperation;
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

        public CalculatorHistory CreateHistory() => new CalculatorHistory()
        {
            Operation = Operation,
            Operand1 = x,
            Operand2 = y,
            Result = Execute()
        };
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
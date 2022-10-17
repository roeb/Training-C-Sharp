using System;
using System.Collections.Generic;
using System.Linq;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            var option = CalculatorOption.NextOperation;
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
                    var ersteZahlAlsString = HoleBenutzerEingabe("Bitte gib den ersten Operanden ein: ");
                    var zweiteZahlAlsString = HoleBenutzerEingabe("Bitte gib den zweite Operanden ein: ");

                    operand1 = Convert.ToDouble(ersteZahlAlsString);
                    operand2 = Convert.ToDouble(zweiteZahlAlsString);

                }
                else
                {
                    Console.WriteLine($"Der aktuelle Wert ist: {calculator.Value}");
                    var zweiteZahlAlsString = HoleBenutzerEingabe("Bitte gib den Operanden ein: ");

                    operand2 = Convert.ToDouble(zweiteZahlAlsString);
                }

                var operationValue = HoleBenutzerEingabe("Bitte gib die auszuführende Operation ein (+, -, /, *): ");
                Operation operation = (Operation)(Convert.ToChar(operationValue));


                var result = calculator.Execute(operation, operand1, operand2).Result();
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

    public record CalculatorHistory(Operation Operation, double Operand1, double Operand2, double Result);

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
            var operands = (x, y);

            switch (operation)
            {
                case Operation.Addition:
                    calculateOperation = new Addition(operands);
                    break;

                case Operation.Substraktion:
                    calculateOperation = new Substraktion(operands);
                    break;

                case Operation.Division:
                    calculateOperation = new Division(operands);
                    break;

                case Operation.Multiplikation:
                    calculateOperation = new Multiplikation(operands);
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

        public CalculateOperation((double x, double y) operands)
        {
            this.x = operands.x;
            this.y = operands.y;
        }

        protected abstract double Execute();

        public string Result() => $"{Operation} von {x} und {y} ergibt {Execute()}";

        public CalculatorHistory CreateHistory() => new CalculatorHistory(Operation, x, y, Execute());
    }

    public class Addition : CalculateOperation
    {
        public override Operation Operation => Operation.Addition;


        public Addition((double x, double y) operands) : base(operands) { }

        protected override double Execute()
        {
            return base.x + base.y; ;
        }
    }

    public class Substraktion : CalculateOperation
    {
        public override Operation Operation => Operation.Substraktion;

        public Substraktion((double x, double y) operands) : base(operands) { }

        protected override double Execute()
        {
            return base.x - base.y;
        }
    }


    public class Division : CalculateOperation
    {
        public override Operation Operation => Operation.Division;

        public Division((double x, double y) operands) : base(operands) { }

        protected override double Execute()
        {
            return base.x / base.y;
        }
    }


    public class Multiplikation : CalculateOperation
    {
        public override Operation Operation => Operation.Multiplikation;

        public Multiplikation((double x, double y) operands) : base(operands) { }

        protected override double Execute()
        {
            return base.x * base.y;
        }
    }
}
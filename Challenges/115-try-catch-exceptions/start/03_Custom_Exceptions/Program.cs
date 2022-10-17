using System;

class Program
{
    static void Main(string[] args)
    {
        var calc = new Calculator();
        new CalculatorTestHarness(calc).TestMultiplication(20, 2);

        Console.ReadKey();
    }
}

public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner)
    // TODO: complete the definition of the constructor
    {
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        throw new NotImplementedException("Please implement the CalculatorTestHarness.TestMultiplication() method");
    }

    public void Multiply(int x, int y)
    {
        throw new NotImplementedException("Please implement the CalculatorTestHarness.Multiply() method");
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
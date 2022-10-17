using System;
using System.Text;

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
    public CalculationException(int operand1, int operand2, string message, Exception inner) : base(message, inner)
    {
        Operand1 = operand1;
        Operand2 = operand2;
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
        StringBuilder ret = new("Multiply succeeded");
        try
        {
            Multiply(x, y);
        }
        catch (CalculationException ex)
        {
            ret.Clear();
            if (x < 0 && y < 0)
            {
                ret.Append("Multiply failed for negative operands. ");
            }
            else
            {
                ret.Append("Multiply failed for mixed or positive operands. ");
            }
            ret.Append(ex.Message);
        }
        return ret.ToString();
    }

    public void Multiply(int x, int y)
    {
        try
        {
            calculator.Multiply(x, y);
        }
        catch (OverflowException ex)
        {
            throw new CalculationException(x, y, ex.Message, ex);
        }
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

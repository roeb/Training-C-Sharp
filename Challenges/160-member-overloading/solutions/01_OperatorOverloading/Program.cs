using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {

        Console.ReadKey();
    }
}


public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    private static bool CurrencyOperation(CurrencyAmount a, CurrencyAmount b, bool operation)
    {
        if (a.currency == b.currency)
            return operation;
        else
            throw new ArgumentException();
    }

    private static decimal CurrencyOperation(CurrencyAmount a, CurrencyAmount b, decimal operation)
    {
        if (a.currency == b.currency)
            return operation;
        else
            throw new ArgumentException();
    }

    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
        => CurrencyOperation(a, b, a.amount == b.amount);
    public static bool operator !=(CurrencyAmount a, CurrencyAmount b)
        => CurrencyOperation(a, b, a.amount != b.amount);
    public override bool Equals(object obj) => this == (CurrencyAmount)obj;
    public override int GetHashCode() => base.GetHashCode();
    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
        => CurrencyOperation(a, b, a.amount > b.amount);
    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
        => CurrencyOperation(a, b, a.amount < b.amount);
    public static decimal operator +(CurrencyAmount a, CurrencyAmount b)
        => CurrencyOperation(a, b, a.amount + b.amount);
    public static decimal operator -(CurrencyAmount a, CurrencyAmount b)
        => CurrencyOperation(a, b, a.amount - b.amount);
    public static decimal operator *(CurrencyAmount a, decimal b)
        => a.amount * b;
    public static decimal operator /(CurrencyAmount a, decimal b)
        => a.amount / b;
    public static explicit operator double(CurrencyAmount a) => (double)a.amount;
    public static implicit operator decimal(CurrencyAmount a) => a.amount;
}
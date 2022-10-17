class Program
{
    static void Main(string[] args)
    {
        var rectangle = new Descriper<string>("4", "Anzahl Ecken eines Rechtecks");

        Console.WriteLine(rectangle.ToString());
        Console.WriteLine(rectangle.GetValueType());

        Console.ReadKey();
    }
}


public class Descriper<T>
{
    private T _value;
    private string _description;

    public Descriper(T value, string description)
    {
        this._value = value;
        this._description = description;
    }

    public override string ToString()
    {
        return $"{_description}: {_value}";
    }

    public string GetValueType()
    {
        return typeof(T).ToString();
    }
}
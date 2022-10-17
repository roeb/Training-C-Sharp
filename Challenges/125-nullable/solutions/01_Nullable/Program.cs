class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Badge.Print(734, "Ernest Johnny Payne", "Strategic Communication"));
        Console.WriteLine(Badge.Print(id: null, "Jane Johnson", "Procurement"));
        Console.WriteLine(Badge.Print(254, "Charlotte Hale", department: null));
        Console.WriteLine(Badge.Print(id: null, "Charlotte Hale", department: null));

        Console.ReadKey();
    }
}

static class Badge
{
    private const string DefaultDerpartment = "owner";
    public static string Print(int? id, string name, string? department)
    {
        department = (department ?? DefaultDerpartment).ToUpper();
        return id.HasValue switch
        {
            true => $"[{id}] - {name} - {department}",
            false => $"{name} - {department}",
        };
    }
}
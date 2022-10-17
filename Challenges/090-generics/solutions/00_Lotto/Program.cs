class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starte Ziehung 5 aus 35 ...");

        var lotto35 = new Lotto5Aus35();
        for (int i = 1; i <= lotto35.GetAnzahl(); i++)
        {
            int zahl = lotto35.GetLottoZahl(35);
            Console.WriteLine($"Ziehung {i}: {zahl}");
        }

        Console.WriteLine("Ziehung beendet!");


        Console.WriteLine("Starte Ziehung 6 aus 49 ...");

        var lotto49 = new Lotto6Aus49();
        for (int i = 1; i <= lotto49.GetAnzahl(); i++)
        {
            int zahl = lotto49.GetLottoZahl(49);
            Console.WriteLine($"Ziehung {i}: {zahl}");
        }

        Console.WriteLine("Ziehung beendet!");


        Console.ReadKey();
    }
}

public interface ILotto
{
    int GetLottoZahl(int maxZahl);

    int GetAnzahl();
}

public abstract class Lotto : ILotto
{
    public abstract int GetAnzahl();

    public int GetLottoZahl(int maxZahl)
    {
        Random rd = new Random();
        return rd.Next(maxZahl) + 1;
    }
}

public class Lotto5Aus35 : Lotto
{
    public override int GetAnzahl()
    {
        return 5;
    }
}

public class Lotto6Aus49 : Lotto
{
    public override int GetAnzahl()
    {
        return 6;
    }
}
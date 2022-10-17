class Program
{
    static void Main(string[] args)
    {
        var zeitLang = new ZeitLang();
        var zeitKurz = new ZeitKurz(new DateTime(2012, 11, 28));

        Console.WriteLine(zeitLang.ZeitAnzeige());
        Console.WriteLine(zeitKurz.ZeitAnzeige());

        Console.ReadKey();
    }
}


public abstract class Zeit
{
    protected readonly DateTime time;

    public Zeit() => this.time = DateTime.Now;

    public Zeit(DateTime time) => this.time = time;

    public abstract string ZeitAnzeige();
}

public class ZeitKurz : Zeit
{
    public ZeitKurz() : base() { }
    public ZeitKurz(DateTime time) : base(time) { }

    public override string ZeitAnzeige()
    {
        return base.time.ToShortTimeString();
    }
}

public class ZeitLang : Zeit
{
    public ZeitLang() : base() { }
    public ZeitLang(DateTime time) : base(time) { }

    public override string ZeitAnzeige()
    {
        return base.time.ToLongTimeString();
    }
}
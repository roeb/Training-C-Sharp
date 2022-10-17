using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Product product = new Product()
        {
            Name = "Sneakers",
            StockAmount = 10,
            Status = ProductStatus.InStock
        };

        //TODO:
        // 1. EventHandler an das ProductSold Event binden und implementieren
        // 2. Sell beliebig oft ausführen, bis der Bestand erschöpft ist.

        Console.ReadKey();
    }

    static void ProductSold(Product product, int amount)
    {
        // TODO:
        // 1. Prüfen ob der Status Ordered ist und dann eine entsprechende Meldung ausgeben
        // 2. Wenn der Status InStock und die Anzahl im Lager ausreichend ist, findet der Verkauf statt. 
        //      Die Anzahl im wird aktualisiert und es erfolgt eine Nachricht
        // 3. Wenn der Bestand nicht ausreicht, gibt es eine Meldung und der Status wird auf Ordered gestellt.
    }
}

public class Product
{
    public string Name { get; set; }
    public int StockAmount { get; set; }
    public ProductStatus Status { get; set; }

    // TODO: EventHandler und Delegate implementieren
    // Der Delegate bekommt die bestellte Menge aus der Sell Methode und das aktuelle Product übergeben.

    public void Sell(int amount)
    {
        // TODO: EventHandler aufrufen
    }
}

public enum ProductStatus
{
    InStock,
    Ordered
}
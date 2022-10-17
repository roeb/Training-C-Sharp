using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Product product = new Product()
        {
            Name = "Sneakers",
            StockAmount = 5,
            Status = ProductStatus.InStock
        };

        product.ProductSold += new Product.ProductSoldEventHandler(ProductSold);

        product.Sell(3);
        product.Sell(3);

        Console.ReadKey();
    }

    static void ProductSold(Product product, int amount)
    {
        if (product.Status == ProductStatus.Ordered)
        {
            Console.WriteLine($"Das Produkt '{product.Name}' ist moment nicht im Lager und wurde bestellt.");
        }
        else if (product.StockAmount >= amount)
        {
            product.StockAmount -= amount;
            Console.WriteLine($"Product '{product.Name}' wurde {amount} mal verkauft. Der aktuell Bestand ist nun {product.StockAmount}");
        }
        else
        {
            Console.WriteLine($"Der Bestand ist zu gering. Es werden {amount - product.StockAmount} neue Produkte bestellt.");
            product.Status = ProductStatus.Ordered;
        }
    }
}

public class Product
{
    public string Name { get; set; }
    public int StockAmount { get; set; }
    public ProductStatus Status { get; set; }

    public delegate void ProductSoldEventHandler(Product product, int amount);
    public event ProductSoldEventHandler ProductSold;

    public void Sell(int amount)
    {
        ProductSold?.Invoke(this, amount);
    }
}

public enum ProductStatus
{
    InStock,
    Ordered
}
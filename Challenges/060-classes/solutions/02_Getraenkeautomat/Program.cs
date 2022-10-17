class Program
{
    private static string[] drinks = new string[]
       {
            "Wasser (0,50 Euro)",
            "Cola (1,00 Euro)",
            "Bier (2,00 Euro)",
       };

    static void Main(string[] args)
    {

        int drinkNumer = SelectDrink();
        int amountOfDrinks = SelectAmount();
        double price = GetPrice(drinkNumer, amountOfDrinks);

        ExecutePayment(price);

        Console.ReadKey();
    }

    private static int SelectDrink()
    {
        Console.WriteLine("Wählen sie ihr Getränk aus:");
        for (int i = 1; i <= drinks.Length; i++)
        {
            Console.WriteLine($"{i}) {drinks[i - 1]}");
        }

        Console.WriteLine("Geben sie die Nummer des Getränks ein: ");
        var drinkNumber = int.Parse(Console.ReadLine());

        return drinkNumber;
    }

    private static int SelectAmount()
    {
        Console.WriteLine("Geben sie die gwünschte Menge ein: ");
        var amountOfDrinks = int.Parse(Console.ReadLine());

        if (amountOfDrinks == 0)
            Console.WriteLine("Es muss mindestens 1 Getränk gewählt werden.");

        return amountOfDrinks;
    }

    private static double GetPrice(int drinkNumber, int amount)
    {
        double drinkPrice = drinkNumber switch
        {
            1 => 0.5,
            2 => 1.0,
            3 => 2.0,
            _ => 0
        };

        if (drinkPrice == 0)
        {
            Console.WriteLine("Für ihre Auswahl konnte kein Getränk ermittelt werden.");
            return 0;
        }

        return drinkPrice * amount;
    }

    private static void ExecutePayment(double price)
    {
        if (price == 0)
            return;

        double insertedMoney = 0;
        double missingMoney = price - insertedMoney;
        while (insertedMoney < price)
        {
            if (insertedMoney == 0)
                Console.WriteLine($"Bitte werfen sie {missingMoney} Euro ein: ");

            var money = Convert.ToDouble(Console.ReadLine());
            if (!IsInsertedMoneyValid(money))
            {
                Console.WriteLine($"{money} Euro Stück ist ungültig.");
                continue;
            }

            insertedMoney += money;
            missingMoney = price - insertedMoney;

            if (insertedMoney == price)
                Console.WriteLine("Vielen Dank!. Bitte entnehmen sie ihr Getränk.");
            else if (insertedMoney < price)
                Console.WriteLine($"Das eingeworfene Betrag ist zu gering. Es fehlen noch {missingMoney} Euro");
            else if (insertedMoney > price)
                Console.WriteLine("Der eingeworfene Betrag ist zu hoch. Kein Rückgeld möglich. Bitte entnehmen Sie ihr Getränk");
        }
    }

    private static bool IsInsertedMoneyValid(double money)
    {
        var validCoins = new double[]
        {
            0.05,
            0.10,
            0.20,
            0.50,
            1.00,
            2.00
        };

        foreach (var coin in validCoins)
        {
            if (money == coin)
                return true;
        }

        return false;
    }
}
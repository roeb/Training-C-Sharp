class Program
{
    static void Main(string[] args)
    {
        var drinks = new string[]
        {
            "Wasser (0,50 Euro)",
            "Cola (1,00 Euro)",
            "Bier (2,00 Euro)",
        };

        Console.WriteLine("Wählen sie ihr Getränk aus:");
        for (int i = 0; i < drinks.Length; i++)
        {
            Console.WriteLine($"{i}) {drinks[i]}");
        }

        Console.WriteLine("Geben sie die Nummer des Getränks ein: ");
        var drinkNumber = int.Parse(Console.ReadLine());
        double drinkPrice = drinkNumber switch
        {
            1 => 0.5,
            2 => 1.0,
            3 => 2.0,
            _ => 0
        };

        if (drinkPrice == 0)
            Console.WriteLine("Für ihre Auswahl konnte kein Getränk ermittelt werden.");
        else
        {
            Console.WriteLine($"Bitte werfen sie {drinkPrice} Euro ein: ");
            var money = Convert.ToDouble(Console.ReadLine());

            if (money == drinkPrice)
                Console.WriteLine("Vielen Dank!. Bitte entnehmen sie ihr Getränk.");
            else if (money < drinkPrice)
                Console.WriteLine("Das eingeworfene Betrag ist zu gering.");
            else if (money > drinkPrice)
                Console.WriteLine("Der eingeworfene Betrag ist zu hoch. Kein Rückgeld möglich. Bitte entnehmen Sie ihr Getränk");

        }

        Console.ReadKey();
    }
}
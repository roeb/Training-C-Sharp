namespace _02_Calc_Iteration_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bitte gib den ersten Summanden ein: ");
            string ersterSummand = Console.ReadLine();
            Console.Write("Bitte gib den zweiten Summanden ein: ");
            string zweiterSummand = Console.ReadLine();

            double ersterSummandAlsZahl = Convert.ToDouble(ersterSummand);
            double zweiterSummandAlsZahl = Convert.ToDouble(zweiterSummand);

            double summe = ersterSummandAlsZahl + zweiterSummandAlsZahl;

            Console.WriteLine("Die Summe ist: {0}", summe);
            Console.ReadLine();
        }
    }
}
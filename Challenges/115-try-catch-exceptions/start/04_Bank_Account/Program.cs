class Program
{
    static void Main(string[] args)
    {
        var account = new BankAccount();
        account.Open();

        account.UpdateBalance(20);
        account.UpdateBalance(-10);
        account.UpdateBalance(5);

        Console.WriteLine(account.Balance);

        account.Close();

        Console.ReadKey();
    }
}

public class BankAccount
{
    public void Open()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public void Close()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public decimal Balance
    {
        get
        {
            throw new NotImplementedException("You need to implement this property.");
        }
    }

    public void UpdateBalance(decimal change)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
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
    private readonly object _lock = new object();
    private decimal _balance;
    private bool _isOpen;

    public void Open() => _isOpen = true;

    public void Close() => _isOpen = false;

    public decimal Balance => _isOpen ? _balance : throw new InvalidOperationException();

    public void UpdateBalance(decimal change)
    {
        if (!_isOpen)
            throw new InvalidOperationException("Cannot update balance on an account that isn't open");
        lock (_lock)
            _balance += change;
    }
}
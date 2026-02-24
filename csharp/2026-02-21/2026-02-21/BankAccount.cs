namespace _2026_02_21;

public class BankAccount
{
    private long balance;
    
    public long Balance
    {
        get { return balance; }
    }

    public BankAccount(long balance)
    {
        this.balance = balance;
    }

    public long deposit(long amount)
    {
        amount = Math.Abs(amount);
        balance += amount;
        validation(balance);
        return balance;
    }

    public long withdraw(long amount)
    {
        amount = Math.Abs(amount);
        balance -= amount;
        validation(balance);
        return balance;
    }

    private void validation(long amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be negative");
    }
}
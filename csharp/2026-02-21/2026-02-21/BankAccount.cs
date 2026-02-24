namespace _2026_02_21;

public class BankAccount
{
    long Balance { get; set; } //private

    public BankAccount(long balance)
    {
        Balance = balance;
    }

    public long deposit(long amount)
    {
        amount = Math.Abs(amount);
        Balance += amount;
        validation(Balance);
        return Balance;
    }

    public long withdraw(long amount)
    {
        amount = Math.Abs(amount);
        Balance -= amount;
        validation(Balance);
        return Balance;
    }

    private void validation(long amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be negative");
    }
}
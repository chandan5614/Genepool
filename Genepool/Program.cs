using Genepool.src.OOP.Encapsulation;

class Program
{
    static void Main(String[] args)
    {
        BadEncapsulation();
        Encapsulation();
    }

    private static void BadEncapsulation()
    {
        // BadEncapsulation allows direct modification of the balance
        BadBankAccount badBankAccount = new BadBankAccount();
        badBankAccount.balance = -1;
        Console.WriteLine($"Balance: {badBankAccount.balance}");
    }

    private static void Encapsulation()
    {
        BankAccount bankAccount = new BankAccount(100);
        bankAccount.Deposit(100);
        bankAccount.Withdraw(150);
        bankAccount.GetBalance();
    }
}
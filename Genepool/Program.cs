using Genepool.src.OOP.Abstraction;
using Genepool.src.OOP.Encapsulation;
using Genepool.src.OOP.Inheritance;

class Program
{
    static void Main(String[] args)
    {
        Inheritance();
    }

    private static void NoEncapsulation()
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

    private static void NoAbstraction()
    {
        BadEmailService badEmailService= new BadEmailService();
        badEmailService.Connect();
        badEmailService.Authenticate();
        badEmailService.SendEmail();
        badEmailService.Disconnect();
    }

    private static void Abstraction()
    {
        EmailService emailService= new EmailService();
        emailService.SendEmail();
    }

    private static void Inheritance()
    {
        // Creating an instance of Car, which inherits from Vehicle
        Car car = new Car
        {
            Brand = "Toyota",
            Model = "Corolla",
            Year = 2020,
            NumberOfDoors = 4,
            NumberOfWheels = 4
        };

        // Using inherited methods from Vehicle class
        Console.WriteLine($"Car: {car.Brand} {car.Model} ({car.Year})");
        car.Start();  // Inherited from Vehicle
        Console.WriteLine($"Number of Doors: {car.NumberOfDoors}");
        Console.WriteLine($"Number of Wheels: {car.NumberOfWheels}");
        car.Stop();   // Inherited from Vehicle

        Console.WriteLine();

        // Creating an instance of Bike, which inherits from Vehicle
        Bike bike = new Bike
        {
            Brand = "Yamaha",
            Model = "MT-09",
            Year = 2021,
            NumberOfWheels = 2
        };

        // Using inherited methods from Vehicle class
        Console.WriteLine($"Bike: {bike.Brand} {bike.Model} ({bike.Year})");
        bike.Start();  // Inherited from Vehicle
        Console.WriteLine($"Number of Wheels: {bike.NumberOfWheels}");
        bike.Stop();   // Inherited from Vehicle
    }
}
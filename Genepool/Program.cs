﻿using Genepool.src.OOP.Abstraction;
using Genepool.src.OOP.Composition;
using Genepool.src.OOP.Coupling.Bad;
using Genepool.src.OOP.Coupling.Good;
using Genepool.src.OOP.Encapsulation;

class Program
{
    static void Main(String[] args)
    {
        Composition();
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
        BadEmailService badEmailService = new BadEmailService();
        badEmailService.Connect();
        badEmailService.Authenticate();
        badEmailService.SendEmail();
        badEmailService.Disconnect();
    }

    private static void Abstraction()
    {
        EmailService emailService = new EmailService();
        emailService.SendEmail();
    }

    private static void Inheritance()
    {
        // Creating an instance of Car, which inherits from Vehicle
        Genepool.src.OOP.Inheritance.Good.Car car = new Genepool.src.OOP.Inheritance.Good.Car
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
        Genepool.src.OOP.Inheritance.Good.Bike bike = new Genepool.src.OOP.Inheritance.Good.Bike
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

    private static void NoPolymorphism()
    {
        // Create a list of objects without polymorphism
        List<Object> vehicles = new List<Object>
    {
        new Genepool.src.OOP.Polymorphism.Bad.Car { Brand = "Toyota", Model = "Camry", Year = 2020, NumberOfDoors = 4 },
        new Genepool.src.OOP.Polymorphism.Bad.Bike { Brand = "Harley-Davidson", Model = "Sportster", Year = 2021 }
    };

        // Perform a general inspection on each vehicle with type checks
        foreach (var vehicle in vehicles)
        {
            if (vehicle is Genepool.src.OOP.Polymorphism.Bad.Car)
            {
                Genepool.src.OOP.Polymorphism.Bad.Car car = (Genepool.src.OOP.Polymorphism.Bad.Car)vehicle; // Cast to Car
                Console.WriteLine($"Inspecting {car.Brand} {car.Model} ({car.GetType().Name})");
                car.Start();
                car.Stop();
                Console.WriteLine();
            }
            else if (vehicle is Genepool.src.OOP.Polymorphism.Bad.Bike)
            {
                Genepool.src.OOP.Polymorphism.Bad.Bike bike = (Genepool.src.OOP.Polymorphism.Bad.Bike)vehicle; // Cast to Bike
                Console.WriteLine($"Inspecting {bike.Brand} {bike.Model} ({bike.GetType().Name})");
                bike.Start();
                bike.Stop();
                Console.WriteLine();
            }
            else
            {
                throw new Exception("Object is not a valid vehicle");
            }
        }
    }


    private static void Polymorphism()
    {
        // Create a list of vehicles
        List<Genepool.src.OOP.Polymorphism.Good.Vehicle> vehicles = new List<Genepool.src.OOP.Polymorphism.Good.Vehicle>{
            new Genepool.src.OOP.Polymorphism.Good.Car { Brand = "Toyota", Model = "Camry", Year = 2020, NumberOfDoors = 4 },
            new Genepool.src.OOP.Polymorphism.Good.Bike { Brand = "Harley-Davidson", Model = "Sportster", Year = 2021 }
            };

        // Perform a general inspection on each vehicle
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Inspecting {vehicle.Brand} {vehicle.Model} ({vehicle.GetType().Name})");
            vehicle.Start();
            vehicle.Stop();
            Console.WriteLine();
        }
    }

    private static void NoCoupling()
    {
        Genepool.src.OOP.Coupling.Bad.Order order = new Genepool.src.OOP.Coupling.Bad.Order();
        order.PlaceOrder();
    }

    private static void Coupling()
    {
        Genepool.src.OOP.Coupling.Good.EmailSender emailSender = new Genepool.src.OOP.Coupling.Good.EmailSender();
        Genepool.src.OOP.Coupling.Good.Order order = new Genepool.src.OOP.Coupling.Good.Order(emailSender);
        //Genepool.src.OOP.Coupling.Good.Order order= new Genepool.src.OOP.Coupling.Good.Order(new Genepool.src.OOP.Coupling.Good.SMSSender());
        order.PlaceOrder();
    }

    private static void Composition()
    {
        Car car = new Car();
        car.StartCar();
    }
}
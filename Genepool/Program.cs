﻿using System.Reflection;
using Genepool.src.Architectures.OnionArchitecture.Core.Entities;
using Genepool.src.Architectures.OnionArchitecture.Core.Interfaces;
using Genepool.src.Architectures.OnionArchitecture.Infrastructure.Persistence;
using Genepool.src.Architectures.OnionArchitecture.Infrastructure.Persistence.Repositories;
using Genepool.src.Architectures.OnionArchitecture.Presentation.Middleware;
using Genepool.src.OOP.Abstraction;
using Genepool.src.OOP.Encapsulation;
using Genepool.src.SOLID.D.Good;
using Genepool.src.SOLID.I.Bad;
using Genepool.src.SOLID.I.Good;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(String[] args)
    {
        var app = CleanArchitectureWebApplication(args);
        app.Run();
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
        Genepool.src.OOP.Composition.Car car = new Genepool.src.OOP.Composition.Car();
        car.StartCar();
    }

    private static void NoSingleResponsibility()
    {
        Genepool.src.SOLID.S.Bad.User user = new Genepool.src.SOLID.S.Bad.User
        {
            UserName = "JaneDoe",
            Email = "janedoe@example.com"
        };
        user.Register();
    }

    private static void SingleResponsibility()
    {
        Genepool.src.SOLID.S.Good.User user = new Genepool.src.SOLID.S.Good.User
        {
            UserName = "JohnDoe",
            Email = "johndoe@example.com"
        };

        Genepool.src.SOLID.S.Good.UserService userService = new Genepool.src.SOLID.S.Good.UserService();
        userService.Register(user);
    }

    private static void NoOpenClosedPrinciple()
    {
        Genepool.src.SOLID.O.Bad.Shape circle = new Genepool.src.SOLID.O.Bad.Shape
        {
            Type = Genepool.src.SOLID.O.Bad.ShapeType.Circle,
            Radius = 5
        };

        Genepool.src.SOLID.O.Bad.Shape rectangle = new Genepool.src.SOLID.O.Bad.Shape
        {
            Type = Genepool.src.SOLID.O.Bad.ShapeType.Rectangle,
            Length = 10,
            Width = 5
        };

        Console.WriteLine($"Circle Area: {circle.CalculateArea()}");
        Console.WriteLine($"Rectangle Area: {rectangle.CalculateArea()}");
    }

    private static void OpenClosedPrinciple()
    {
        Genepool.src.SOLID.O.Good.Shape circle = new Genepool.src.SOLID.O.Good.Circle
        {
            Radius = 5
        };

        Genepool.src.SOLID.O.Good.Shape rectangle = new Genepool.src.SOLID.O.Good.Rectangle
        {
            Length = 10,
            Width = 5
        };

        Console.WriteLine($"Circle Area: {circle.CalculateArea()}");
        Console.WriteLine($"Rectangle Area: {rectangle.CalculateArea()}");
    }

    private static void NoLiskovSubstitutionPrinciple()
    {
        var rect = new Genepool.src.SOLID.L.Bad.Rectangle();
        rect.Height = 10;
        rect.Width = 5;
        Console.WriteLine("Expected area = 10 * 5 = 50.");
        Console.WriteLine("Calculated area = " + rect.Area);

        // Violates LSP when substituting Square for Rectangle
        var square = new Genepool.src.SOLID.L.Bad.Square();
        square.Height = 10;
        square.Width = 5; // Setting width should not affect height, but it does
        Console.WriteLine("Expected area = 10 * 5 = 50.");
        Console.WriteLine("Calculated area = " + square.Area);
    }

    private static void LiskovSubstitutionPrinciple()
    {
        Genepool.src.SOLID.L.Good.Shape rectangle = new Genepool.src.SOLID.L.Good.Rectangle
        {
            Width = 5,
            Height = 4
        };
        Console.WriteLine($"Area of the rectangle: {rectangle.Area}");

        Genepool.src.SOLID.L.Good.Shape square = new Genepool.src.SOLID.L.Good.Square
        {
            SideLength = 5
        };
        Console.WriteLine($"Area of the square: {square.Area}");
    }

    private static void NoInterfaceSegregation()
    {
        IShape circle = new Genepool.src.SOLID.I.Bad.Circle { Radius = 10 };

        Console.WriteLine($"Circle Area: {circle.Area()}");

        try
        {
            Console.WriteLine($"Circle Volume: {circle.Volume()}"); // Will throw InvalidOperationException
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        IShape sphere = new Genepool.src.SOLID.I.Bad.Sphere { Radius = 10 };

        Console.WriteLine($"Sphere Area: {sphere.Area()}");
        Console.WriteLine($"Sphere Volume: {sphere.Volume()}");
    }

    private static void InterfaceSegregation()
    {
        IShape2D circle = new Genepool.src.SOLID.I.Good.Circle { Radius = 10 };

        Console.WriteLine($"Circle Area: {circle.Area()}");

        IShape3D sphere = new Genepool.src.SOLID.I.Good.Sphere { Radius = 10 };

        Console.WriteLine($"Sphere Area: {sphere.Area()}");
        Console.WriteLine($"Sphere Volume: {sphere.Volume()}");
    }

    private static void NoDependencyInversion()
    {
        Genepool.src.SOLID.D.Bad.Car car = new Genepool.src.SOLID.D.Bad.Car();
        car.StartCar();
    }

    private static void DependencyInversion()
    {
        IEngine engine = new Genepool.src.SOLID.D.Good.Engine(); // Concrete implementation to be injected into the car
        Genepool.src.SOLID.D.Good.Car car = new Genepool.src.SOLID.D.Good.Car(engine);
        car.StartCar();
    }

    private static WebApplication OnionArchitectureWebApplication(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        ConfigureOnionArchitectureServices(builder.Services);

        var app = builder.Build();

        // Seed data
        SeedData(app.Services);

        // Use custom middleware for global exception handling
        app.UseMiddleware<GlobalExceptionHandler>();

        app.UseRouting();
        app.MapControllers(); // Maps the attribute-routed controllers

        return app;
    }

    private static void ConfigureOnionArchitectureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("DemoDb")); // Use an in-memory database for demo purposes
        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();

        // Configure JSON options to handle reference cycles
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.MaxDepth = 64;
            });
    }


    private static void SeedData(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Seed Owners
            if (!context.Owners.Any())
            {
                var owner1 = new Owner { Name = "John Doe", Email = "john@example.com" };
                var owner2 = new Owner { Name = "Jane Smith", Email = "jane@example.com" };

                context.Owners.AddRange(owner1, owner2);
                context.SaveChanges();

                // Seed Vehicles
                var vehicle1 = new Vehicle { Make = "Toyota", Model = "Camry", Year = 2020, OwnerId = owner1.Id, LicensePlate = "qwe-123" };
                var vehicle2 = new Vehicle { Make = "Honda", Model = "Civic", Year = 2021, OwnerId = owner1.Id, LicensePlate = "asd-456" };
                var vehicle3 = new Vehicle { Make = "Ford", Model = "Mustang", Year = 2022, OwnerId = owner2.Id, LicensePlate = "zxc-789" };

                context.Vehicles.AddRange(vehicle1, vehicle2, vehicle3);
                context.SaveChanges();
            }
        }
    }

    private static WebApplication CleanArchitectureWebApplication(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        ConfigureCleanArchitectureServices(builder.Services);

        var app = builder.Build();

        // Seed data
        SeedData(app.Services);

        // Use custom middleware for global exception handling
        app.UseMiddleware<GlobalExceptionHandler>();

        app.UseRouting();
        app.MapControllers(); // Maps the attribute-routed controllers

        return app;
    }

    private static void ConfigureCleanArchitectureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("DemoDb")); // Use an in-memory database for demo purposes

        // Register MediatR with the current assembly
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        // Register repositories
        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();

        // Configure JSON options to handle reference cycles
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.MaxDepth = 64;
            });
    }

}
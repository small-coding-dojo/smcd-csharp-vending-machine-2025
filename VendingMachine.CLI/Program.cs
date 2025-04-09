using VendingMachine.Core;

namespace VendingMachine.CLI;

public class Program
{
    private static VendingMachineService _vendingMachine = new VendingMachineService();

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Vending Machine CLI!");
        _vendingMachine.InitializeWithDefaultProducts();
        
        bool exit = false;
        while (!exit)
        {
            DisplayMenu();
            string choice = Console.ReadLine() ?? string.Empty;
            
            switch (choice.ToUpper())
            {
                case "1":
                    DisplayProducts();
                    break;
                case "2":
                    InsertMoney();
                    break;
                case "3":
                    PurchaseProduct();
                    break;
                case "4":
                    ReturnChange();
                    break;
                case "Q":
                    exit = true;
                    Console.WriteLine("Thank you for using the Vending Machine. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine($"Current Balance: {_vendingMachine.GetBalance():C}");
        Console.WriteLine("\nPlease select an option:");
        Console.WriteLine("1. Display Products");
        Console.WriteLine("2. Insert Money");
        Console.WriteLine("3. Purchase Product");
        Console.WriteLine("4. Return Change");
        Console.WriteLine("Q. Quit");
        Console.Write("\nYour choice: ");
    }

    private static void DisplayProducts()
    {
        var products = _vendingMachine.GetProducts();
        Console.WriteLine("\nAvailable Products:");
        Console.WriteLine("ID\tName\t\tPrice\tQuantity");
        Console.WriteLine("----------------------------------------");
        
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id}\t{product.Name,-10}\t{product.Price:C}\t{product.Quantity}");
        }
    }

    private static void InsertMoney()
    {
        Console.WriteLine("\nInsert Money:");
        Console.WriteLine("Valid amounts: 0.25, 0.50, 1.00, 2.00, 5.00");
        Console.Write("Enter amount: ");
        
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            try
            {
                _vendingMachine.InsertMoney(amount);
                Console.WriteLine($"Added {amount:C}. New balance: {_vendingMachine.GetBalance():C}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount. Please enter a valid number.");
        }
    }

    private static void PurchaseProduct()
    {
        DisplayProducts();
        Console.Write("\nEnter product ID to purchase: ");
        string productId = Console.ReadLine() ?? string.Empty;
        
        string result = _vendingMachine.PurchaseProduct(productId);
        Console.WriteLine(result);
    }

    private static void ReturnChange()
    {
        decimal change = _vendingMachine.ReturnChange();
        Console.WriteLine($"Returned change: {change:C}");
    }
}

namespace VendingMachine.Core;

/// <summary>
/// Represents a product in the vending machine
/// </summary>
public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(string id, string name, decimal price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Id}\t{Name, -10}\t{Price:C}\t{Quantity}";
    }
}
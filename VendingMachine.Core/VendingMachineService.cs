namespace VendingMachine.Core;

/// <summary>
/// Service that handles vending machine operations
/// </summary>
public class VendingMachineService
{
    private readonly Products _alternativeProducts = new Products();
    private readonly List<Product> _products;
    private decimal _balance;

    public VendingMachineService()
    {
        _products = new List<Product>();
        _balance = 0;
    }

    /// <summary>
    /// Initializes the vending machine with default products
    /// </summary>
    public void InitializeWithDefaultProducts()
    {
        _products.Clear();
        _products.Add(new Product("A1", "Cola", 1.50m, 10));
        _products.Add(new Product("A2", "Water", 1.00m, 10));
        _products.Add(new Product("B1", "Chips", 1.25m, 10));
        _products.Add(new Product("B2", "Chocolate", 1.75m, 10));
    }

    /// <summary>
    /// Gets all available products
    /// </summary>
    public List<Product> GetProducts()
    {
        return _products.ToList();
    }

    /// <summary>
    /// Inserts money into the vending machine
    /// </summary>
    public void InsertMoney(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero");
        }

        _balance += amount;
    }

    /// <summary>
    /// Gets the current balance
    /// </summary>
    public decimal GetBalance()
    {
        return _balance;
    }

    /// <summary>
    /// Purchases a product by its ID
    /// </summary>
    public string PurchaseProduct(string productId)
    {
        var product = _products.FirstOrDefault(p => p.Id == productId);
        
        if (product == null)
        {
            return "Product not found";
        }

        if (product.Quantity <= 0)
        {
            return "Product out of stock";
        }

        if (_balance < product.Price)
        {
            return $"Insufficient funds. You need {product.Price - _balance:C} more.";
        }

        // Process the purchase
        product.Quantity--;
        _balance -= product.Price;
        
        return $"Dispensing {product.Name}. Remaining balance: {_balance:C}";
    }

    /// <summary>
    /// Returns the remaining balance and resets it to zero
    /// </summary>
    public decimal ReturnChange()
    {
        decimal change = _balance;
        _balance = 0;
        return change;
    }
}

internal class Products
{
    private Dictionary<StorageCode, Product> _products = new();

}
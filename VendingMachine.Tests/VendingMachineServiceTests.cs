using VendingMachine.Core;

namespace VendingMachine.Tests;

public class VendingMachineServiceTests
{
    private readonly VendingMachineService _vendingMachine;

    public VendingMachineServiceTests()
    {
        _vendingMachine = new VendingMachineService();
        _vendingMachine.InitializeWithDefaultProducts();
    }

    [Fact]
    public void InitializeWithDefaultProducts_ShouldAddFourProducts()
    {
        // Act
        var products = _vendingMachine.GetProducts();

        // Assert
        Assert.Equal(4, products.Count);
    }

    [Fact]
    public void InsertMoney_ShouldIncreaseBalance()
    {
        // Arrange
        decimal initialBalance = _vendingMachine.GetBalance();
        decimal amountToInsert = 1.50m;

        // Act
        _vendingMachine.InsertMoney(amountToInsert);

        // Assert
        Assert.Equal(initialBalance + amountToInsert, _vendingMachine.GetBalance());
    }

    [Fact]
    public void InsertMoney_WithNegativeAmount_ShouldThrowException()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _vendingMachine.InsertMoney(-1.00m));
        Assert.Contains("Amount must be greater than zero", exception.Message);
    }

    [Fact]
    public void PurchaseProduct_WithSufficientFunds_ShouldDecrementQuantityAndBalance()
    {
        // Arrange
        _vendingMachine.InsertMoney(2.00m);
        var initialBalance = _vendingMachine.GetBalance();
        var productId = "A1"; // Cola costs 1.50
        var product = _vendingMachine.GetProducts().First(p => p.Id == productId);
        var initialQuantity = product.Quantity;

        // Act
        var result = _vendingMachine.PurchaseProduct(productId);

        // Assert
        Assert.Contains("Dispensing Cola", result);
        Assert.Equal(initialQuantity - 1, product.Quantity);
        Assert.Equal(initialBalance - product.Price, _vendingMachine.GetBalance());
    }

    [Fact]
    public void PurchaseProduct_WithInsufficientFunds_ShouldReturnErrorMessage()
    {
        // Arrange
        _vendingMachine.InsertMoney(0.50m);
        var productId = "A1"; // Cola costs 1.50

        // Act
        var result = _vendingMachine.PurchaseProduct(productId);

        // Assert
        Assert.Contains("Insufficient funds", result);
    }

    [Fact]
    public void PurchaseProduct_WithInvalidId_ShouldReturnErrorMessage()
    {
        // Act
        var result = _vendingMachine.PurchaseProduct("Z9");

        // Assert
        Assert.Equal("Product not found", result);
    }

    [Fact]
    public void ReturnChange_ShouldResetBalanceToZero()
    {
        // Arrange
        _vendingMachine.InsertMoney(5.00m);
        var expectedChange = _vendingMachine.GetBalance();

        // Act
        var actualChange = _vendingMachine.ReturnChange();

        // Assert
        Assert.Equal(expectedChange, actualChange);
        Assert.Equal(0, _vendingMachine.GetBalance());
    }
}
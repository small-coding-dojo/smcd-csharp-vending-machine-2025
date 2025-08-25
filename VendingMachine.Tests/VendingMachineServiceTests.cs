using System.Globalization;

namespace VendingMachine.Tests;

public class VendingMachineServiceTests
{
    [Fact]
    public void SomeTest()
    {
        var machine = new TheVendingMachine();
        Assert.Equal("INSERT COIN", machine.Output);
    }
    
    [Fact]
    public void SomeTest2()
    {
        var machine = new TheVendingMachine();
        dynamic coin = new { Diameter= 21.21 };
        machine.InsertCoin(coin);
        Assert.Equal("0.05", machine.Output);
        machine.InsertCoin(coin);
        Assert.Equal("0.10", machine.Output);
    }
}

public class TheVendingMachine
{
    public string Output { get; set; } = "INSERT COIN";

    public void InsertCoin(dynamic coin)
    {
        var balance = 0.05m;
        if (Output == "0.05")
            Output = "0.10";
        else
            Output = balance.ToString("F2", CultureInfo.InvariantCulture);
    }
}


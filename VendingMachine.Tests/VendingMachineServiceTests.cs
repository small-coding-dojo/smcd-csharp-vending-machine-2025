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
    
    [Fact]
    public void SomeTest3()
    {
        var machine = new TheVendingMachine();
        dynamic coin = new { Diameter= 17.91 };
        machine.InsertCoin(coin);
        Assert.Equal("0.10", machine.Output);
    }

    [Fact]
    public void SomeTest4()
    {
        var machine = new TheVendingMachine();
        dynamic coin = new { Diameter= 24.26 };
        machine.InsertCoin(coin);
        Assert.Equal("0.30", machine.Output);
        machine.InsertCoin(coin);
        Assert.Equal("0.60", machine.Output);
    }

    [Fact]
    public void TESTNAME()
    {
        var sut = new TheVendingMachine();
        dynamic stone = new { Diameter = 98 };
        sut.InsertCoin(stone);
        Assert.Equal("INSERT COIN", sut.Output);
    }

    [Fact]
    public void TESTNAME2()
    {
        var sut = new TheVendingMachine();
        dynamic stone = new { Diameter = 21.22 };
        sut.InsertCoin(stone);
        Assert.Equal("0.05", sut.Output);

    }
}

public class TheVendingMachine
{
    private decimal _balance;
    public string Output { get; set; } = "INSERT COIN";

    public void InsertCoin(dynamic coin)
    {
        if (coin.Diameter == 24.26)
            _balance += 0.30m;
        else if (coin.Diameter == 17.91)
            _balance += 0.10m;
        else if(coin.Diameter >= 21.21 && coin.Diameter <=21.22)
            _balance += 0.05m;
        if(_balance > 0.0m)
            Output = _balance.ToString("F2", CultureInfo.InvariantCulture);
    }
}


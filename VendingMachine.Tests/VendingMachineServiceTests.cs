using System.Globalization;

namespace VendingMachine.Tests;

public class VendingMachineServiceTests
{
    [Fact]
    public void SomeTest()
    {
        var testDisplay = new TestDisplay();
        _ = new TheVendingMachine(testDisplay);
        
        Assert.Equal("INSERT COIN", testDisplay.Output);
    }

    [Fact]
    public void When_inserting_2_nickels_Then_show_0_10()
    {
        var testDisplay = new TestDisplay();
        var subject = new TheVendingMachine(testDisplay);
        
        var nickel = new PhysicalObject(5.00);

        subject.Insert(nickel);
        Assert.Equal("0.05", testDisplay.Output);

        subject.Insert(nickel);
        Assert.Equal("0.10", testDisplay.Output);
    }

    [Fact]
    public void When_inserting_2_dimes_Then_show_0_20()
    {
        var testDisplay = new TestDisplay();
        var subject = new TheVendingMachine(testDisplay);
        
        var dime = new PhysicalObject(2.268);
        
        subject.Insert(dime);
        Assert.Equal("0.10", testDisplay.Output);

        subject.Insert(dime);
        Assert.Equal("0.20", testDisplay.Output);
    }
}

public readonly record struct PhysicalObject(double Weight);

public class TestDisplay
{
    public string Output { get; set; } = string.Empty;

    public void Show(string message)
    {
        Output = message;
    }
}

public class TheVendingMachine
{
    private readonly TestDisplay _testDisplay;
    private decimal _balance;

    public TheVendingMachine(TestDisplay testDisplay)
    {
        _testDisplay = testDisplay;
        _testDisplay.Show("INSERT COIN");
    }

    public void Insert(PhysicalObject coin)
    {
        if (coin.Weight == 2.268)
        {
            _balance += 0.10m;
        }
        else
        {
            _balance += 0.05m;
        }

        _testDisplay.Show(_balance.ToString(CultureInfo.InvariantCulture));
    }
}
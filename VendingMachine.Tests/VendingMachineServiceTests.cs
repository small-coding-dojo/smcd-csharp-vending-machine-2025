using VendingMachine.CLI;

namespace VendingMachine.Tests;

public class VendingMachineServiceTests
{
    [Fact]
    public void When_empty_Then_show_INSERT_COIN()
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

    [Fact]
    public void When_inserting_2_quarters_Then_show_0_50()
    {
        var testDisplay = new TestDisplay();
        var subject = new TheVendingMachine(testDisplay);

        var quarter = new PhysicalObject(5.67);

        subject.Insert(quarter);
        Assert.Equal("0.25", testDisplay.Output);
        
        subject.Insert(quarter);
        Assert.Equal("0.50", testDisplay.Output);
    }
    
    [Fact]
    public void When_inserting_2_quarters_Then_show_0_50___()
    {
        var testDisplay = new TestDisplay();
        var subject = new TheVendingMachine(testDisplay);

        var stone = new PhysicalObject(4.2);

        subject.Insert(stone);
        Assert.Equal("INSERT COIN", testDisplay.Output);
    }
}
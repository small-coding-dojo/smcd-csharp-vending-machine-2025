namespace VendingMachine.Tests;

public class VendingMachineServiceTests
{
    [Fact]
    public void SomeTest()
    {
        var testDisplay = new TestDisplay();
        var subject = new TheVendingMachine(testDisplay);
        
        Assert.Equal("INSERT COIN", testDisplay.Output);
    }
}

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
    public TheVendingMachine(TestDisplay testDisplay)
    {
        testDisplay.Show("INSERT COIN");
    }
}
namespace VendingMachine.Tests;

public class VendingMachineServiceTests
{
    [Fact]
    public void FreshMachineShowsInsertCoin()
    {
        ICanDisplay testDisplay = new TestDisplay();
        var testMachine = new VendingMachineImplementation(testDisplay);
        Assert.Equal("INSERT COIN", testDisplay.Output);
    }
}

public interface ICanDisplay
{
    void Show(string insertCoin);
    string Output { get; set; }
}

public class VendingMachineImplementation
{
    private readonly ICanDisplay _display;

    public VendingMachineImplementation(ICanDisplay display) 
    {
        _display = display;
        _display.Show("INSERT COIN");
    }
}

public class TestDisplay : ICanDisplay
{
    public string Output { get; set; } = "";

    public void Show(string message)
    {
        Output = message;
    }
}


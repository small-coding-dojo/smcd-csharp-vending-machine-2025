using VendingMachine.CLI;

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
using VendingMachine.CLI;

namespace VendingMachine.Tests;

public class VendingMachineServiceTests
{
    [Fact]
    public void FreshMachineShowsInsertCoin()
    {
        var testDisplay = new TestDisplay();
        var _ = new VendingMachineImplementation(testDisplay);

        Assert.Equal("INSERT COIN", testDisplay.Output);
    }
}
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

    [Fact]
    public void FreshMachine_InsertNickel_ShowsBalance5Cents()
    {
        var testDisplay = new TestDisplay();
        var testMachine = new VendingMachineImplementation(testDisplay);

        Coin coin = new Coin(CoinInfos.Nickel.Weight, CoinInfos.Nickel.Diameter, CoinInfos.Nickel.Thickness);
        
        testMachine.InsertCoin(coin);
        
        Assert.Equal("0.05", testDisplay.Output);

        testMachine.InsertCoin(coin);

        Assert.Equal("0.10", testDisplay.Output);

    }
}

public struct CoinInfos
{
    public static CoinInfo Nickel = new CoinInfo(1, 2, 3);
}

public readonly record struct CoinInfo(double Weight, double Diameter, double Thickness);
using VendingMachine.CLI;

namespace VendingMachine.Tests;

public struct CoinInfo
{
    public double Weight;
    public double Diameter;
    public double Thickness;

}

public class CoinInfos {

    public static CoinInfo Nickel = new CoinInfo() { Diameter = 21.21, Thickness = 1.95, Weight = 5.0 };

}

public class VendingMachineServiceTests
{
    [Fact]
    public void FreshMachineShowsInsertCoin()
    {
        ICanDisplay testDisplay = new TestDisplay();
        var testMachine = new VendingMachineImplementation(testDisplay);
        Assert.Equal("INSERT COIN", testDisplay.Output);
    }

    [Fact]
    public void InsertTwoNickels()
    {
        // arrange
        var ourNickel = new Coin(CoinInfos.Nickel.Weight, CoinInfos.Nickel.Diameter, CoinInfos.Nickel.Thickness);

        var testDisplay = new TestDisplay();
        var testMachine = new VendingMachineImplementation(testDisplay);
        
        // act
        testMachine.InsertCoin(ourNickel);

        // assert
        Assert.Equal("0.05", testDisplay.Output);
        
        // act
        testMachine.InsertCoin(ourNickel);

        // assert
        Assert.Equal("0.10", testDisplay.Output);
    }
}
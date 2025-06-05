using VendingMachine.CLI;

namespace VendingMachine.Tests;

public struct CoinInfo
{
    public double Weight;
    public double Diameter;
    public double Thickness;

}

public abstract class CoinInfos {

    public static CoinInfo Nickel = new() { Diameter = 21.21, Thickness = 1.95, Weight = 5.0 };
    public static CoinInfo Dime = new() { Diameter = 17.91, Thickness = 1.35, Weight = 2.268 };
    public static CoinInfo Quarter = new() { Diameter = 24.257, Thickness = 1.7526, Weight = 5.67 };
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
    public void InsertANickel()
    {
        // arrange
        var ourNickel = new Coin(CoinInfos.Nickel.Weight, CoinInfos.Nickel.Diameter, CoinInfos.Nickel.Thickness);

        var testDisplay = new TestDisplay();
        var testMachine = new VendingMachineImplementation(testDisplay);

        // act
        testMachine.InsertCoin(ourNickel);

        // assert
        Assert.Equal("0.05", testDisplay.Output);
    }

    [Fact]
    public void InsertADime()
    {
        // arrange
        var ourDime = new Coin(CoinInfos.Dime.Weight, CoinInfos.Dime.Diameter, CoinInfos.Dime.Thickness);

        var testDisplay = new TestDisplay();
        var testMachine = new VendingMachineImplementation(testDisplay);

        // act
        testMachine.InsertCoin(ourDime);

        // assert
        Assert.Equal("0.10", testDisplay.Output);
    }
    
    [Fact]
    public void InsertAQuarter()
    {
        // arrange
        var ourQuarter = new Coin(CoinInfos.Quarter.Weight, CoinInfos.Quarter.Diameter, CoinInfos.Quarter.Thickness);

        var testDisplay = new TestDisplay();
        var testMachine = new VendingMachineImplementation(testDisplay);

        // act
        testMachine.InsertCoin(ourQuarter);

        // assert
        Assert.Equal("0.25", testDisplay.Output);
    }

    [Fact]
    public void InsertANickelAndADimeAndAQuarter()
    {
        // arrange
        var ourNickel = new Coin(CoinInfos.Nickel.Weight, CoinInfos.Nickel.Diameter, CoinInfos.Nickel.Thickness);
        var ourDime = new Coin(CoinInfos.Dime.Weight, CoinInfos.Dime.Diameter, CoinInfos.Dime.Thickness);
        var ourQuarter = new Coin(CoinInfos.Quarter.Weight, CoinInfos.Quarter.Diameter, CoinInfos.Quarter.Thickness);

        var testDisplay = new TestDisplay();
        var testMachine = new VendingMachineImplementation(testDisplay);

        // act
        testMachine.InsertCoin(ourNickel);

        // assert
        Assert.Equal("0.05", testDisplay.Output);

        // act
        testMachine.InsertCoin(ourDime);

        // assert
        Assert.Equal("0.15", testDisplay.Output);
        
        // act
        testMachine.InsertCoin(ourQuarter);

        // assert
        Assert.Equal("0.40", testDisplay.Output);
    }
}

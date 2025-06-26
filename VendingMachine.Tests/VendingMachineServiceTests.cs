using VendingMachine.CLI;

namespace VendingMachine.Tests;

public class VendingMachineServiceTests
{
    [Fact]
    public void FreshMachine_NothingInserted_ShowsInsertCoin()
    {
        var testDisplay = new TestDisplay();
        var _ = new VendingMachineImplementation(testDisplay);

        Assert.Equal("INSERT COIN", testDisplay.Output);
    }

    [Fact]
    public void FreshMachine_InsertTwoNickels_ShowsBalance10Cents()
    {
        var testDisplay = new TestDisplay();
        var testMachine = new VendingMachineImplementation(testDisplay);

        var coin = new Coin(CoinInfos.Nickel.Weight, CoinInfos.Nickel.Diameter, CoinInfos.Nickel.Thickness);
        
        testMachine.InsertCoin(coin);
        
        Assert.Equal("0.05", testDisplay.Output);

        testMachine.InsertCoin(coin);

        Assert.Equal("0.10", testDisplay.Output);
    }

    [Fact]
    public void FreshMachine_InsertTwoDimes_ShowsBalance20Cents()
    {
        var testDisplay = new TestDisplay();
        var testMachine = new VendingMachineImplementation(testDisplay);

        var coin = new Coin(CoinInfos.Dime.Weight, CoinInfos.Dime.Diameter, CoinInfos.Dime.Thickness);

        testMachine.InsertCoin(coin);

        Assert.Equal("0.10", testDisplay.Output);

        testMachine.InsertCoin(coin);

        Assert.Equal("0.20", testDisplay.Output);
    }

    [Fact]
    public void FreshMachine_InsertTwoQuarters_ShowsBalance50Cents()
    {
        var testDisplay = new TestDisplay();
        var testMachine = new VendingMachineImplementation(testDisplay);

        var coin = new Coin(CoinInfos.Quarter.Weight, CoinInfos.Quarter.Diameter, CoinInfos.Quarter.Thickness);

        testMachine.InsertCoin(coin);

        Assert.Equal("0.25", testDisplay.Output);

        testMachine.InsertCoin(coin);

        Assert.Equal("0.50", testDisplay.Output);
    }

    [Fact]
    public void FreshMachine_InsertDimeNickelQuarter_ShowsBalance40Cents()
    {
        var testDisplay = new TestDisplay();
        var testMachine = new VendingMachineImplementation(testDisplay);

        var ourDime = new Coin(CoinInfos.Dime.Weight, CoinInfos.Dime.Diameter, CoinInfos.Dime.Thickness);
        var ourNickel = new Coin(CoinInfos.Nickel.Weight, CoinInfos.Nickel.Diameter, CoinInfos.Nickel.Thickness);
        var ourQuarter = new Coin(CoinInfos.Quarter.Weight, CoinInfos.Quarter.Diameter, CoinInfos.Quarter.Thickness);

        testMachine.InsertCoin(ourDime);
        testMachine.InsertCoin(ourNickel);
        testMachine.InsertCoin(ourQuarter);

        Assert.Equal("0.40", testDisplay.Output);
    }
}
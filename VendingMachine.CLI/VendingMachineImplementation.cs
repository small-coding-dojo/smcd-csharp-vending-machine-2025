using System.Globalization;

namespace VendingMachine.CLI;

public class VendingMachineImplementation
{
    private readonly ICanDisplay _display;
    private decimal _balance;
    
    public VendingMachineImplementation(ICanDisplay display)
    {
        _display = display;

        _display.Show("INSERT COIN");
    }

    public void InsertCoin(Coin coin)
    {
        _balance += 0.05m;
        _display.Show(_balance.ToString(CultureInfo.InvariantCulture));
    }
}
using System.Globalization;

namespace VendingMachine.CLI;

public class TheVendingMachine
{
    private readonly ICanDisplay _testDisplay;
    private decimal _balance;

    public TheVendingMachine(ICanDisplay testDisplay)
    {
        _testDisplay = testDisplay;
        _testDisplay.Show("INSERT COIN");
    }

    public void Insert(PhysicalObject coin)
    {
        if (coin.Weight == 5.67)
        {
            _balance += 0.25m;
        }
        else if (coin.Weight == 2.268)
        {
            _balance += 0.10m;
        }
        else if (coin.Weight == 5.00)
        {
            _balance += 0.05m;
        }

        if (_balance > 0.0m)
        {
            _testDisplay.Show(_balance.ToString(CultureInfo.InvariantCulture));
        }
    }
}
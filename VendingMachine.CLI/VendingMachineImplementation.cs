using System.Collections.Immutable;
using System.Globalization;

namespace VendingMachine.CLI;

public class VendingMachineImplementation
{
    private readonly record struct CoinTemplate(double Weight, decimal Value);
    
    private readonly ICanDisplay _display;
    private decimal _balance;
    private readonly ImmutableList<CoinTemplate> _coinTemplates;

    public VendingMachineImplementation(ICanDisplay display)
    {
        _coinTemplates = ImmutableList.Create(
            new CoinTemplate(5.0, 0.05m),
            new CoinTemplate(2.268, 0.10m),
            new CoinTemplate(5.67, 0.25m)
        );

        _display = display;

        _display.Show("INSERT COIN");
    }

    public void InsertCoin(Coin coin)
    {
        var distances = new Dictionary<double, CoinTemplate>();
        foreach (var template in _coinTemplates)
        {
            var weightDistance = Math.Abs(template.Weight - coin.Weight);
            distances.Add(weightDistance, template);
        }

        _balance += distances[distances.Keys.Min()].Value;
        _display.Show(_balance.ToString(CultureInfo.InvariantCulture));
    }
}
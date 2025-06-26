using System.Collections.Immutable;
using System.Globalization;

namespace VendingMachine.CLI;

public class VendingMachineImplementation
{
    private readonly record struct CoinTemplate(double Weight, double Diameter, decimal Value);
    
    private readonly ICanDisplay _display;
    private decimal _balance;
    private readonly ImmutableList<CoinTemplate> _coinTemplates;
    private readonly double _tolerance = 1.0 / 100.0;

    public VendingMachineImplementation(ICanDisplay display)
    {
        _coinTemplates = ImmutableList.Create(
            new CoinTemplate(5.0, 21.21, 0.05m),
            new CoinTemplate(2.268, 17.91, 0.10m),
            new CoinTemplate(5.67, 24.257, 0.25m)
        );

        _display = display;

        _display.Show("INSERT COIN");
    }

    public void InsertCoin(Coin coin)
    {
        var coinBasedOnWeightDistance = FindNearestCoin(coin, t => t.Weight, c => c.Weight);
        var coinBasedOnDiameterDistance = FindNearestCoin(coin, t => t.Diameter, c => c.Diameter);

        var actualTolerance = coinBasedOnDiameterDistance.Diameter * _tolerance;
        var diameterDifference = Math.Abs(coinBasedOnDiameterDistance.Diameter - coin.Diameter);

        if (diameterDifference < actualTolerance)
        {
            _balance += coinBasedOnWeightDistance.Value;
            _display.Show(_balance.ToString(CultureInfo.InvariantCulture));
        }
    }

    private CoinTemplate FindNearestCoin(Coin coin, Func<CoinTemplate, double> templatePropertySelector, Func<Coin, double> coinPropertySelector)
    {
        var distances = new Dictionary<double, CoinTemplate>();
        foreach (var coinTemplate in _coinTemplates)
        {
            var distance = Math.Abs(templatePropertySelector(coinTemplate) - coinPropertySelector(coin));
            distances.Add(distance, coinTemplate);
        }

        return distances[distances.Keys.Min()];
    }
}
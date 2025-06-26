using System.Collections.Immutable;
using System.Globalization;

namespace VendingMachine.CLI;

public class VendingMachineImplementation
{
    private readonly record struct CoinTemplate(double Weight, double Diameter, double Thickness, decimal Value);
    
    private readonly ICanDisplay _display;
    private decimal _balance;
    private readonly ImmutableList<CoinTemplate> _coinTemplates;
    private readonly double _tolerance = 1.0 / 100.0;

    public VendingMachineImplementation(ICanDisplay display)
    {
        _coinTemplates = ImmutableList.Create(
            new CoinTemplate(5.0, 21.21, 1.95, 0.05m),
            new CoinTemplate(2.268, 17.91, 1.35, 0.10m),
            new CoinTemplate(5.67, 24.257, 1.7526, 0.25m)
        );

        _display = display;

        _display.Show("INSERT COIN");
    }

    public void InsertCoin(Coin coin)
    {
        var value = GetCoinValue(coin);

        if (value > 0.0m)
        {
            _balance += value;
            _display.Show(_balance.ToString(CultureInfo.InvariantCulture));
        }
    }

    private decimal GetCoinValue(Coin coin)
    {
        var coinBasedOnWeightDistance = FindNearestCoinByWeight(coin);
        var coinBasedOnDiameterDistance = FindNearestCoinByDiameter(coin);
        var coinBasedOnThicknessDistance = FindNearestCoinByThickness(coin);

        var isWeightDifferenceWithinTolerance = IsDifferenceWithinTolerance(coin, coinBasedOnWeightDistance, t => t.Weight, c => c.Weight);
        var isDiameterDifferenceWithinTolerance = IsDifferenceWithinTolerance(coin, coinBasedOnDiameterDistance, t => t.Diameter, c => c.Diameter);
        var isThicknessDifferenceWithinTolerance = IsDifferenceWithinTolerance(coin, coinBasedOnThicknessDistance, t => t.Thickness, c => c.Thickness);

        var isWithinTolerance = isWeightDifferenceWithinTolerance 
                                && isDiameterDifferenceWithinTolerance 
                                && isThicknessDifferenceWithinTolerance;
        
        var value = 0.0m;

        if (isWithinTolerance)
        {
            value = coinBasedOnWeightDistance.Value;
        }

        return value;
    }

    private bool IsDifferenceWithinTolerance(Coin coin, CoinTemplate coinTemplate, Func<CoinTemplate, double> templatePropertySelector, Func<Coin, double> coinPropertySelector)
    {
        var actualTolerance = templatePropertySelector(coinTemplate) * _tolerance;
        var difference = Math.Abs(templatePropertySelector(coinTemplate) - coinPropertySelector(coin));
        var isDifferenceWithinTolerance = difference < actualTolerance;
        
        return isDifferenceWithinTolerance;
    }
    
    private CoinTemplate FindNearestCoinByWeight(Coin coin) => FindNearestCoin(coin, t=> t.Weight, c => c.Weight);
    private CoinTemplate FindNearestCoinByDiameter(Coin coin) => FindNearestCoin(coin, t=> t.Diameter, c => c.Diameter);
    private CoinTemplate FindNearestCoinByThickness(Coin coin) => FindNearestCoin(coin, t=> t.Thickness, c => c.Thickness);
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
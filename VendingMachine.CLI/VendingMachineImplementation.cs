using System.Collections.Immutable;
using System.Globalization;

namespace VendingMachine.CLI;

public class VendingMachineImplementation
{
    private readonly ICanDisplay _display;
    private readonly ImmutableList<CoinTemplate> _coinTemplates;
    private readonly double TolerancePercentage = 1;
    private decimal _balance = 0;

    public void InsertCoin(Coin inputCoin)
    {
        // Wenn Gewicht = 5g
        // Wenn Durchmesser = 21,21mm
        // Wenn Dicke = 1,95mm
        // Dann Wert = 0,05 USD
        
        var value = EvaluateCoin(inputCoin);
        _balance += value;

        if (_balance > 0.0m)
        {
            _display.Show(_balance.ToString(CultureInfo.InvariantCulture));
        }
    }

    public VendingMachineImplementation(ICanDisplay display) 
    {
        _coinTemplates = ImmutableList.Create(
            new CoinTemplate(5.0, 21.21, 1.95, 0.05m),
            new CoinTemplate(2.268, 17.91, 1.35, 0.10m),
            new CoinTemplate(5.67, 24.257, 1.7526, 0.25m)
            //new PennyTemplate(2.5, 19.05, 1.52, 0.05m) This is a help comment
        );
        _display = display;
        _display.Show("INSERT COIN");
    }

    private decimal EvaluateCoin(Coin inputCoin)
    {
        // The coin - to - value mapping is defined by a table
        // containing the columns = CoinTemplate
        // - Weight
        // - Diameter
        // - Thickness
        // - Value
        // and a global constant struct giving the tolerances
        // - Tolerance.WeightPercent
        // - Tolerance.DiameterPercent
        // - Tolerance.ThicknessPercent
        
        var coinBasedOnWeight = FindNearestCoin(inputCoin, t => t.Weight, c => c.Weight);
        var coinBasedOnDiameter = FindNearestCoin(inputCoin, t => t.Diameter, c => c.Diameter);
        var coinBasedOnThickness = FindNearestCoin(inputCoin, t => t.Thickness, c => c.Thickness);
        
        // We need to verify that the difference is within the tolerance
        var difference = Math.Abs(coinBasedOnDiameter.Diameter - inputCoin.Diameter);
        var tolerance = coinBasedOnDiameter.Diameter * TolerancePercentage / 100.0;
        if (difference > tolerance)
        {
            return 0.0m;
        }

        return coinBasedOnDiameter.Value;
    }


    private CoinTemplate FindNearestCoin(Coin inputCoin, Func<CoinTemplate, double> coinTemplatePropertySelector, Func<Coin, double> coinPropertySelector)
    {
        var absoluteDifferences = new Dictionary<double, CoinTemplate>();
        foreach (var coinTemplate in _coinTemplates)
        {
            var absoluteDifference = Math.Abs(coinTemplatePropertySelector(coinTemplate) - coinPropertySelector(inputCoin));
            absoluteDifferences.Add(absoluteDifference, coinTemplate);
        }
        var minimumDifference = absoluteDifferences.Keys.Min();
        return absoluteDifferences[minimumDifference];
    }
}

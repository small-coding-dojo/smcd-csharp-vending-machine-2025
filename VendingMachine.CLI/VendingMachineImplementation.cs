using System.Collections.Immutable;
using System.Globalization;

namespace VendingMachine.CLI;

public class VendingMachineImplementation
{
    private readonly ICanDisplay _display;
    private readonly ImmutableList<CoinTemplate> _coinTemplates;

    private decimal _balance = 0;

    public VendingMachineImplementation(ICanDisplay display) 
    {
        _coinTemplates = ImmutableList.Create(
            new CoinTemplate(5.0, 21.21, 1.95, 0.05m),
            new CoinTemplate(2.268, 17.91, 1.35, 0.10m));
        _display = display;
        _display.Show("INSERT COIN");
    }

    public void InsertCoin(Coin inputCoin)
    {
        // Wenn Gewicht = 5g
        // Wenn Durchmesser = 21,21mm
        // Wenn Dicke = 1,95mm
        // Dann Wert = 0,05 USD
        var value = EvaluateCoin(inputCoin);
        _display.Show(value.ToString( CultureInfo.InvariantCulture));
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
        var template = FindNearestCoin(inputCoin);
        
        _balance += template.Value;
        return _balance;
    }

    private CoinTemplate FindNearestCoin(Coin inputCoin)
    {
        var absoluteWeightDifferences = new Dictionary<double, CoinTemplate>();
        foreach (var coinTemplate in _coinTemplates)
        {
            var absoluteWeightDifference = Math.Abs(coinTemplate.Weight - inputCoin.Weight);
            absoluteWeightDifferences.Add(absoluteWeightDifference, coinTemplate);
        }

        var minimumWeightDifference = absoluteWeightDifferences.Keys.Min();

        return absoluteWeightDifferences[minimumWeightDifference];
    }
}

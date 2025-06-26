using System.Collections.Immutable;
using System.Globalization;

namespace VendingMachine.CLI;

public class VendingMachineImplementation
{
    private readonly record struct CoinTemplate(double Weight, double Diameter, decimal Value);
    
    private readonly ICanDisplay _display;
    private decimal _balance;
    private readonly ImmutableList<CoinTemplate> _coinTemplates;

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
        var weightDistances = new Dictionary<double, CoinTemplate>();
        foreach (var template in _coinTemplates)
        {
            var weightDistance = Math.Abs(template.Weight - coin.Weight);
            weightDistances.Add(weightDistance, template);
        }
        
        var diameterDistances = new Dictionary<double, CoinTemplate>();
        foreach (var template in _coinTemplates)
        {
            var diameterDistance = Math.Abs(template.Diameter - coin.Diameter);
            diameterDistances.Add(diameterDistance, template);
        }

        var minDiameterDistance = diameterDistances.Keys.Min();
        var tolerance = 1.0 / 100.0;
        var actualTolerance = diameterDistances[minDiameterDistance].Diameter * tolerance;
        var diameterDifference = Math.Abs(diameterDistances[minDiameterDistance].Diameter - coin.Diameter);

        if (diameterDifference > actualTolerance)
        {
            return;
        }

        _balance += weightDistances[weightDistances.Keys.Min()].Value;
        _display.Show(_balance.ToString(CultureInfo.InvariantCulture));
    }
}
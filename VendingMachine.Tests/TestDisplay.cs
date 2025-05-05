using VendingMachine.CLI;

namespace VendingMachine.Tests;

public class TestDisplay : ICanDisplay
{
    public string Output { get; set; } = String.Empty;

    public void Show(string message)
    {
        Output = message;
    }
}
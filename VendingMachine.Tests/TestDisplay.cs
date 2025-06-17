using VendingMachine.CLI;

namespace VendingMachine.Tests;

public class TestDisplay : ICanDisplay
{
    public string Output { get; set; } = "";

    public void Show(string message)
    {
        Output = message;
    }
}
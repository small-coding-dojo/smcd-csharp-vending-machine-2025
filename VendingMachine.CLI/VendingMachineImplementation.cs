namespace VendingMachine.CLI;

public class VendingMachineImplementation
{
    private readonly ICanDisplay _display;

    public VendingMachineImplementation(ICanDisplay display) 
    {
        _display = display;
        _display.Show("INSERT COIN");
    }
}
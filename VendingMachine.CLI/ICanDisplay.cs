namespace VendingMachine.CLI;

public interface ICanDisplay
{
    void Show(string message);
    string Output { get; set; }
}
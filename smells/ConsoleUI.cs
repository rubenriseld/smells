using smells.Interfaces;

namespace smells;

public class ConsoleUI : IUI
{
    public void Output(string stringToOutput)
    {
        Console.WriteLine(stringToOutput);
    }
    public string Input()
    {
        return Console.ReadLine().ToString();
    }
    public void Exit()
    {
        System.Environment.Exit(0);
    }
    public void Clear()
    {
        Console.Clear();
    }
}

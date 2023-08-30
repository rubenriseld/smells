namespace smells.Interfaces;

public interface IUI
{
    void Output(string stringToOutput);
    string Input();
    void Exit();
    void Clear();
}

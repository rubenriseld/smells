namespace smells.Interfaces;

public interface IGame
{
    IUI UserInterface { set; }
    string Name { get; set; }
    void AddUserInterface(IUI ui);
    int RunGame();
}

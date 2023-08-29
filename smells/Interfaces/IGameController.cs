namespace smells.Interfaces;

public interface IGameController
{
    IUI UserInterface { get; set; }
    IGameController AddGame(IGame game);
    void HandleMenuChoice();
    void RunController();
}
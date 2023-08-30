namespace smells.Interfaces;

public interface IGameController
{
    IUI UserInterface { get; set; }
    IHighScoreController HighScoreController { get; set; }

    List<IGame>? Games { get; set; }
    IGameController AddGame(IGame game);
    void HandleMenuChoice();
    void RunController();
}
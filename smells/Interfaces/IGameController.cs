namespace smells.Interfaces;

public interface IGameController
{
    IGameController AddGame(IGame game);
    void HandleMenuChoice();
    void Menu();
}
namespace smells.Interfaces
{
    public interface IGameController
    {
        IGameController AddGame(IGame game);
        IGameController AddUserInterface(IUI ui);
        void HandleMenuChoice();
        void Menu();
    }
}
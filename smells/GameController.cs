using smells.Interfaces;

namespace smells;
public class GameController : IGameController
{
    public IUI UserInterface { get; set; }
    public IHighScoreController HighScoreController { get; set; }

    public List<IGame>? Games { get; set; }
    string UserName { get; set; }
    string MenuChoice { get; set; }
    string ErrorMessage { get; set; }

    public GameController(IUI userInterface, IHighScoreController highScoreController)
    {
        UserInterface = userInterface;
        HighScoreController = highScoreController;
        Games = new List<IGame>();
        UserName = MenuChoice = ErrorMessage = String.Empty;
    }

    public IGameController AddGame(IGame game)
    {
        Games.Add(game);
        game.AddUserInterface(UserInterface);
        return this;
    }

    public void RunController()
    {
        if (UserInterface == null)
        {
            Console.WriteLine("No UI connected to the GameController!");
            return;
        }
        if (Games == null || Games.Count == 0)
        {
            UserInterface.Output("No games installed!");
            UserInterface.Exit();
        }
        UserInterface.Output("Enter your usernname:");
        UserName = UserInterface.Input();
        DisplayMenu();
    }

    public void DisplayMenu()
    {
        bool displayingMenu = true;
        while (displayingMenu)
        {
            UserInterface.Clear();
            UserInterface.Output($"Welcome {UserName}! \nChoose what to play:\n");

            foreach (IGame game in Games)
            {
                UserInterface.Output($"[{Games.IndexOf(game)}] {game.Name}");
            }
            UserInterface.Output("[E] Exit\n");

            if (ErrorMessage != String.Empty) UserInterface.Output(ErrorMessage);

            MenuChoice = UserInterface.Input();
            try
            {
                if (MenuChoice.ToUpper() == "E") UserInterface.Exit();
                HandleMenuChoice();
            }
            catch
            {
                ErrorMessage = "Choose from the menu options\n";
            }
        }
    }
    public void HandleMenuChoice()
    {
        bool continuePlaying = true;
        int choice = Convert.ToInt32(MenuChoice);
        if (Games[choice] != null)
        {
            while (continuePlaying)
            {
                int userScore = Games[choice].RunGame();
                RegisterHighScore(Games[choice].Name, UserName, userScore);
                ShowHighScore(Games[choice].Name);
                UserInterface.Output("New game [Y]\tBack to Menu [M]");
                MenuChoice = UserInterface.Input();
                if (MenuChoice.ToUpper() == "M") continuePlaying = false;
            }
        }
        else
        {
            UserInterface.Output("Invalid option!");
        }
    }
    public void RegisterHighScore(string gameName, string userName, int guesses)
    {
        HighScoreController.AddHighScore(gameName, userName, guesses);

    }
    public void ShowHighScore(string gameName)
    {
        UserInterface.Output(HighScoreController.PrintHighScore(gameName));
    }
}
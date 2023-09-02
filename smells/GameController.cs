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
	bool GamesAreInstalled = true;

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
        CheckIfGamesAreInstalled();
		UserInterface.Output("Enter your username:\n");
		UserName = UserInterface.Input();
		DisplayMenu();
	}
	public void CheckIfGamesAreInstalled()
	{
		if (Games.Count == 0)
		{
            GamesAreInstalled = false;
		}
	}
	//HandleGameMenu() 
	//HandleMainGameMenu()
	public void DisplayMenu()
	{
		bool displayingMenu = true;
		while (displayingMenu)
		{
			UserInterface.Clear();
			UserInterface.Output($"Welcome {UserName}!\n");
			ShowGameOptions();
			UserInterface.Output("\n[E] Exit\n");
			if (ErrorMessage != String.Empty) UserInterface.Output(ErrorMessage);
			HandleMenuChoice();
		}
	}
	public void ShowGameOptions()
	{
		if (GamesAreInstalled == true)
		{
			UserInterface.Output("Choose what to play:\n");

			foreach (IGame game in Games)
			{
				UserInterface.Output($"[{Games.IndexOf(game)}] {game.Name}");
			}
		}
		else ErrorMessage = "No games are installed. Please exit and add games to the controller.\n";
	}
	public void HandleMenuChoice()
	{
		try
		{
			MenuChoice = UserInterface.Input();
			if (MenuChoice.ToUpper() == "E") UserInterface.Exit();
			else
			{
				RunGame(Convert.ToInt32(MenuChoice));
				ErrorMessage = String.Empty;
			}
		}
		catch(Exception e)
		{

			ErrorMessage = e.ToString();
		}

	}
	public void RunGame(int selectedGame)
	{
		bool continuePlaying = true;

		while (continuePlaying)
		{
			int userScore = Games[selectedGame].Start();
			RegisterHighScore(Games[selectedGame].Name, userScore);
			ShowHighScore(Games[selectedGame].Name);
			UserInterface.Output("New game [Y]\tBack to Menu [M]");
			MenuChoice = UserInterface.Input();
			if (MenuChoice.ToUpper() == "M") continuePlaying = false;
		}
	}
	public void RegisterHighScore(string gameName, int userScore)
	{
		HighScoreController.AddHighScore(gameName, UserName, userScore);

	}
	public void ShowHighScore(string gameName)
	{
		UserInterface.Output(HighScoreController.PrintHighScore(gameName));
	}
}
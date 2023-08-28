using smells.Interfaces;

namespace smells;
public class GameController : IGameController
{
	private IUI _ui { get; set; }

	private List<IGame>? _games = new List<IGame>();
	string userName { get; set; }
	string menuChoice { get; set; }
	public GameController(IUI ui)
	{
		_ui = ui;
		userName = "";
		menuChoice = "";
	}

	public IGameController AddGame(IGame game)
	{
		_games.Add(game);
		game.AddUserInterface(_ui);
		return this;
	}
	public void RunController()
	{
		try
		{
			if (_ui != null)
			{
				if (_games != null || _games.Count != 0)
				{
					bool ShowMenu = true;
					string errorMessage = "";
					_ui.Output("Enter your user name:");
					userName = _ui.Input();

					while (ShowMenu)
					{
						_ui.Clear();
						_ui.Output($"Welcome {userName}! \nChoose what to play:\n");

						foreach (IGame game in _games)
						{
							_ui.Output($"[{_games.IndexOf(game)}] {game.Name}");
						}
						_ui.Output("[E] Exit\n");
						if(errorMessage != "")_ui.Output(errorMessage);
			

						menuChoice = _ui.Input();
						try
						{
							if (menuChoice.ToUpper() == "E") _ui.Exit();
							HandleMenuChoice();

						}
						catch
						{
							errorMessage="**Choose from the available options\n";
						}
					}
				}
				else
				{
					_ui.Output("No games installed!");
					return;
				}
			}
			else
			{
				Console.WriteLine("No UI connected to the GameController!");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
		}
	}
	public void HandleMenuChoice()
	{
		bool continuePlaying = true;
		int choice = Convert.ToInt32(menuChoice);
		if (_games[choice] != null)
		{
			while (continuePlaying)
			{
				_games[choice].RunGame(userName);

				_ui.Output("New game [Y]\tBack to Menu [M]");
				menuChoice = _ui.Input();
				if (menuChoice.ToUpper() == "M") continuePlaying = false;
			}
		}
		else
		{
			_ui.Output("Invalid option!");
		}
	}
}
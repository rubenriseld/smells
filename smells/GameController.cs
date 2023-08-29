using smells.Interfaces;

namespace smells;
public class GameController : IGameController
{
	public IUI UserInterface { get; set; }

	//private eller ba public?
	private List<IGame>? _Games = new List<IGame>();
	string UserName { get; set; }
	string MenuChoice { get; set; }

	public GameController(IUI userInterface)
	{
		UserInterface = userInterface;
		UserName = "";
		MenuChoice = "";
	}

	public IGameController AddGame(IGame game)
	{
		_Games.Add(game);
		game.AddUserInterface(UserInterface);
		return this;
	}

	//bryt ut controllern
	public void RunController()
	{
		try
		{
			if (UserInterface != null)
			{
				if (_Games != null || _Games.Count != 0)
				{
					bool ShowMenu = true;
					string errorMessage = "";
					UserInterface.Output("Enter your user name:");
					UserName = UserInterface.Input();

					while (ShowMenu)
					{
						UserInterface.Clear();
						UserInterface.Output($"Welcome {UserName}! \nChoose what to play:\n");

						foreach (IGame game in _Games)
						{
							UserInterface.Output($"[{_Games.IndexOf(game)}] {game.Name}");
						}
						UserInterface.Output("[E] Exit\n");
						if(errorMessage != "")UserInterface.Output(errorMessage);
			

						MenuChoice = UserInterface.Input();
						try
						{
							if (MenuChoice.ToUpper() == "E") UserInterface.Exit();
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
					UserInterface.Output("No games installed!");
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
		int choice = Convert.ToInt32(MenuChoice);
		if (_Games[choice] != null)
		{
			while (continuePlaying)
			{
				_Games[choice].RunGame(UserName);

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
}
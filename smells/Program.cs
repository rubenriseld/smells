using smells.Interfaces;
using smells.Games;

namespace smells;

class MainClass
{
	public static void Main(string[] args)
	{
        IUI consoleUserInterface = new ConsoleUI();
		IHighScoreController highScoreController = new HighScoreController();
		
		GameController gameController = new GameController(consoleUserInterface, highScoreController);

		gameController
			.AddGame(new CowsAndBulls())
			.AddGame(new MasterMind())
			.RunController();
    }
}
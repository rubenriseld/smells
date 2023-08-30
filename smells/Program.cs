using smells.Interfaces;

namespace smells;

class MainClass
{
	public static void Main(string[] args)
	{
        IUI consoleUserInterface = new ConsoleUI();
		IHighScoreController highScoreController = new HighScoreController();
		
		GameController gameController = new GameController(consoleUserInterface, highScoreController);

		//kolla factory
		gameController
			.AddGame(new CowsAndBulls())
			.AddGame(new MasterMind())
			.RunController();
    }
}
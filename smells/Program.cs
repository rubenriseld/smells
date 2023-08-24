using System;
using System.IO;
using System.Collections.Generic;
using smells;
using smells.Interfaces;

namespace MooGame;

class MainClass
{
	public static void Main(string[] args)
	{

		IUI userInterface = new UI(); 
		HighScore cowsAndBullshighScores = new HighScore();
		CowsAndBulls cowsAndBulls = new CowsAndBulls();
		GameController gameController = new GameController(cowsAndBullshighScores);
		gameController.AddUserInterface(userInterface);
		gameController.AddGame(cowsAndBulls);
		gameController.Menu();



		//gameController.AddUI(userInterface)
		//	.AddGame(cowsAndBulls)
		//	.AddGame(magicNumbers)

		//gameController.Run();
	}
}


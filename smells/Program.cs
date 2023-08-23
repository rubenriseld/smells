using System;
using System.IO;
using System.Collections.Generic;
using smells;

namespace MooGame;

class MainClass
{
	public static void Main(string[] args)
	{
		IUI userInterface = new UI();
		HighScore highScores = new HighScore();
		CowsAndBulls cowsAndBulls = new CowsAndBulls();
		GameController gameController = new GameController(cowsAndBulls, userInterface, highScores);
		gameController.Menu();
	}
}


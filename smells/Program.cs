using System;
using System.IO;
using System.Collections.Generic;
using smells.Interfaces;
using smells;

namespace MooGame;

class MainClass
{
	public static void Main(string[] args)
	{

		IUI userInterface = new UI(); 
		CowsAndBulls cowsAndBulls = new CowsAndBulls();
		GameController gameController = new GameController(cowsAndBulls, userInterface);
		gameController.Menu();



		//gameController.AddUI(userInterface)
		//	.AddGame(cowsAndBulls)
		//	.AddGame(magicNumbers)

		//gameController.Run();
	}
}


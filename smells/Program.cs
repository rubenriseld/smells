using System;
using System.IO;
using System.Collections.Generic;
using smells.Interfaces;
using smells;
using smells.Interfaces;

namespace MooGame;

class MainClass
{
	public static void Main(string[] args)
	{

		IUI userInterface = new UI(); 
		CowsAndBulls cowsAndBulls = new CowsAndBulls();
		MasterMind masterMind = new MasterMind();
		GameController gameController = new GameController();
		gameController.AddUserInterface(userInterface).AddGame(cowsAndBulls).AddGame(masterMind);
		gameController.Menu();



		//gameController.AddUI(userInterface)
		//	.AddGame(cowsAndBulls)
		//	.AddGame(magicNumbers)

		//gameController.Run();
	}
}


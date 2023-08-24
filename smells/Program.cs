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

		IUI consoleUserInterface = new ConsoleUI(); 
		CowsAndBulls cowsAndBulls = new CowsAndBulls(consoleUserInterface);
		GameController gameController = new GameController();
		gameController.AddUserInterface(consoleUserInterface).AddGame(cowsAndBulls).Menu();



		//gameController.AddUI(userInterface)
		//	.AddGame(cowsAndBulls)
		//	.AddGame(magicNumbers)

		//gameController.Run();
	}
}


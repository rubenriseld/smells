using System;
using System.IO;
using System.Collections.Generic;
using smells.Interfaces;
using smells;

namespace smells;

class MainClass
{
	public static void Main(string[] args)
	{
        IUI consoleUserInterface = new ConsoleUI();

		IUI userInterface = new UI(); 
		CowsAndBulls cowsAndBulls = new CowsAndBulls();
		GameController gameController = new GameController();
		gameController.AddUserInterface(userInterface).AddGame(cowsAndBulls);
		gameController.Menu();

        GameController gameController = new GameController(consoleUserInterface);

		gameController
			.AddGame(cowsAndBulls)
			.RunController();
    }
}


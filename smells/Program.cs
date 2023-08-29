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
		
		GameController gameController = new GameController(consoleUserInterface);


		//kolla factory
		gameController
			.AddGame(new CowsAndBulls())
			.AddGame(new MasterMind())
			.RunController();
    }
}


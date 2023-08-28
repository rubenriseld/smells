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

        CowsAndBulls cowsAndBulls = new CowsAndBulls();

        GameController gameController = new GameController(consoleUserInterface);
		gameController
			.AddGame(cowsAndBulls)
			.Menu();



        //CowsAndBulls cowsAndBulls = new CowsAndBulls(consoleUserInterface);


        //CowsAndBulls cowsAndBulls = new CowsAndBulls();
        //cowsAndBulls
        //	.AddUserInterface(consoleUserInterface);


        //gameController
        //	.AddUserInterface(consoleUserInterface)
        //	.AddGame(cowsAndBulls)
        //	.Menu();
    }
}


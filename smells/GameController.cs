using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smells.Interfaces;

namespace smells
{
    public class GameController //meny, "Länk" till alla spel o menyval, skriver ut o läser från console mha ui
	{
		private HighScore highscores;
		private CowsAndBulls cowsAndBulls;
		private IUI ui;
		string userName { get; set; }
		string menuChoice { get; set; }
		public GameController(CowsAndBulls cab, IUI ui, HighScore highscores)
		{
			cowsAndBulls= cab;
			this.ui= ui;
			this.highscores = highscores;
			userName="";
			menuChoice="";
		}
		public void Menu()
		{
			bool ShowMenu = true;
			ui.PrintToConsole("\tEnter your user name:\n\t");
			userName = ui.ReadFromConsole();

			while (ShowMenu)
			{
				ui.ClearConsole();
				ui.PrintToConsole($"\n\tWelcome {userName}! \n\tChoose what to play\n\t[1] CowsAndBulls&Bulls \n\t[2] Second Game\n\t[E] Exit");
				menuChoice = ui.ReadFromConsole();
				HandleMenuChoice();
				if (menuChoice.ToUpper()== "E") ui.ExitConsole();
			}
		}
		public void HandleMenuChoice()
		{
			bool continuePlaying = true; //fortsätt spela
			if (menuChoice=="1")
			{
				while (continuePlaying)
				{
					int gameResult = cowsAndBulls.RunGame();
					highscores.AddHighScore(userName, gameResult);
					highscores.PrintHighScores();
					ui.PrintToConsole("New game [y]\tBack to Menu [M]");
					if (ui.ReadFromConsole() == "m" ||ui.ReadFromConsole() == "M") continuePlaying= false;
				}
			}
			if (menuChoice=="2")
			{
				while (continuePlaying) { }
			}

		}

	}
}

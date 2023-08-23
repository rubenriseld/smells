using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells
{
	public class GameController //meny, "Länk" till alla spel o menyval, skriver ut o läser från console mha ui
	{
		private HighScore highscores;
		private CowsAndBulls cowsAndBulls;
		private IUI ui;
		public GameController(CowsAndBulls cab, IUI ui, HighScore highscores)
		{
			cowsAndBulls= cab;
			this.ui= ui;
			this.highscores = highscores;
		}

		string userName;
		string menuChoice;
		public void Menu()
		{
			bool ShowMenu = true;
			ui.PrintToConsole("\tEnter your user name:\n\t");
			userName = ui.ReadFromConsole();

			while (ShowMenu)
			{
				ui.PrintToConsole($"\n\tWelcome {userName}! \n\tChoose what to play\n\t[1] Cows&Bulls \n\t[2] Second Game\n\t[E] Exit");
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
					highscores.AddHighScore(userName,gameResult);
					highscores.PrintHighScores();
					ui.PrintToConsole("New game [y]\n\nBack to Menu [M]");
					if (ui.ReadFromConsole() == "m".ToUpper()) continuePlaying= false;
				}
			}
			if (menuChoice=="2")
			{
				while (continuePlaying) { }
			}

		}

	}
}

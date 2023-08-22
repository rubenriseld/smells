using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells
{
	public class UI
	{
		string userName;
		string menuChoice;
		CowsAndBulls cowsandbulls = new CowsAndBulls();
		public void Menu()
		{
			bool ShowMenu = true;
			Console.Write("\tEnter your user name:\n\t");
			userName = Console.ReadLine();

			while (ShowMenu)
			{
				Console.WriteLine($"\n\tWelcome {userName}! \n\tChoose what to play\n\t[1] Cows&Bulls \n\t[2] Second Game\n\t[E] Exit");
				menuChoice = Console.ReadLine();
				HandleMenuChoice();
				if (menuChoice== "E") ShowMenu= false;
			}
		}
		public void HandleMenuChoice()
		{
			bool continuePlaying = true; //fortsätt spela
			if (menuChoice=="1")
			{
				while (continuePlaying)
				{
					cowsandbulls.RunCowsAndBulls(userName);
					Console.WriteLine("New game? y/n\n\nBack to Menu [M]");
					if (Console.ReadLine() == "M") continuePlaying= false;
				}
			}
			if (menuChoice=="2")
			{
				while (continuePlaying) { }
			}

		}
		public void PrintHighScores()
		{

		}
	}
}

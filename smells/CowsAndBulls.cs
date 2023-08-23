using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells
{
	public class CowsAndBulls : IGame
	{
		string numbersToGuess;
		string userGuess;
		private IUI ui;
		public CowsAndBulls()
		{
			ui = new UI();
		}
		public int RunGame()
		{
			numbersToGuess = GenerateNumbersToGuess();
			ui.PrintToConsole("New game: \n");
			ui.PrintToConsole("For practice, number is: " + numbersToGuess + "\n");
			userGuess = ui.ReadFromConsole();
			int numberOfGuesses = 1;
			string currentGuessResult = HandleUserGuess();
			ui.PrintToConsole(currentGuessResult + "\n");

			string correctGuessResult = "BBBB,";
			while (currentGuessResult != correctGuessResult)
			{
				numberOfGuesses++;
				userGuess = ui.ReadFromConsole();
				ui.PrintToConsole(userGuess + "\n");
				currentGuessResult = HandleUserGuess();
				ui.PrintToConsole(currentGuessResult + "\n");
			}

			ui.PrintToConsole("Correct, it took " + numberOfGuesses + " guesses\n");
			return numberOfGuesses;

		}
		public string GenerateNumbersToGuess()
		{
			Random numberGenerator = new Random();
			string numbersToGuess = "";
			for (int i = 0; i < 4; i++)
			{
				int newNumber = numberGenerator.Next(10); //upp till 10??
				string newNumberValue = "" + newNumber; //för att kolla om samma siffra redan valts
				while (numbersToGuess.Contains(newNumberValue)) //så länge random siffran redan finns hämta ny siffra
				{
					newNumber = numberGenerator.Next(10);
					newNumberValue = "" + newNumber;
				}
				numbersToGuess = numbersToGuess + newNumberValue; //utöka goal me ny siffra
			}
			return numbersToGuess;
		}

		public string HandleUserGuess()
		{
			int numberOfBulls = 0;
			int numberOfCows = 0;
			userGuess += "    "; //if player entered less than 4 chars
			for (int correctNumber = 0; correctNumber < 4; correctNumber++)
			{
				for (int guessedNumber = 0; guessedNumber < 4; guessedNumber++)
				{
					if (numbersToGuess[correctNumber] == userGuess[guessedNumber])
					{
						if (correctNumber == guessedNumber)
						{
							numberOfBulls++;
						}
						else
						{
							numberOfCows++;
						}
					}
				}
			}
			return "BBBB".Substring(0, numberOfBulls) + "," + "CCCC".Substring(0, numberOfCows);
		}


		public void ShowHighscores()
		{

		}
	}
}

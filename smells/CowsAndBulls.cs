using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smells;

namespace smells
{
	public class CowsAndBulls
	{
		public void RunCowsAndBulls(string userName)
		{
			string numbersToGuess = GenerateNumbersToGuess();
			Console.WriteLine("New game: \n");
			Console.WriteLine("For practice, number is: " + numbersToGuess + "\n");
			string userGuess = Console.ReadLine();
			int numberOfGuesses = 1;
			string currentGuessResult = HandleUserGuess(numbersToGuess, userGuess);
			Console.WriteLine(currentGuessResult + "\n");

			string correctGuessResult = "BBBB,";
			while (currentGuessResult != correctGuessResult)
			{
				numberOfGuesses++;
				userGuess = Console.ReadLine();
				Console.WriteLine(userGuess + "\n");
				currentGuessResult = HandleUserGuess(numbersToGuess, userGuess);
				Console.WriteLine(currentGuessResult + "\n");
			}
			Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\n");
			HighScore hs = new HighScore();
			hs.AddHighScore(userName, numberOfGuesses);
			hs.PrintHighScores();
		}
		static string GenerateNumbersToGuess() //siffran som ska gissas
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
		static string HandleUserGuess(string numbersToGuess, string userGuess)
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
	}
}

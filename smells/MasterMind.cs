using smells.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells
{
	public class MasterMind : IGame
	{
		string numbersToGuess;
		string userGuess;
		public string Name { get; set; }
		public HighScore highscore { get; set; }
		public MasterMind()
		{
			highscore = new HighScore("HighScoresMM");
		}
		public void RunGame(string userName)
		{
			numbersToGuess = GenerateNumbersToGuess(); //4 siffror
			Console.WriteLine(numbersToGuess);
			Console.WriteLine("[1] [2] [3] [4] [5] [6]");
			userGuess = Console.ReadLine();
			Console.WriteLine(HandleUserGuess());

		}
		public string GenerateNumbersToGuess()
		{
			Random numberGenerator = new Random();
			string numbersToGuess = "";
			for (int i = 0; i < 4; i++)
			{
				numbersToGuess += numberGenerator.Next(6).ToString();
			}

			return numbersToGuess;
		}

		public string HandleUserGuess()
		{
			int correctGuessAndPlace = 0;
			int correctGuess = 0;
			userGuess += "    ";
			for (int correctNumber = 0; correctNumber < 4; correctNumber++)
			{
				for (int guessedNumber = 0; guessedNumber < 4; guessedNumber++)
				{
					if (numbersToGuess[correctNumber] == userGuess[guessedNumber])
					{
						if (correctNumber == guessedNumber)
						{
							correctGuessAndPlace++;
						}
						else
						{
							correctGuess++;
						}
					}
				}
			}
			return "****".Substring(0, correctGuessAndPlace) + "," + "????".Substring(0, correctGuess);
		}

	}
}

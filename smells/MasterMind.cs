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
			List<GameProgressData> gameBoard = new List<GameProgressData>();
			numbersToGuess = GenerateNumbersToGuess(); //4 siffror
			Console.WriteLine(numbersToGuess);
			int numberOfGuesses = 0;
			Console.WriteLine("[*** M A S T E R  M I N D ***]");

			for (int i = 0; i < 12; i++)
			{
				userGuess = Console.ReadLine();
				string correct = HandleUserGuess();

				if (correct == "****")
				{
					i = 12;
				}
				gameBoard.Add(new GameProgressData(userGuess, correct));
				if (userGuess == numbersToGuess) { i = 12; }
				PrintProgress(gameBoard);
				
			}
			highscore.AddHighScore(userName, numberOfGuesses);
			highscore.PrintHighScores();

		}
		public void PrintProgress(List<GameProgressData> data)
		{
			Console.Clear();
			foreach (var item in data)
			{
				Console.WriteLine(string.Format("|{0,2}|{1,4}|{2,4}|{3,4}|{4,4}|", item.UserGuess[0], item.UserGuess[1], item.UserGuess[2], item.UserGuess[3], item.UserGuessResult));
			}
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
			int correctGuessWrongPlace = 0;
			userGuess += "    ";
			int loopCount = 0;
			foreach (var number in numbersToGuess)
			{
				if (userGuess.Contains(number))
				{
					if (number == userGuess[loopCount])
					{
						correctGuessAndPlace++;
					}
					else
					{
						correctGuessWrongPlace++;
					}
				}
				loopCount++;
			}
			return "****".Substring(0, correctGuessAndPlace) + "????".Substring(0, correctGuessWrongPlace);
		}

	}
}

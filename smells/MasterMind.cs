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
		public IUI _ui { get; set; }
		public string Name { get; set; }
		public HighScore HighScore { get; set; }
		public MasterMind()
		{
			Name ="Mastermind";
			HighScore = new HighScore(Name);
		}
		public void AddUserInterface(IUI ui)
		{
			_ui = ui;
		}
		public void RunGame(string userName)
		{
			numbersToGuess = GenerateNumbersToGuess(); //4 siffror
			GameProgressData[] gameBoard = CreateGameBoard();
			PrintProgress(gameBoard);
			_ui.Output(numbersToGuess);
			string msg = $"Too bad :c The correct numbers are : {numbersToGuess}";
			int numberOfGuesses = 0;
			for (int i = 0; i < 12; i++)
			{
				userGuess = _ui.Input();
				gameBoard[i] = new GameProgressData().CreateData(userGuess, HandleUserGuess());
				PrintProgress(gameBoard);
				if (HandleUserGuess() == "****")
				{
					msg = $"Good Job! It took you {numberOfGuesses+1} try!";
					i = 12;
				}

				numberOfGuesses++;


			}
			_ui.Output(msg);
			HighScore.AddHighScore(userName, numberOfGuesses);
			_ui.Output(HighScore.PrintHighScores());

		}
		public GameProgressData[] CreateGameBoard()
		{
			GameProgressData gameProgressData = new GameProgressData();
			GameProgressData[] gameBoard = new GameProgressData[12];

			for (int i = 0; i < 12; i++)
			{
				gameBoard[i] = gameProgressData.CreateData("    ", " ");
			}
			return gameBoard;
		}
		public void PrintProgress(GameProgressData[] data)
		{
			Console.Clear();
			Console.WriteLine("[   MASTERMIND  ]\n-----------------");
			Console.WriteLine("[Choose from 1-6]\n-----------------");
			for (int i = 0; i < data.Length; i++)
			{
				Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} | {4} ", data[i].UserGuess[0], data[i].UserGuess[1], data[i].UserGuess[2], data[i].UserGuess[3], data[i].UserGuessResult));
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

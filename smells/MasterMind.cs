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
		string NumbersToGuess;
		string UserGuess;
		public string Name { get; set; }
		public HighScore HighScore { get; set; }
		public IUI UserInterface { get; set; }

		public MasterMind()
		{
			Name = "Mastermind";
			HighScore = new HighScore(Name);
		}
		public void AddUserInterface(IUI userInterface)
		{
			this.UserInterface = userInterface;
		}
		public void RunGame(string userName)
		{
			NumbersToGuess = GenerateNumbersToGuess(); //4 siffror
			GameProgressData[] gameBoard = CreateGameBoard();
			PrintProgress(gameBoard);
			UserInterface.Output(NumbersToGuess);
			string msg = $"Too bad :c The correct numbers are : {NumbersToGuess}";
			int numberOfGuesses = 0;
			for (int i = 0; i < 12; i++)
			{
				UserGuess = UserInterface.Input();
				gameBoard[i] = new GameProgressData().CreateData(UserGuess, HandleUserGuess());
				PrintProgress(gameBoard);
				if (HandleUserGuess() == "****")
				{
					msg = $"Good Job! It took you {numberOfGuesses+1} try!";
					i = 12;
				}
				numberOfGuesses++;
			}
			UserInterface.Output(msg);
			HighScore.AddHighScore(userName, numberOfGuesses);
			UserInterface.Output(HighScore.PrintHighScores());
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
			UserInterface.Clear();
			UserInterface.Output("[   MASTERMIND  ]\n-----------------");
			UserInterface.Output("[Choose from 1-6]\n-----------------");
			for (int i = 0; i < data.Length; i++)
			{
				UserInterface.Output(string.Format("| {0} | {1} | {2} | {3} | {4} ", data[i].UserGuess[0], data[i].UserGuess[1], data[i].UserGuess[2], data[i].UserGuess[3], data[i].UserGuessResult));
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
			UserGuess += "    ";
			int loopCount = 0;
			foreach (var number in NumbersToGuess)
			{
				if (UserGuess.Contains(number))
				{
					if (number == UserGuess[loopCount])
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
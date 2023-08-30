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

		private GameProgressData[] GameBoard;

		private int NumberOfGuesses;

		private string GameResultMessage;

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
			GameBoard = CreateGameBoard();
			UpdateGameBoard();
			UserInterface.Output(NumbersToGuess);
			PrintGameProgress();
			RegisterHighScore(userName);
			ShowHighScore();
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
		public void UpdateGameBoard()
		{
			UserInterface.Clear();
			UserInterface.Output("[   MASTERMIND  ]\n-----------------\n[Choose from 1-6]\n-----------------");
			for (int i = 0; i < GameBoard.Length; i++)
			{
				UserInterface.Output(string.Format("| {0} | {1} | {2} | {3} | {4} ", GameBoard[i].UserGuess[0], GameBoard[i].UserGuess[1], GameBoard[i].UserGuess[2], GameBoard[i].UserGuess[3], GameBoard[i].UserGuessResult));
			}
		}
		public void PrintGameProgress()
		{
			GameResultMessage = $"Too bad :c The correct numbers are : {NumbersToGuess}";
			NumberOfGuesses = 0;
			for (int i = 0; i < 12; i++)
			{
				UserGuess = UserInterface.Input();
				GameBoard[i] = new GameProgressData().CreateData(UserGuess, HandleUserGuess());
				UpdateGameBoard();
				if (HandleUserGuess() == "****")
				{
					GameResultMessage = $"Good Job! Amount of guesses you won with: {NumberOfGuesses+1}";
					i = 12;
				}
				NumberOfGuesses++;
			}
			UserInterface.Output(GameResultMessage);
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
		public void RegisterHighScore(string userName)
		{
			HighScore.AddHighScore(userName, NumberOfGuesses);

		}
		public void ShowHighScore()
		{
			UserInterface.Output(HighScore.PrintHighScores());
		}

	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smells.Interfaces;

namespace smells
{
    public class CowsAndBulls : IGame
	{
		string numbersToGuess;
		string userGuess;
        public HighScore highscore { get; set; }

        public string Name { get; set; }

        private IUI _ui;
		public CowsAndBulls(IUI ui)
		{
			_ui = ui;
            Name = "Cows and Bulls";
            highscore = new HighScore("HighScoresCAB");

        }
        public void RunGame(string userName)
		{
			numbersToGuess = GenerateNumbersToGuess();
			_ui.Output("New game: \n");
			_ui.Output($"For practice, number is: {numbersToGuess}\n");
			userGuess = _ui.Input();
			int numberOfGuesses = 1;
			string currentGuessResult = HandleUserGuess();
			_ui.Output($"{currentGuessResult}\n");

			string correctGuessResult = "BBBB,";
			while (currentGuessResult != correctGuessResult)
			{
				numberOfGuesses++;
				userGuess = _ui.Input();
				//_ui.Output($"\n {userGuess}");
				currentGuessResult = HandleUserGuess();
				_ui.Output($"{currentGuessResult}\n");
			}
			highscore.AddHighScore(userName, numberOfGuesses);
			_ui.Output("\nCorrect, it took " + numberOfGuesses + " guesses!\n");
			_ui.Output(highscore.PrintHighScores());
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

	}
}

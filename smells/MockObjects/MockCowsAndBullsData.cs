using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smells.Games;

namespace smells.MockObjects
{
    public class MockCowsAndBullsData
	{
		string GeneratedNumbers { get; set;}
		public  MockCowsAndBullsData(string mockGeneratedNumber)
		{
			GeneratedNumbers = mockGeneratedNumber;
		}
		public string HandleUserGuess(string userGuess)
		{
			int numberOfBulls = 0;
			int numberOfCows = 0;
			userGuess += "    "; 
			for (int correctNumber = 0; correctNumber < 4; correctNumber++)
			{
				for (int guessedNumber = 0; guessedNumber < 4; guessedNumber++)
				{
					if (GeneratedNumbers[correctNumber] == userGuess[guessedNumber])
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
		public bool GenerateDuplicateNumbers()
		{
			CowsAndBulls cowsAndBulls = new CowsAndBulls();
			int duplicateCounter = 0;
			string numbersToGuess = cowsAndBulls.GenerateNumbersToGuess();
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (numbersToGuess[i] == numbersToGuess[j] && j!= i)
					{
						duplicateCounter++;
					}
				}
			}
			if (duplicateCounter == 0) return false;
			else return true;
		}

	}
}
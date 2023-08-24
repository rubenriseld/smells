using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells.MockObjects
{
	public class MockCowsAndBullsData
	{
		string generatedNumbers = "5278";

		public string HandleUserGuess(string userGuess)
		{
			int numberOfBulls = 0;
			int numberOfCows = 0;
			userGuess += "    "; //if player entered less than 4 chars
			for (int correctNumber = 0; correctNumber < 4; correctNumber++)
			{
				for (int guessedNumber = 0; guessedNumber < 4; guessedNumber++)
				{
					if (generatedNumbers[correctNumber] == userGuess[guessedNumber])
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

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
			userGuess += "    "; 
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
		//public string RunGame(string userGuess)
		//{

		//	return "";
		//}
		public string GenerateNumbersToGuess()
		{
			int[] faultyGeneratedNumbers = { 5, 5, 3, 7};
			string numbersToGuess = "";
			for (int i = 0; i < 4; i++)
			{
				int newNumber = faultyGeneratedNumbers[i];
				string newNumberValue = "" + newNumber.ToString(); 
				while (numbersToGuess.Contains(newNumberValue))
				{
					newNumber = faultyGeneratedNumbers[i] + 1;
					newNumberValue = "" + newNumber.ToString();
				}
				numbersToGuess = numbersToGuess + newNumberValue; 
			}
			return numbersToGuess;
		}

	}
}

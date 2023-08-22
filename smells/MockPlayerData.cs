using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells
{
	public class MockPlayerData :IPlayerData
	{
		public string Name {get;set;
}		public int NumberOfGames { get; set; }
		int numberOfGuesses;
		public MockPlayerData()
		{
			Name = "user1";
			NumberOfGames = 3;
			numberOfGuesses = 15;
		}

		public void Update(int guesses) => throw new NotImplementedException();
		
		public int UpdateGuesses(int guesses)
		{
			numberOfGuesses += guesses;
			return numberOfGuesses;
		}
		public int UpdateNumberOfGames()
		{
			NumberOfGames++;
			return NumberOfGames;
		}

		public double Average()
		{
			return (double)numberOfGuesses/NumberOfGames;
		}
	}
}

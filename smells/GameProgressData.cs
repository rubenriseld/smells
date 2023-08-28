using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells
{
	public class GameProgressData
	{
		public string UserGuess { get; set; }
		public string UserGuessResult { get; set; }
		//public GameProgressData(string userGuess, string userGuessResult)
		//{
		//	UserGuess=userGuess;
		//	UserGuessResult=userGuessResult;
		//}
		public GameProgressData CreateData(string userGuess, string userGuessResult)
		{
			UserGuess= userGuess;
			UserGuessResult= userGuessResult;
			return this;
		}

	}
}

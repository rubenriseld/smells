using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells
{
	internal interface IGame
	{
		int RunGame();
		string GenerateNumbersToGuess();
		string HandleUserGuess();
	}
}

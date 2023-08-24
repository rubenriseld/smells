using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells.Interfaces
{
    internal interface IGame
    {
        void RunGame(string userName);
        string GenerateNumbersToGuess();
        string HandleUserGuess();
        HighScore highscore { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells.Interfaces
{
    public interface IGame
    {
        int RunGame();
        string Name { get; set; }
        string GenerateNumbersToGuess();
        string HandleUserGuess();
        //HighScore highscore();
    }
}

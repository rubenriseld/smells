using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells.Interfaces
{
    public interface IGame
    {
        string Name { get; set; }
        void RunGame(string userName);
        HighScore highscore { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells.Interfaces;

public interface IGame
{
    IUI _ui { set; }
    string Name { get; set; }
    HighScore highscore { get; set; }
    void AddUserInterface(IUI ui);
    void RunGame(string userName);
}

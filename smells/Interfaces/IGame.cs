using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells.Interfaces;

public interface IGame
{
    IUI UserInterface { set; }
    HighScore HighScore { set; }
    string Name { get; set; }
    void AddUserInterface(IUI ui);
    void RunGame(string userName);
}

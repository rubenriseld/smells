using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells.Interfaces;

public interface IPlayerData
{
    string Name { get; }
    int NumberOfGames { get; }
    public void Update(int guesses);
    public double Average();
}

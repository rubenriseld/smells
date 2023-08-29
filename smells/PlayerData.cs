using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smells.Interfaces;

namespace smells;

public class PlayerData : IPlayerData
{
    public string Name { get; private set; }
    public int NumberOfGames { get; private set; }
    int TotalGuesses;
    public PlayerData(string name, int guesses)
    {
        Name = name;
        NumberOfGames = 1;
        this.TotalGuesses = guesses;
    }
    public void Update(int guesses)
    {
        TotalGuesses += guesses;
        NumberOfGames++;
    }
    public double Average()
    {
        return (double)TotalGuesses / NumberOfGames;
    }
    public override bool Equals(Object p)
    {
        return Name.Equals(((PlayerData)p).Name);
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}


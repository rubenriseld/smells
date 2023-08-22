using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells
{
	public class PlayerData : IPlayerData
	{		
			public string Name { get;  private set; }
			public int NumberOfGames { get; private set; }
			int totalGuesses;
			public PlayerData(string name, int guesses)
			{
				Name = name;
				NumberOfGames = 1;
				this.totalGuesses = guesses;
			}
			public void Update(int guesses)
			{
				totalGuesses += guesses;
				NumberOfGames++;
			}
			public double Average()
			{
				return (double)totalGuesses / NumberOfGames;
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
	}


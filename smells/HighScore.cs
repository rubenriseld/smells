using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smells.Interfaces;
using static System.Formats.Asn1.AsnWriter;

namespace smells
{
    public class HighScore
	{
		IUI ui;
		public HighScore()
		{
			ui = new UI();
		}
		public void AddHighScore(string userName, int numberOfGuesses)
		{
			StreamWriter streamWriter = new StreamWriter("HighScores.txt", append: true);
			streamWriter.WriteLine(userName + "#&#" + numberOfGuesses);
			streamWriter.Close();

		}
		public void PrintHighScores()
		{
			List<PlayerData> playerHighScores = GetHighScores("Highscores");		
			playerHighScores.Sort((player1, player2) => player1.Average().CompareTo(player2.Average()));
			ui.PrintToConsole("Player\t\t  Games\t  Avarage\n\t______\t\t  _____\t  _______");
			foreach (PlayerData player in playerHighScores)
			{
				ui.PrintToConsole(string.Format("{0, -9}\t{1,5:D}\t{2,9:F2}", player.Name, player.NumberOfGames, player.Average()));
			}
			ui.PrintToConsole("_________________________________");
		}
		public List<PlayerData> GetHighScores(string game)
		{
			

			StreamReader streamReader = new StreamReader($"{game}.txt");
			List<PlayerData> playerHighScores = new List<PlayerData>();
			string line;
			while ((line = streamReader.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int score = Convert.ToInt32(nameAndScore[1]);
				PlayerData playerData = new PlayerData(name, score);
				int position = playerHighScores.IndexOf(playerData);
				if (position< 0)
				{
					playerHighScores.Add(playerData);
				}
				else
				{
					playerHighScores[position].Update(score);
				}
			}
			streamReader.Close();
			return playerHighScores;
		}

	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace smells
{
	public class HighScore
	{
		StreamReader streamReader;
		StreamWriter streamWriter;
		public void AddHighScore(string userName, int numberOfGuesses)
		{
			streamWriter = new StreamWriter("HighScores.txt", append: true);
			streamWriter.WriteLine(userName + "#&#" + numberOfGuesses);
		}
        public void ShowHighScores()
        {
		StreamReader streamReader = new StreamReader("HighScores.txt");
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
			playerHighScores.Sort((player1, player2) => player1.Avarage().CompareTo(player2.Avarage()));
			Console.WriteLine("Player   games avarage");
			foreach (PlayerData player in playerHighScores)
			{
				Console.WriteLine(string.Format("{0, -9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.Avarage()));
			}
			streamReader.Close();
		}
		public int ShowHowManyGames()
		{
			return 2;
		}

	}
	}


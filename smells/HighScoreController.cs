using System;
using System.Collections.Generic;
using smells.Data;
using smells.Interfaces;

namespace smells;

public class HighScoreController : IHighScoreController
{
    public string GameName { get; set; }
    private List<IPlayerData> PlayerData = new List<IPlayerData>();
    public void AddHighScore(string userName, int score)
    {
        StreamWriter streamWriter = new StreamWriter($"{GameName}.txt", append: true);
        streamWriter.WriteLine(userName + "#&#" + score);
        streamWriter.Close();
    }
    public string CreateHighScoreTable()
    {
        PlayerData.Clear(); 
        GetHighScore();
        PlayerData.Sort((player1, player2) => player1.GetAverageOfTotalScore().CompareTo(player2.GetAverageOfTotalScore()));
        string highScores = ("Player\t\tGames\tAverage\n------\t\t-----\t--------");
        foreach (PlayerData player in PlayerData)
        {
            highScores += (string.Format("\n{0}\t\t{1}\t{2:F2}", player.Name, player.TotalGamesPlayed, player.GetAverageOfTotalScore()));
        }
        highScores += ("\n--------------------------------");
        return highScores;
    }
    public void GetHighScore()
    {
        StreamReader streamReader = new StreamReader($"{GameName}.txt");
        string line;
        while ((line = streamReader.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int score = Convert.ToInt32(nameAndScore[1]);
            PlayerData playerData = new PlayerData(name, score);
            int position = PlayerData.IndexOf(playerData);
            if (position < 0)
            {
                PlayerData.Add(playerData);
            }
            else
            {
                PlayerData[position].AddToTotalScore(score);
            }
        }
        streamReader.Close();

    }
    public void SetCurrentGameName(string gameName) {
        GameName = gameName;
    }
}
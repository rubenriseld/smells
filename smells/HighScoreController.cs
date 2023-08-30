using System;
using System.Collections.Generic;
using smells.Interfaces;

namespace smells;

public class HighScoreController : IHighScoreController
{
    //string TxtFile { get; set; }
    private List<PlayerData> PlayerData = new List<PlayerData>();
    public void AddHighScore(string gameName, string userName, int numberOfGuesses)
    {
        StreamWriter streamWriter = new StreamWriter($"{gameName}.txt", append: true);
        streamWriter.WriteLine(userName + "#&#" + numberOfGuesses);
        streamWriter.Close();
    }
    public string PrintHighScore(string gameName)
    {
        PlayerData.Clear(); 
        GetHighScore(gameName);
        PlayerData.Sort((player1, player2) => player1.Average().CompareTo(player2.Average()));
        string highScoreList = ("Player\t\tGames\tAverage\n------\t\t-----\t--------");
        foreach (PlayerData player in PlayerData)
        {
            //highScoreList += (string.Format("\n{0, -9}\t{1,5:D}\t{2,9:F2}", player.Name, player.NumberOfGames, player.Average()));
            highScoreList += (string.Format("\n{0}\t\t{1}\t{2:F2}", player.Name, player.NumberOfGames, player.Average()));
        }
        highScoreList += ("\n--------------------------------");
        return highScoreList;
    }
    public void GetHighScore(string gameName)
    {
        StreamReader streamReader = new StreamReader($"{gameName}.txt");
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
                PlayerData[position].Update(score);
            }
        }
        streamReader.Close();

    }
}
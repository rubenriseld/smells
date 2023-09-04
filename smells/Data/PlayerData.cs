using smells.Interfaces;

namespace smells.Data;

public class PlayerData : IPlayerData
{
    public string Name { get; private set; }
    public int TotalGamesPlayed { get; private set; }
    int TotalScore;
    public PlayerData(string name, int score)
    {
        Name = name;
        TotalGamesPlayed = 1;
        TotalScore = score;
    }
    public void AddToTotalScore(int score)
    {
        TotalScore += score;
        IncreaseNumberOfGamesByOne();
    }
    public void IncreaseNumberOfGamesByOne()
    {
        TotalGamesPlayed++;
    }
    public double GetAverageOfTotalScore()
    {
        return (double)TotalScore / TotalGamesPlayed;
    }
    public override bool Equals(object p)
    {
        return Name.Equals(((PlayerData)p).Name);
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}


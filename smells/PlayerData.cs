using smells.Interfaces;

namespace smells;

public class PlayerData : IPlayerData
{
    public string Name { get; private set; }
    public int NumberOfGames { get; private set; }
    int TotalScore;
    public PlayerData(string name, int score)
    {
        Name = name;
        NumberOfGames = 1;
        this.TotalScore = score;
    }
    public void Update(int score)
    {
        TotalScore += score;
        NumberOfGames++;
    }
    public double Average()
    {
        return (double)TotalScore / NumberOfGames;
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


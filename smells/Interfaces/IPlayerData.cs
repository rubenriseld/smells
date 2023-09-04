namespace smells.Interfaces
{
    public interface IPlayerData
    {
        string Name { get; }
        int TotalGamesPlayed { get; }

        void AddToTotalScore(int score);
        bool Equals(object p);
        double GetAverageOfTotalScore();
        int GetHashCode();
        void IncreaseNumberOfGamesByOne();
    }
}
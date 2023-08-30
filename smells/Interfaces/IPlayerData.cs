namespace smells.Interfaces;

public interface IPlayerData
{
    string Name { get; }
    int NumberOfGames { get; }
    public void Update(int guesses);
    public double Average();
}

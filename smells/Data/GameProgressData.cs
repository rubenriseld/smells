namespace smells.Data;
public class GameProgressData
{
    public string UserGuess { get; set; }
    public string UserGuessResult { get; set; }
    public GameProgressData CreateData(string userGuess, string userGuessResult)
    {
        UserGuess = userGuess;
        UserGuessResult = userGuessResult;
        return this;
    }

}

namespace smells.Interfaces;

public interface IHighScoreController
{
	void AddHighScore(string gameName,string userName, int numberOfGuesses);
	void GetHighScore(string gameName);
	string PrintHighScore(string gameName);
}
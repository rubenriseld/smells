namespace smells.Interfaces;

public interface IHighScoreController
{
	string GameName { get; set; }
	void AddHighScore(string userName, int score);
	void GetHighScore();
	string CreateHighScoreTable();
	void SetCurrentGameName(string gameName);
}
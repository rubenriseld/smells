using smells.Interfaces;

namespace smells;

public class MasterMind : IGame
{
	string NumbersToGuess;
	string UserGuess;
	public string Name { get; set; }
	public IUI UserInterface { get; set; }

	private GameProgressData[] GameBoard;

	private int NumberOfGuesses;

	private string GameResultMessage;

	public MasterMind()
	{
		Name = "Mastermind";
	}
	public void AddUserInterface(IUI userInterface)
	{
		this.UserInterface = userInterface;
	}
	public int Start()
	{
		NumbersToGuess = GenerateNumbersToGuess();
		GameBoard = CreateGameBoard();
		UpdateGameBoard();
		UserInterface.Output(NumbersToGuess);
		PrintGameProgress();
		return NumberOfGuesses;
	}
	public string GenerateNumbersToGuess()
	{
		Random numberGenerator = new Random();
		string numbersToGuess = "";
		for (int i = 0; i < 4; i++)
		{
			numbersToGuess += (numberGenerator.Next(6) + 1).ToString();
		}
		return numbersToGuess;
	}
	public GameProgressData[] CreateGameBoard()
	{
		GameProgressData gameProgressData = new GameProgressData();
		GameProgressData[] gameBoard = new GameProgressData[12];
		for (int i = 0; i < 12; i++)
		{
			gameBoard[i] = gameProgressData.CreateData("    ", " ");
		}
		return gameBoard;
	}
	public void UpdateGameBoard()
	{
		UserInterface.Clear();
		UserInterface.Output("[   MASTERMIND  ]\n-----------------\n[Choose from 1-6]\n-----------------");
		for (int i = 0; i < GameBoard.Length; i++)
		{
			UserInterface.Output(string.Format("| {0} | {1} | {2} | {3} | {4} ", GameBoard[i].UserGuess[0], GameBoard[i].UserGuess[1], GameBoard[i].UserGuess[2], GameBoard[i].UserGuess[3], GameBoard[i].UserGuessResult));
		}
		UserInterface.Output(NumbersToGuess);

	}
	public void PrintGameProgress()
	{
		GameResultMessage = $"Too bad :c The correct numbers are : {NumbersToGuess}";
		NumberOfGuesses = 0;
		for (int i = 0; i < 12; i++)
		{
			UserGuess = UserInterface.Input();

			while (UserGuess.Count() < 4 || !UserGuess.All(char.IsDigit))
			{
				UserInterface.Output("[Use 4 digits]");
				UserGuess = UserInterface.Input();
			}
			GameBoard[i] = new GameProgressData().CreateData(UserGuess, HandleUserGuess());
			UpdateGameBoard();
			if (HandleUserGuess() == "****")
			{
				GameResultMessage = $"Good Job! Amount of guesses you won with: {NumberOfGuesses + 1}";
				i = 12;
			}
			NumberOfGuesses++;
		}
		UserInterface.Output(GameResultMessage);
	}
	public string HandleUserGuess()
	{
		int correctGuessAndPlace = 0;
		int correctGuessWrongPlace = 0;
		UserGuess += "    ";

		//dictionaries for storing numbers that have been checked to see if they match,
		//and avoid using them for matching with multiple numbers (gives misleading guess results)
		Dictionary<(int, char), bool> checkedUserGuess = new Dictionary<(int, char), bool>();
		for (int i = 0; i < 4; i++)
		{
			checkedUserGuess.Add((i, UserGuess[i]), false);
		}
		Dictionary<(int, char), bool> checkedNumbersToGuess = new Dictionary<(int, char), bool>();
		for (int i = 0; i < 4; i++)
		{
			checkedNumbersToGuess.Add((i, NumbersToGuess[i]), false);
		}


		//check for matching numbers that are in the CORRECT place
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (NumbersToGuess[i] == UserGuess[j])
				{
					if (i == j && checkedNumbersToGuess[(i, NumbersToGuess[i])] == false && checkedUserGuess[(j, UserGuess[j])] == false)
					{
						correctGuessAndPlace++;
						checkedNumbersToGuess[(i, NumbersToGuess[i])] = true;
						checkedUserGuess[(j, UserGuess[j])] = true;
						//UserInterface.Output("correctGuessAndPlace " + correctGuessAndPlace.ToString() + "i:" + i + " j: " + j);
					}
				}
			}
		}

		//check for matching numbers that are in the INCORRECT place
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (NumbersToGuess[i] == UserGuess[j])
				{
					if (checkedNumbersToGuess[(i, NumbersToGuess[i])] == false && checkedUserGuess[(j, UserGuess[j])] == false)
					{
						correctGuessWrongPlace++;
						checkedNumbersToGuess[(i, NumbersToGuess[i])] = true;
						checkedUserGuess[(j, UserGuess[j])] = true;
						//UserInterface.Output("correctGuessWrongPlace " + correctGuessWrongPlace.ToString() + "i:" + i + " j: " + j);
					}
				}
			}
		}
		return "****".Substring(0, correctGuessAndPlace) + "????".Substring(0, correctGuessWrongPlace);
	}
}
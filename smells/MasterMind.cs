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
	public int RunGame()
	{
		NumbersToGuess = GenerateNumbersToGuess(); //4 siffror
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
	}
	public void PrintGameProgress()
	{
		GameResultMessage = $"Too bad :c The correct numbers are : {NumbersToGuess}";
		NumberOfGuesses = 0;
		for (int i = 0; i < 12; i++)
		{
			UserGuess = UserInterface.Input();
			while (UserGuess.Count() < 4)
			{
				if (UserGuess.Count() < 4)
				{
					UserInterface.Output("invalid guess");
					UserGuess = UserInterface.Input();
				}
			}
			GameBoard[i] = new GameProgressData().CreateData(UserGuess, HandleUserGuess());
			UpdateGameBoard();
			if (HandleUserGuess() == "****")
			{
				GameResultMessage = $"Good Job! Amount of guesses you won with: {NumberOfGuesses+1}";
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
		List<char> numbersInCorrectPlace = new List<char>(); //bra där

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (NumbersToGuess[i] == UserGuess[j])
                    {
					if (i == j)
					{
						correctGuessAndPlace++;
						numbersInCorrectPlace.Add(UserGuess[j]);
                        }
                        else if (NumbersToGuess.Contains(UserGuess[j]) && !numbersInCorrectPlace.Contains(UserGuess[j]))
                        {
							correctGuessWrongPlace++;

                        }
                    }
                }
            }
            return "****".Substring(0, correctGuessAndPlace) + "????".Substring(0, correctGuessWrongPlace);
	}
}
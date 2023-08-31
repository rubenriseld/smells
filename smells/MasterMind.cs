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
        //List<char> checkedNumbers = new List<char>();
        List<char> correct = new List<char>();

        //try
        //{

        //	for (int i = 0; i < 4; i++)
        //	{
        //		for (int j = 0; j < 4; j++)
        //		{
        //			if (NumbersToGuess[i] == UserGuess[j])
        //			{
        //				if (i == j)
        //				{
        //					correctGuessAndPlace++;
        //					checkedNumbers.Add(NumbersToGuess[i]);
        //					correct.Add(UserGuess[j]);
        //					checkedNumbers.Add(UserGuess[j]);
        //					UserInterface.Output("correctGuessAndPlace " +correctGuessAndPlace.ToString() + "i:" + i + " j: " + j);
        //				}
        //				else if (NumbersToGuess.Contains(UserGuess[j]) && !correct.Contains(UserGuess[j]) ||
        //						NumbersToGuess.Contains(UserGuess[j]) && correct.Contains(UserGuess[j]) && !checkedNumbers.Contains(UserGuess[j]))
        //				{
        //					correctGuessWrongPlace++;
        //					//checkedNumbers.Add(NumbersToGuess[i]);
        //					//checkedNumbers[UserGuess[j]] = true;

        //					UserInterface.Output("correctGuessWrongPlace " + correctGuessWrongPlace.ToString() + "i:" + i + " j: " + j);

        //				}
        //			}
        //		}
        //	}
        //}
        //catch (Exception e)
        //{
        //	UserInterface.Output(e.ToString());
        //}

        //om siffra finns i ToGuess och är på rätt plats ++rätt ++rätttlista
        //om siffra finns i ToGuess och är INTE på rätt plats inte finns i rättlista cows++
        //om siffra finns i ToGuess och är INTE på rätt plats och FINNS i rättlista cows++

        //array[2: false, 3: false, 2:true]

        //Dictionary << Tuple<int, char>, bool> checkedNumbers = new Dictionary<Tuple<int, char>, bool>();
        //for (int i = 0; i < 4; i++)
        //{
        //    checkedNumbers.Add( { Convert.ToChar(i), UserGuess[i]}, false);
        ////??
        ////add.(char number, bool false
        //}

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




   //     int loop = 0;
   //     foreach (var checkd in checkedNumbersToGuess)
   //     {
   //         if (checkd.Value.Equals(UserGuess[loop]))    
   //         {
			//	(checkd.Value.K) = false;
			//}
   //         else
   //         {
   //             correctGuessWrongPlace++;
   //         }
   //         loop++;
   //     }

        //checked numbers har siffran o e false - siffran finns i toGuess o e rätt, kör true

        //foreach (var number in UserGuess)
        //{
        //	for (int i = 0; i < 4; i++)
        //	{
        //		if (number== NumbersToGuess[i] && checkedNumbers[(i, UserGuess[i])] == false)
        //		{
        //			checkedNumbers[(i, UserGuess[i])] = true;
        //			correct.Add(number);
        //			correctGuessAndPlace++;
        //			UserInterface.Output("correctGuessAndPlace " + correctGuessAndPlace.ToString() + "i:" + i + " j: " + number);

        //		}
        //              else if (NumbersToGuess.Contains(number) && !correct.Contains(number) && checkedNumbers[(i, UserGuess[i])] == false)
        //		{
        //			checkedNumbers[(i, UserGuess[i])]= true;
        //			correctGuessWrongPlace++;
        //			UserInterface.Output("correctGuessWrongPlace " + correctGuessWrongPlace.ToString() + "i:" + i + " j: " + j);

        //		}

        //          }
        //}
        //return "****".Substring(0, correctGuessAndPlace) + "????".Substring(0, correctGuessWrongPlace);
        //foreach (var item in checkedNumbers)
        //{
        //    UserInterface.Output(item.ToString());
        //}
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

                        UserInterface.Output("correctGuessAndPlace " + correctGuessAndPlace.ToString() + "i:" + i + " j: " + j);
                    }
                    else if (checkedNumbersToGuess[(i, NumbersToGuess[i])] == false && checkedUserGuess[(j, UserGuess[j])] == false)
					{
                        correctGuessWrongPlace++;
                        UserInterface.Output("correctGuessWrongPlace " + correctGuessWrongPlace.ToString() + "i:" + i + " j: " + j);
                        //checkedNumbers[(j, UserGuess[j])] = true;
                        checkedNumbersToGuess[(i, NumbersToGuess[i])] = true;
                        checkedUserGuess[(j, UserGuess[j])] = true;



                    }
                }
            }
        }
		return "****".Substring(0, correctGuessAndPlace) + "????".Substring(0, correctGuessWrongPlace);
    }
	
}


    //            if (NumbersToGuess[i] == UserGuess[j])
    //{
    //	if (i == j && checkedNumbers[(j, UserGuess[j])] == false)
    //	{
    //		correctGuessAndPlace++;
    //		checkedNumbers[(j, UserGuess[j])] = true;
    //		UserInterface.Output("correctGuessAndPlace " + correctGuessAndPlace.ToString() + "i:" + i + " j: " + j);
    //	}
    //	else if (NumbersToGuess.Contains(UserGuess[j]) &&
    //		checkedNumbers[(j, UserGuess[j])] == false
    //		)
    //	{
    //		correctGuessWrongPlace++;
    //		//checkedNumbers.Add(NumbersToGuess[i]);
    //		//checkedNumbers[UserGuess[j]] = true;
    //		checkedNumbers[(j, UserGuess[j])] = true;


    //		UserInterface.Output("correctGuessWrongPlace " + correctGuessWrongPlace.ToString() + "i:" + i + " j: " + j);

    //	}
    //}

//        try
//        {
//    return "****".Substring(0, correctGuessAndPlace) + "????".Substring(0, correctGuessWrongPlace);

//}
//catch (Exception e)
//{
//    return e.ToString();
//}
//	}
//}

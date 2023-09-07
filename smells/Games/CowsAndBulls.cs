using smells.Interfaces;

namespace smells.Games;

public class CowsAndBulls : IGame
{
    string NumbersToGuess;
    string UserGuess;
    public IUI UserInterface { get; set; }
    public string Name { get; set; }
    private int NumberOfGuesses;

    public CowsAndBulls()
    {
        Name = "Cows and Bulls";
    }
    public void AddUserInterface(IUI userInterface)
    {
        UserInterface = userInterface;
    }
    public int Start()
    {
        UserInterface.Clear();
        UserInterface.Output("New game: \n");
        NumbersToGuess = GenerateNumbersToGuess();
        UserInterface.Output($"For practice, number is: {NumbersToGuess}\n");
        PrintGameProgress();
        return NumberOfGuesses;
    }
    public void PrintGameProgress()
    {
        NumberOfGuesses = 0;
        string currentGuessResult = "";
        string correctGuessResult = "BBBB,";
        while (currentGuessResult != correctGuessResult)
        {
            UserGuess = UserInterface.Input();
            while (UserGuess.Count() != 4 || !UserGuess.All(char.IsDigit))
            {
                UserInterface.Output("[Please enter 4 numbers]\n");
                UserGuess = UserInterface.Input();

            }
            NumberOfGuesses++;
            currentGuessResult = HandleUserGuess();
            UserInterface.Output($"{currentGuessResult}\n");
        }
        UserInterface.Output("Correct, it took " + NumberOfGuesses + " guesses!\n");
    }

    public string GenerateNumbersToGuess()
    {
        Random numberGenerator = new Random();
        string numbersToGuess = "";
        for (int i = 0; i < 4; i++)
        {
            int newNumber = numberGenerator.Next(10);
            string newNumberValue = "" + newNumber;
            while (numbersToGuess.Contains(newNumberValue))
            {
                newNumber = numberGenerator.Next(10);
                newNumberValue = "" + newNumber;
            }
            numbersToGuess = numbersToGuess + newNumberValue;
        }
        return numbersToGuess;
    }
    public string HandleUserGuess()
    {
        int numberOfBulls = 0;
        int numberOfCows = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (NumbersToGuess[i] == UserGuess[j])
                {
                    if (i == j)
                    {
                        numberOfBulls++;
                    }
                    else
                    {
                        numberOfCows++;
                    }
                }
            }
        }
        return "BBBB".Substring(0, numberOfBulls) + "," + "CCCC".Substring(0, numberOfCows);
    }
}
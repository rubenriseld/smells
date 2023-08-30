using smells.Interfaces;

namespace smells;

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
        this.UserInterface = userInterface;
    }
    public int RunGame()
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
        UserGuess = UserInterface.Input();
        NumberOfGuesses = 1;
        string currentGuessResult = HandleUserGuess();
        UserInterface.Output($"{currentGuessResult}\n");
         
        string correctGuessResult = "BBBB,";
        while (currentGuessResult != correctGuessResult)
        {
			NumberOfGuesses++;
            UserGuess = UserInterface.Input();
            currentGuessResult = HandleUserGuess();
            UserInterface.Output($"{currentGuessResult}\n");
        }
        UserInterface.Output("\nCorrect, it took " + NumberOfGuesses + " guesses!\n");
    }

	public string GenerateNumbersToGuess()
    {
        Random numberGenerator = new Random();
        string numbersToGuess = "";
        for (int i = 0; i < 4; i++)
        {
            int newNumber = numberGenerator.Next(10); //upp till 10??
            string newNumberValue = "" + newNumber; //för att kolla om samma siffra redan valts
            while (numbersToGuess.Contains(newNumberValue)) //så länge random siffran redan finns hämta ny siffra
            {
                newNumber = numberGenerator.Next(10);
                newNumberValue = "" + newNumber;
            }
            numbersToGuess = numbersToGuess + newNumberValue; //utöka goal me ny siffra
        }
        return numbersToGuess;
    }

    public string HandleUserGuess()
    {
        int numberOfBulls = 0;
        int numberOfCows = 0;
        UserGuess += "    "; //if player entered less than 4 chars
        for (int correctNumber = 0; correctNumber < 4; correctNumber++)
        {
            for (int guessedNumber = 0; guessedNumber < 4; guessedNumber++)
            {
                if (NumbersToGuess[correctNumber] == UserGuess[guessedNumber])
                {
                    if (correctNumber == guessedNumber)
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
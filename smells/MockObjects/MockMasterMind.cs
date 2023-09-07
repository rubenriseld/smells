using smells.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells.MockObjects;

public class MockMasterMind
{
    string NumbersToGuess;
    public MockMasterMind(string MockNumbersToGuess)
    {
        NumbersToGuess = MockNumbersToGuess;
    }

    public string HandleUserGuess(string userGuess)
    {
        int correctGuessAndPlace = 0;
        int correctGuessWrongPlace = 0;

        //dictionaries for storing numbers that have been checked to see if they match,
        //and avoid using them for matching with multiple numbers (gives misleading guess results)
        Dictionary<(int, char), bool> checkedUserGuess = new Dictionary<(int, char), bool>();
        for (int i = 0; i < 4; i++)
        {
            checkedUserGuess.Add((i, userGuess[i]), false);
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
                if (NumbersToGuess[i] == userGuess[j])
                {
                    if (i == j && checkedNumbersToGuess[(i, NumbersToGuess[i])] == false && checkedUserGuess[(j, userGuess[j])] == false)
                    {
                        correctGuessAndPlace++;
                        checkedNumbersToGuess[(i, NumbersToGuess[i])] = true;
                        checkedUserGuess[(j, userGuess[j])] = true;
                    }
                }
            }
        }

        //check for matching numbers that are in the INCORRECT place
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (NumbersToGuess[i] == userGuess[j])
                {
                    if (checkedNumbersToGuess[(i, NumbersToGuess[i])] == false && checkedUserGuess[(j, userGuess[j])] == false)
                    {
                        correctGuessWrongPlace++;
                        checkedNumbersToGuess[(i, NumbersToGuess[i])] = true;
                        checkedUserGuess[(j, userGuess[j])] = true;
                    }
                }
            }
        }
        return "****".Substring(0, correctGuessAndPlace) + "????".Substring(0, correctGuessWrongPlace);
    }
}
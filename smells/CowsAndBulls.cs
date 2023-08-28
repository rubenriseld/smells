﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smells.Interfaces;

namespace smells;

public class CowsAndBulls : IGame
{
    public IUI _ui { get; set; }
    public string Name { get; set; }
    public HighScore HighScore { get; set; }

    string? numbersToGuess;
    string? userGuess;

    public CowsAndBulls()
    {
        Name = "Cows and Bulls";
        HighScore = new HighScore(Name);
    }

    public void AddUserInterface(IUI ui)
    {
        _ui = ui;
    }
    public void RunGame(string userName)
    {
        numbersToGuess = GenerateNumbersToGuess();
        _ui.Output("New game: \n");
        _ui.Output($"For practice, number is: {numbersToGuess}\n");
        userGuess = _ui.Input();
        int numberOfGuesses = 1;
        string currentGuessResult = HandleUserGuess();
        _ui.Output($"{currentGuessResult}\n");

        string correctGuessResult = "BBBB,";
        while (currentGuessResult != correctGuessResult)
        {
            numberOfGuesses++;
            userGuess = _ui.Input();
            currentGuessResult = HandleUserGuess();
            _ui.Output($"{currentGuessResult}\n");
        }
        HighScore.AddHighScore(userName, numberOfGuesses);
        _ui.Output("\nCorrect, it took " + numberOfGuesses + " guesses!\n");
        _ui.Output(HighScore.PrintHighScores());
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
        userGuess += "    "; //if player entered less than 4 chars
        for (int correctNumber = 0; correctNumber < 4; correctNumber++)
        {
            for (int guessedNumber = 0; guessedNumber < 4; guessedNumber++)
            {
                if (numbersToGuess[correctNumber] == userGuess[guessedNumber])
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
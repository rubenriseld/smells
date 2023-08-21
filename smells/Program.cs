﻿using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame;

class MainClass
{
	public static void Main(string[] args)
	{

		bool continuePlaying = true; //fortsätt spela
		Console.WriteLine("Enter your user name:\n");
		string userName = Console.ReadLine();

		while (continuePlaying)
		{
			string numbersToGuess = GenerateNumbersToGuess(); //skapa siffra som ska gissas
			Console.WriteLine("New game: \n");
			Console.WriteLine("For practice, number is: " + numbersToGuess + "\n");
			string userGuess = Console.ReadLine();

			int numberOfGuesses = 1;
			string currentGuessResult = HandleUserGuess(numbersToGuess, userGuess);
			Console.WriteLine(currentGuessResult + "\n");

			string correctGuessResult = "BBBB,";
			while (currentGuessResult != correctGuessResult)
			{
				numberOfGuesses++;
				userGuess = Console.ReadLine();
				Console.WriteLine(userGuess + "\n");
				currentGuessResult = HandleUserGuess(numbersToGuess, userGuess);
				Console.WriteLine(currentGuessResult + "\n");
			}

			StreamReader sr = new StreamReader("HighScores.txt");
			string line;
			while ((line = sr.ReadLine()) != null)
			{

				
				if (line.Contains(userName))
				{

					string[] old = line.Split("#&#");
					int n = Convert.ToInt32(old[1]) + numberOfGuesses;
					Console.WriteLine(n);
				}
			}
			sr.Close();
			//StreamWriter output = new StreamWriter("HighScores.txt", append: true);




			//output.WriteLine(userName + "#&#" + numberOfGuesses);


			//output.Close();
			ShowHighScores();
			Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
			string answer = Console.ReadLine();
			if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
			{
				continuePlaying = false;
			}
		}

		static string GenerateNumbersToGuess() //siffran som ska gissas
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

		static string HandleUserGuess(string numbersToGuess, string userGuess)
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
		static void ShowHighScores()
		{
			StreamReader streamReader = new StreamReader("HighScores.txt"); //hämta data från textfil me "scores"
			List<PlayerData> playerHighScores = new List<PlayerData>();
			string line; //
			while ((line = streamReader.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int score = Convert.ToInt32(nameAndScore[1]);

				//for each name count updatePlayedGames
				PlayerData playerData = new PlayerData(name, score);
				int position = playerHighScores.IndexOf(playerData);
				if (position < 0)
				{
					playerHighScores.Add(playerData);
				}
				else
				{
					playerHighScores[position].Update(score);
				}
			}
			playerHighScores.Sort((player1, player2) => player1.Avarage().CompareTo(player2.Avarage()));
			Console.WriteLine("Player   games avarage");
			foreach (PlayerData player in playerHighScores)
			{
				Console.WriteLine(string.Format("{0, -9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.Avarage()));
			}
			streamReader.Close();
		}
	}
	class PlayerData
	{
		public string Name { get; private set; }
		public int NumberOfGames { get; private set; }
		int totalGuesses;
		public PlayerData(string name, int guesses)
		{
			Name = name;
			NumberOfGames = 1;
			this.totalGuesses = guesses;
		}
		public void Update(int guesses)
		{
			totalGuesses += guesses;

		}
		public double Avarage()
		{
			return (double)totalGuesses / NumberOfGames;
		}
		public void UpdateNumberOfGames()
		{
			NumberOfGames++;
		}
		//public override bool Equals(Object p)
		//{
		//	return Name.Equals(((PlayerData)p).Name);
		//}
		//public override int GetHashCode()
		//{
		//	return Name.GetHashCode();
		//}
	}
}

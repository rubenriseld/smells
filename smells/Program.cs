using System;
using System.IO;
using System.Collections.Generic;
using smells;

namespace MooGame;

class MainClass
{
	public static void Main(string[] args)
	{
		UI userInterface = new UI();
		userInterface.Menu();
		
		
		
		
		
		//bool BackToMenu = true;

		//Console.WriteLine("Enter your user name:\n");
		//string userName = Console.ReadLine();
		//CowsAndBulls cowsBulls = new CowsAndBulls();
		//while (BackToMenu)
		//{
		//	bool continuePlaying = true; //fortsätt spela
		//	Console.WriteLine("Choose what to play\n\t[1] Cows&Bulls \n\t[2] Second Game\n\t[E] Exit");
		//	string menuChoice =Console.ReadLine();
		//	if (menuChoice=="1")
		//	{

		//	}
		//	switch (menuChoice)
		//	{
		//		case "1":
		//			while (continuePlaying)
		//			{
		//				cowsBulls.RunCowsAndBulls(userName);
		//				Console.WriteLine("New game? y/n\n\nBack to Menu [M]");
		//				if (Console.ReadLine() == "M") continuePlaying= false;
		//			}
		//			break;
		//		case "2":
		//			break;
		//		case "E":
		//			BackToMenu= false;
		//			break;
		//	}



			//string numbersToGuess = GenerateNumbersToGuess(); //skapa siffra som ska gissas
			//Console.WriteLine("New game: \n");
			//Console.WriteLine("For practice, number is: " + numbersToGuess + "\n");
			//string userGuess = Console.ReadLine();

			//int numberOfGuesses = 1;
			//string currentGuessResult = HandleUserGuess(numbersToGuess, userGuess);
			//Console.WriteLine(currentGuessResult + "\n");

			//string correctGuessResult = "BBBB,";
			//while (currentGuessResult != correctGuessResult)
			//{
			//	numberOfGuesses++;
			//	userGuess = Console.ReadLine();
			//	Console.WriteLine(userGuess + "\n");
			//	currentGuessResult = HandleUserGuess(numbersToGuess, userGuess);
			//	Console.WriteLine(currentGuessResult + "\n");
			//}
			//StreamWriter output = new StreamWriter("HighScores.txt", append: true);
			//output.WriteLine(userName + "#&#" + numberOfGuesses);
			//output.Close();
			//ShowHighScores();
			//Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
			//string answer = Console.ReadLine();
			//if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
			//{
			//	continuePlaying = false;
			//}
		}

		//static void CowsAndBulls()
		//{
		//	string numbersToGuess = GenerateNumbersToGuess(); //skapa siffra som ska gissas
		//	Console.WriteLine("New game: \n");
		//	Console.WriteLine("For practice, number is: " + numbersToGuess + "\n");
		//	string userGuess = Console.ReadLine();

		//	int numberOfGuesses = 1;
		//	string currentGuessResult = HandleUserGuess(numbersToGuess, userGuess);
		//	Console.WriteLine(currentGuessResult + "\n");

		//	string correctGuessResult = "BBBB,";
		//	while (currentGuessResult != correctGuessResult)
		//	{
		//		numberOfGuesses++;
		//		userGuess = Console.ReadLine();
		//		Console.WriteLine(userGuess + "\n");
		//		currentGuessResult = HandleUserGuess(numbersToGuess, userGuess);
		//		Console.WriteLine(currentGuessResult + "\n");
		//	}
		//	StreamWriter output = new StreamWriter("HighScores.txt", append: true);
		//	output.WriteLine(userName + "#&#" + numberOfGuesses);
		//	output.Close();
		//	ShowHighScores();
		//	Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
		//	string answer = Console.ReadLine();
		//}
		//static string GenerateNumbersToGuess() //siffran som ska gissas
		//{
		//	Random numberGenerator = new Random();
		//	string numbersToGuess = "";
		//	for (int i = 0; i < 4; i++)
		//	{
		//		int newNumber = numberGenerator.Next(10); //upp till 10??
		//		string newNumberValue = "" + newNumber; //för att kolla om samma siffra redan valts
		//		while (numbersToGuess.Contains(newNumberValue)) //så länge random siffran redan finns hämta ny siffra
		//		{
		//			newNumber = numberGenerator.Next(10);
		//			newNumberValue = "" + newNumber;
		//		}
		//		numbersToGuess = numbersToGuess + newNumberValue; //utöka goal me ny siffra
		//	}
		//	return numbersToGuess;
		//}

		//static string HandleUserGuess(string numbersToGuess, string userGuess)
		//{
		//	int numberOfBulls = 0;
		//	int numberOfCows = 0;
		//	userGuess += "    "; //if player entered less than 4 chars
		//	for (int correctNumber = 0; correctNumber < 4; correctNumber++)
		//	{
		//		for (int guessedNumber = 0; guessedNumber < 4; guessedNumber++)
		//		{
		//			if (numbersToGuess[correctNumber] == userGuess[guessedNumber])
		//			{
		//				if (correctNumber == guessedNumber)
		//				{
		//					numberOfBulls++;
		//				}
		//				else
		//				{
		//					numberOfCows++;
		//				}
		//			}
		//		}
		//	}
		//	return "BBBB".Substring(0, numberOfBulls) + "," + "CCCC".Substring(0, numberOfCows);
		//}
		//	static void ShowHighScores()
		//	{


		//		StreamReader streamReader = new StreamReader("HighScores.txt"); //hämta data från textfil me "scores"
		//		List<PlayerData> playerHighScores = new List<PlayerData>();
		//		string line; //
		//		while ((line = streamReader.ReadLine()) != null)
		//		{
		//			string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
		//			string name = nameAndScore[0];
		//			int score = Convert.ToInt32(nameAndScore[1]);
		//			PlayerData playerData = new PlayerData(name, score);
		//			int position = playerHighScores.IndexOf(playerData);
		//			if (position < 0)
		//			{
		//				playerHighScores.Add(playerData);
		//			}
		//			else
		//			{
		//				playerHighScores[position].Update(score);
		//			}
		//		}
		//		playerHighScores.Sort((player1, player2) => player1.Average().CompareTo(player2.Average()));
		//		Console.WriteLine("Player  games avarage");
		//		foreach (PlayerData player in playerHighScores)
		//		{
		//			Console.WriteLine(string.Format("{0, -9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.Average()));
		//		}
		//		streamReader.Close();
		//	}
		//}
		//class PlayerData
		//{
		//	public string Name { get; private set; }
		//	public int NumberOfGames { get; private set; }
		//	int totalGuesses;
		//	public PlayerData(string name, int guesses)
		//	{
		//		Name = name;
		//		NumberOfGames = 1;
		//		this.totalGuesses = guesses;
		//	}
		//	public void Update(int guesses)
		//	{
		//		totalGuesses += guesses;
		//		NumberOfGames++;
		//	}
		//	public double Average()
		//	{
		//		return (double)totalGuesses / NumberOfGames;
		//	}
		//	public override bool Equals(Object p)//tillsammans me indexOf
		//	{
		//		return Name.Equals(((PlayerData)p).Name); 
		//	}
		//	public override int GetHashCode()  //här highscore "summering"? kolla me sebbeboii
		//	{
		//		return Name.GetHashCode();
		//	}
		//}
	}


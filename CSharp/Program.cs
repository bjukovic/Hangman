using System;
using System.Collections.Generic;
using System.IO;

class Hangman
{
    static int totalScore = 0;
    const string ScoreFileName = "scores.txt";

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. View Score");
            Console.WriteLine("3. View All Scores");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter your choice: ");

            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    StartGame();
                    break;
                case "2":
                    ViewScore();
                    break;
                case "3":
                    ViewAllScores();
                    break;
                case "4":
                    Console.WriteLine("Thank you for playing Hangman! Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void StartGame()
    {
        var categories = new Dictionary<int, (string Name, string[] Words)>
        {
            { 1, ("Animals", new[] { "lion", "elephant", "giraffe", "dolphin", "penguin", "tiger", "kangaroo", "panda", "eagle" }) },
            { 2, ("Countries", new[] { "germany", "iceland", "egypt", "france", "brazil", "japan", "canada", "italy", "australia" }) },
            { 3, ("Food", new[] { "pancakes", "cookies", "pizza", "burger", "sushi", "tacos", "pasta", "salad", "steak", "burek" }) },
            { 4, ("Sports", new[] { "football", "tennis", "cricket", "basketball", "baseball", "swimming", "volleyball", "hockey" }) }
        };

        Console.Clear();
        Console.WriteLine("Choose a category:");
        foreach (var category in categories)
        {
            Console.WriteLine($"{category.Key}. {category.Value.Name}");
        }

        int chosenCategoryKey = 0;
        while (true)
        {
            Console.Write("\nEnter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out chosenCategoryKey) && categories.ContainsKey(chosenCategoryKey))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid number.");
            }
        }

        var (categoryName, words) = categories[chosenCategoryKey];
        Random random = new Random();
        string wordToGuess = words[random.Next(words.Length)];
        char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();
        HashSet<char> guessedLetters = new HashSet<char>();

        int maxAttempts = 6;
        int attempts = 0;
        bool wordGuessed = false;

        Console.WriteLine($"\nYou selected the category: {categoryName}");
        Console.WriteLine("Let's start the game!");

        while (attempts < maxAttempts && !wordGuessed)
        {
            Console.Clear();
            DisplayHangman(attempts);
            Console.WriteLine($"\nCategory: {categoryName}");
            Console.WriteLine("\nWord: " + new string(guessedWord));
            Console.WriteLine("Attempts left: " + (maxAttempts - attempts));
            Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters));
            Console.Write("Guess a letter: ");

            string input = Console.ReadLine()?.ToLower();
            if (string.IsNullOrEmpty(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                Console.WriteLine("Please enter a single valid letter.");
                Console.ReadKey();
                continue;
            }

            char guessedLetter = input[0];
            if (guessedLetters.Contains(guessedLetter))
            {
                Console.WriteLine("You've already guessed that letter.");
                Console.ReadKey();
                continue;
            }

            guessedLetters.Add(guessedLetter);

            if (wordToGuess.Contains(guessedLetter))
            {
                Console.WriteLine("Correct guess!");
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guessedLetter)
                    {
                        guessedWord[i] = guessedLetter;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong guess!");
                attempts++;
            }

            wordGuessed = new string(guessedWord) == wordToGuess;
        }

        Console.Clear();
        DisplayHangman(attempts);
        if (wordGuessed)
        {
            int roundScore = Math.Max(10 - attempts, 0);
            Console.WriteLine("\nCongratulations! You've guessed the word: " + wordToGuess);
            Console.WriteLine($"You earned {roundScore} points this round.");
            totalScore += roundScore;

            Console.Write("\nWould you like to save your score? Yes (y) or no (n): ");
            string saveChoice = Console.ReadLine()?.Trim().ToLower();
            if (saveChoice == "y")
            {
                SaveScore(roundScore);
                Console.WriteLine("Score saved successfully!");
            }
        }
        else
        {
            Console.WriteLine("\nGame over! The word was: " + wordToGuess);
        }
        Console.WriteLine("\nPress any key to return to the main menu.");
        Console.ReadKey();
    }

    static void ViewScore()
    {
        Console.Clear();
        Console.WriteLine($"Your total score is: {totalScore}");
        Console.WriteLine("\nPress any key to return to the main menu.");
        Console.ReadKey();
    }

    static void ViewAllScores()
    {
        Console.Clear();
        Console.WriteLine("All Scores:");
        if (File.Exists(ScoreFileName))
        {
            string[] allScores = File.ReadAllLines(ScoreFileName);
            foreach (var line in allScores)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("No scores recorded yet.");
        }
        Console.WriteLine("\nPress any key to return to the main menu.");
        Console.ReadKey();
    }

    static void SaveScore(int roundScore)
    {
        Console.Write("Enter your name: ");
        string playerName = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(playerName))
        {
            string scoreEntry = $"{playerName}: {roundScore} points";
            File.AppendAllText(ScoreFileName, scoreEntry + Environment.NewLine);
        }
        else
        {
            Console.WriteLine("Score not saved. Name cannot be empty.");
        }
    }

    static void DisplayHangman(int attempts)
    {
        string[] hangmanStages = new string[]
        {
            @"
     +---+
     |   |
         |
         |
         |
         |
  =========",
            @"
     +---+
     |   |
     O   |
         |
         |
         |
  =========",
            @"
     +---+
     |   |
     O   |
     |   |
         |
         |
  =========",
            @"
     +---+
     |   |
     O   |
    /|   |
         |
         |
  =========",
            @"
     +---+
     |   |
     O   |
    /|\  |
         |
         |
  =========",
            @"
     +---+
     |   |
     O   |
    /|\  |
    /    |
         |
  =========",
            @"
     +---+
     |   |
     O   |
    /|\  |
    / \  |
         |
  ========="
        };

        Console.WriteLine(hangmanStages[attempts]);
    }
}



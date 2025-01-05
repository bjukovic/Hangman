const readlineSync = require('readline-sync');
const fs = require('fs');

let totalScore = 0;
const ScoreFileName = 'scores.txt';

function main() {
    while (true) {
        console.clear();
        console.log("Welcome to Hangman!");
        console.log("1. Start Game");
        console.log("2. View Score");
        console.log("3. View All Scores");
        console.log("4. Exit");
        
        const choice = prompt("\nEnter your choice: ").trim();

        switch (choice) {
            case "1":
                startGame();
                break;
            case "2":
                viewScore();
                break;
            case "3":
                viewAllScores();
                break;
            case "4":
                console.log("Thank you for playing Hangman! Goodbye!");
                return;
            default:
                console.log("Invalid choice. Please select 1, 2, 3, or 4.");
                prompt("Press Enter to continue...");
                break;
        }
    }
}

function startGame() {
    const categories = {
        1: { name: "Animals", words: ["lion", "elephant", "giraffe", "dolphin", "penguin", "tiger", "kangaroo", "panda", "eagle"] },
        2: { name: "Countries", words: ["germany", "iceland", "egypt", "france", "brazil", "japan", "canada", "italy", "australia"] },
        3: { name: "Food", words: ["pancakes", "cookies", "pizza", "burger", "sushi", "tacos", "pasta", "salad", "steak", "burek"] },
        4: { name: "Sports", words: ["football", "tennis", "cricket", "basketball", "baseball", "swimming", "volleyball", "hockey"] }
    };

    console.clear();
    console.log("Choose a category:");
    for (const key in categories) {
        console.log(`${key}. ${categories[key].name}`);
    }

    let chosenCategoryKey;
    while (true) {
        chosenCategoryKey = parseInt(prompt("\nEnter the number of your choice: ").trim());
        if (!isNaN(chosenCategoryKey) && categories[chosenCategoryKey]) {
            break;
        } else {
            console.log("Invalid choice. Please enter a valid number.");
        }
    }

    const category = categories[chosenCategoryKey];
    const wordToGuess = category.words[Math.floor(Math.random() * category.words.length)];
    let guessedWord = Array(wordToGuess.length).fill('_');
    let guessedLetters = new Set();
    const maxAttempts = 6;
    let attempts = 0;

    console.log(`\nYou selected the category: ${category.name}`);
    console.log("Let's start the game!");

    while (attempts < maxAttempts && guessedWord.join('') !== wordToGuess) {
        console.clear();
        displayHangman(attempts);
        console.log(`\nCategory: ${category.name}`);
        console.log(`\nWord: ${guessedWord.join(' ')}`);
        console.log(`Attempts left: ${maxAttempts - attempts}`);
        console.log(`Guessed letters: ${Array.from(guessedLetters).join(', ')}`);
        
        const input = prompt("Guess a letter: ").toLowerCase();
        if (!input || input.length !== 1 || !/[a-z]/.test(input)) {
            console.log("Please enter a single valid letter.");
            prompt("Press Enter to continue...");
            continue;
        }

        if (guessedLetters.has(input)) {
            console.log("You've already guessed that letter.");
            prompt("Press Enter to continue...");
            continue;
        }

        guessedLetters.add(input);

        if (wordToGuess.includes(input)) {
            for (let i = 0; i < wordToGuess.length; i++) {
                if (wordToGuess[i] === input) {
                    guessedWord[i] = input;
                }
            }
        } else {
            attempts++;
        }
    }

    console.clear();
    displayHangman(attempts);
    if (guessedWord.join('') === wordToGuess) {
        const roundScore = Math.max(10 - attempts, 0);
        console.log(`\nCongratulations! You've guessed the word: ${wordToGuess}`);
        console.log(`You earned ${roundScore} points this round.`);
        totalScore += roundScore;

        if (prompt("\nWould you like to save your score? (y/n): ").toLowerCase() === 'y') {
            saveScore(roundScore);
            console.log("Score saved successfully!");
        }
    } else {
        console.log(`\nGame over! The word was: ${wordToGuess}`);
    }
    prompt("\nPress Enter to return to the main menu.");
}

function viewScore() {
    console.clear();
    console.log(`Your total score is: ${totalScore}`);
    prompt("\nPress Enter to return to the main menu.");
}

function viewAllScores() {
    console.clear();
    console.log("All Scores:");
    if (fs.existsSync(ScoreFileName)) {
        const allScores = fs.readFileSync(ScoreFileName, 'utf8').split('\n');
        allScores.forEach(line => console.log(line));
    } else {
        console.log("No scores recorded yet.");
    }
    prompt("\nPress Enter to return to the main menu.");
}

function saveScore(roundScore) {
    const playerName = prompt("Enter your name: ").trim();
    if (playerName) {
        const scoreEntry = `${playerName}: ${roundScore} points`;
        fs.appendFileSync(ScoreFileName, scoreEntry + '\n');
    } else {
        console.log("Score not saved. Name cannot be empty.");
    }
}

function displayHangman(attempts) {
    const hangmanStages = [
        `
     +---+
     |   |
         |
         |
         |
         |
  =========`,
        `
     +---+
     |   |
     O   |
         |
         |
         |
  =========`,
        `
     +---+
     |   |
     O   |
     |   |
         |
         |
  =========`,
        `
     +---+
     |   |
     O   |
    /|   |
         |
         |
  =========`,
        `
     +---+
     |   |
     O   |
    /|\\  |
         |
         |
  =========`,
        `
     +---+
     |   |
     O   |
    /|\\  |
    /    |
         |
  =========`,
        `
     +---+
     |   |
     O   |
    /|\\  |
    / \\  |
         |
  =========`
    ];
    console.log(hangmanStages[attempts]);
}

function prompt(query) {
    return readlineSync.question(query);
}

main();

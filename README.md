# Hangman Game

This repository consists of three separate implementations of the classic Hangman game in C#, Python, and JavaScript. Each version offers a console-based game where players guess letters to reveal a hidden word within a limited number of attempts. This project demonstrates language-specific approaches to the same game logic, providing a great reference for multi-language programming.


## Table of Contents
- [About the Game](#about-the-game)
- [Project Goals](#project-goals)
- [Features](#features)
- [Getting Started](#getting-started)
- [How to Play](#how-to-play)
- [Project Structure](#project-structure)


## About the Game

**Hangman** is a classic word-guessing game usually played between two or more players. In this game, one player selects a random word, and the other(s) try to guess it by entering individual letters. Each correct guess reveals the letter's position(s) within the word, while each incorrect guess deducts an attempt. The game ends either when the player successfully guesses the entire word or runs out of attempts. The game is called "Hangman" because, traditionally, each incorrect guess adds a part to a drawing of a hanging figure. Once the drawing is complete, representing the loss of all attempts, the player loses the game.

## Project Goals

The main goals of this project are to:
- **Provide a fun, interactive game experience** that can be played from the console.
- **Cross-Language Comparison**: Demonstrate how the same problem can be solved in multiple programming languages, highlighting differences in syntax, structure, and libraries between C#, Python, and JavaScript.
- **Learn through practical work**: This project can help understand programming concepts in a practical way by building a functional game from scratch.  


## Features

- **Cross-platform compatibility**: Playable in C#, Python, and JavaScript.
- **Console-based gameplay**: Simple and interactive game flow via the console.
- **Random word selection**: Each game session selects a new word from a predefined list.
- **Score tracking**: Monitors incorrect attempts and provides feedback.
- **Visual representation**: ASCII-based "hangman" figure to visually indicate progress.

## Getting Started

To run this Hangman game, ensure you have the following prerequisites for each language version:

### C#
   - Install the [.NET SDK](https://dotnet.microsoft.com/download) on your device, you can find all the instructions on the linked site.
   - To verify the installation open the terminal and run the command:
     ```bash
     dotnet --version
     ```
   - If installed correctly, this command should display the installed .NET SDK version.
   - Then navigate to the root folder of the project and execute the application with:
      ```bash
     dotnet run
     ```
  

### Python

- Install **Python 3** on your device (Windows/Mac OS/Linux) to execute Python code. You can find installation guidance and the download link [here](https://www.python.org/downloads/).
-  Confirm the installation by running `python --version` or `python3 --version` in the terminal.
- Navigate to the root directory of the Python project and execute the application with:
   ```bash
   python hangman.py
   ```

### JavaScript

- **Node.js**: Install [Node.js](https://nodejs.org/) for your platform to run the JavaScript version of Hangman. This program is compatible with Node.js v12 or later.
- In the terminal, verify the installation:
  - Open a terminal or command prompt.
  - Run the command:
    ```bash
    node --version
    ```
  - If installed correctly, this command should display the installed Node.js version.
- Install the required `readline-sync` package for this program:
  ```bash
  npm install readline-sync
- Navigate to the root folder of the project where `hangman.js` is located and run the application:
  ```bash
  node hangman.js


Ensure you have the required tools installed for the language you intend to use.



## How to Play

1. The program will select a random word and display it as a series of underscores representing each letter.
2. Guess a letter by entering it into the console.
3. If the guessed letter is in the word, it will be revealed in its correct position(s).
4. If the letter is incorrect, an attempt is deducted. 
5. The game continues until you either guess the word correctly or run out of attempts.

## Project Structure

```
Hangman/
├── CSharp/               # C# implementation 
│   └── hangman.cs    
│   
├── JavaScript/       # JavaScript implementation    
│   └── hangman.js    
│   
└── Python/           # Python implementation 
    └── hangman.py    
```


This project was made for Programming Languages (CS305) in the Fall semester of 2024/2025 academic year.

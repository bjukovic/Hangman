# Hangman Game

This repository consists of three separate implementations of the classic Hangman game in C#, Python, and JavaScript. Each version offers a console-based game where players guess letters to reveal a hidden word within a limited number of attempts. This project demonstrates language-specific approaches to the same game logic, providing a great reference for multi-language programming.


## Table of Contents
- [About the Game](#about-the-game)
- [Features](#features)
- [Implementations](#implementations)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [How to Play](#how-to-play)
  - [Sample Gameplay](#sample-gameplay)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)


## About the Game

**Hangman** is a classic word-guessing game usually played between two or more players. In this game, one player selects a random word, and the other(s) try to guess it by entering individual letters. Each correct guess reveals the letter's position(s) within the word, while each incorrect guess deducts an attempt. The game ends either when the player successfully guesses the entire word or runs out of attempts. The game is called "Hangman" because, traditionally, each incorrect guess adds a part to a drawing of a hanging figure. Once the drawing is complete, representing the loss of all attempts, the player loses the game.

## Features

- **Cross-platform compatibility**: Playable in C#, Python, and JavaScript.
- **Console-based gameplay**: Simple and interactive game flow via the console.
- **Random word selection**: Each game session selects a new word from a predefined list.
- **Score tracking**: Monitors incorrect attempts and provides feedback.
- **Visual representation**: ASCII-based "hangman" figure to visually indicate progress.

## Implementations

 ### Prerequisites

To run this Hangman game, ensure you have the following prerequisites for each language version:

### C#

- **.NET SDK**: Install the [.NET SDK](https://dotnet.microsoft.com/download) for your platform to build and run the C# version of Hangman. This game is compatible with .NET Core 3.1 or later.

### Python

- **Python 3.x**: Download and install [Python 3.x](https://www.python.org/downloads/). You can verify the installation by running `python --version` in your terminal.

### JavaScript

- **Web Browser**: A modern web browser (e.g., Chrome, Firefox, Edge, Safari) that supports JavaScript. Simply open the HTML file (`index.html`) in your browser to start the game.

---

Ensure you have the required tools installed for the language you intend to use. Once everything is set up, follow the instructions in the [Getting Started](#getting-started) section to build and run the game.


- **Visual Studio Code**: [Download and install Visual Studio Code](https://code.visualstudio.com/download)
- **C#**: [.NET SDK](https://dotnet.microsoft.com/download)
- **Python**: [Python 3.x](https://www.python.org/downloads/)
- **JavaScript**: A modern web browser (e.g., Chrome, Firefox)

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/hangman-game.git
   cd hangman-game

2. **Open the project in Visual Studio Code**:
    ```bash
     code .
     ```


#### C# (dotnet)

1. Navigate to the C# folder:
   ```bash
   cd CSharp
   ```
2. Build and run:
   ```bash
   dotnet build
   dotnet run
   ```

#### Python

1. Navigate to the Python folder:
   ```bash
   cd Python
   ```
2. Run the game:
   ```bash
   python hangman.py
   ```

#### JavaScript

1. **Clone the repository**:
   Open a terminal and run the following command to clone the repository to your local machine:
   ```bash
   git clone https://github.com/your-username/hangman-game.git
   cd hangman-game
2. Open the project in **Visual Studio Code**:

3. 

## How to Play

1. The program will select a random word and display it as a series of underscores representing each letter.
2. Guess a letter by entering it into the console.
3. If the guessed letter is in the word, it will be revealed in its correct position(s).
4. If the letter is incorrect, an attempt is deducted. 
5. The game continues until you either guess the word correctly or run out of attempts.

## Project Structure

```
hangman-game/
├── CSharp/          # C# implementation
│   ├── Program.cs
│   └── ...
├── Python/          # Python implementation
│   ├── hangman.py
│   └── ...
└── JavaScript/      # JavaScript implementation
    ├── index.html
    ├── hangman.js
    └── ...
```

## Contributing

Contributions are welcome! If you would like to contribute to this project, please fork the repository and submit a pull request.

This project was made for course Programming Languages CS305 in the Fall semester of 2024/2025 academic year.

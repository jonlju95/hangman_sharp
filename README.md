# Hangman (C#)

## Purpose
A **console-based hangman game** written in C#,
built as part of a programming assignment.

## Features
- Choose a difficulty level before starting.
- Guess either single letters and the full word.
- Validate and clean user input before processing.
- Continue playing rounds until the player chooses to exit.

## Code structure
The project is organized into single-responsibility classes and interfaces:

- **`Program`** - Entry point, starts the game.
- **`HangmanApp`** - Main gameplay loop and overall game flow control.
- **`GameLogic`** - Core game rules and guess checking. Returns a `GuessResult` enum to indicate the outcome.
- **`GameUI`** - Handles all user interaction (input/output) and processes the `GuessResult` enum to show appropriate
  feedback.
    - **`IGameUI`** - Interface defining the methods required for any UI implementation.
- **`GameModel`** - Stores the current game state, including the word to guess, masked word, guesses and remaining
  tries. Only `GameLogic` modifies it, while other classes recieve a read-only copy.
- **`Difficulty`** - Represents difficulty settings, including the name and number of tries.
- **`GuessResult`** - Enum describing guess outcomes (e.g. correct letter, wrong letter, already guessed letter or
  invalid input).
- **`WordProvider`** - Selects a random word.
    - **`IWordProvider`** - Interface defining word selection methods.
- **`Validator`** - Static helper class for:
    - Trimming eventual whitespace from input.
    - Validating that guesses only contain alphabetic characters.

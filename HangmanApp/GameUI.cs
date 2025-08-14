using HangmanApp.Interfaces;
using HangmanApp.Models;

namespace HangmanApp.Utils;

public class GameUI : IGameUI {
    public void ShowWelcome() {
        Console.WriteLine("Welcome to hangman!\n");
    }

    public void DisplayState(string maskedWord, IEnumerable<char> wrongGuesses, int remainingGuesses) {
        Console.Write("Word: ");
        foreach (char letter in maskedWord) {
            Console.Write(letter);
        }

        Console.Write("\nGuessed letters: ");
        foreach (char letter in wrongGuesses) {
            Console.Write(letter + ", ");
        }

        Console.WriteLine($"\nRemaining guesses: {remainingGuesses}");
    }

    public string PromptGuess() {
        Console.Write("\nGuess a letter, or the entire word: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public void ShowWinMessage(string correctWord) {
        Console.Clear();
        Console.WriteLine("You won the game!");
        Console.WriteLine($"The word was: {correctWord}");
    }

    public void ShowLoseMessage(string correctWord) {
        Console.Clear();
        Console.WriteLine("You lose!");
        Console.WriteLine($"The word was: {correctWord}");
    }

    public void ShowGuessFeedback(GuessResult result) {
        switch (result) {
            case GuessResult.CorrectLetter:
            case GuessResult.CorrectWord:
                ShowCorrectGuessMessage();
                break;
            case GuessResult.IncorrectLetter:
            case GuessResult.IncorrectWord:
                ShowIncorrectGuessMessage();
                break;
            case GuessResult.AlreadyGuessed:
                ShowAlreadyGuessedMessage();
                break;
            default:
                ShowInvalidInputMessage();
                break;
        }
    }

    public bool PromptPlayAgain() {
        Console.Write("\nPlay again? (y/n): ");
        return Console.ReadKey().KeyChar == 'y' || Console.ReadKey().KeyChar == 'Y';
    }

    public Difficulty SelectDifficulty() {
        Dictionary<string, int> difficulty = new Dictionary<string, int>() {
            { "Hard", 5 },
            { "Normal", 10 },
            { "Easy", 20 },
        };

        Console.WriteLine("Choose difficulty: ");

        int menuItemNumber = 1;
        foreach ((string key, int value) in difficulty) {
            Console.Write($"[{menuItemNumber++}] - {key}, {value} rounds\n");
        }

        Console.Write("\nOption: ");
        string difficultyChoice = Console.ReadKey().KeyChar switch {
            '1' => "Hard",
            '2' => "Normal",
            '3' => "Easy",
            _ => "Normal"
        };

        return new Difficulty(difficultyChoice, difficulty[difficultyChoice]);
    }

    private static void ShowCorrectGuessMessage() {
        Console.Clear();
        Console.WriteLine("Correct guess!");
    }

    private static void ShowIncorrectGuessMessage() {
        PrintError("Incorrect guess!");
    }

    private static void ShowAlreadyGuessedMessage() {
        PrintError("Already guessed!");
    }

    private static void ShowInvalidInputMessage() {
        PrintError("Invalid input!");
    }

    private static void PrintError(string message) {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

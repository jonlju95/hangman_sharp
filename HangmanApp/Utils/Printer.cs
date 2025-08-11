namespace HangmanApp.Utils;

public class Printer {
	public static void DisplayState(char[] maskedWord, HashSet<char> wrongGuesses, int remainingGuesses) {
		Console.Write("\nWord: ");
		foreach (char letter in maskedWord) {
			Console.Write(letter);
		}

		Console.Write("\nGuessed letters: ");
		foreach (char letter in wrongGuesses) {
			Console.Write(letter + ", ");
		}
		Console.WriteLine($"\nRemaining guesses: {remainingGuesses}");
	}

	public static char PromptGuess() {
		Console.Write("\nGuess a letter: ");
		return Console.ReadKey().KeyChar;
	}

	public static void ShowWinMessage(string correctWord) {
		Console.WriteLine("\nYou won the game!");
		Console.WriteLine($"The word was: {correctWord}");
	}

	public static void ShowLoseMessage(string correctWord) {
		Console.WriteLine("You lose!");
		Console.WriteLine($"The word was: {correctWord}");
	}

	public static char PromptPlayAgain() {
		Console.Write("\nPlay again? (y/n): ");
		return Console.ReadKey().KeyChar;
	}
}

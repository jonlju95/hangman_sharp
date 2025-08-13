namespace HangmanApp.Utils;

public static class ConsoleUI {

	public static int SelectDifficulty() {
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

		return difficulty[difficultyChoice];
	}

	public static void DisplayState(char[] maskedWord, HashSet<char> wrongGuesses, int remainingGuesses) {
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

	public static string? PromptGuess() {
		Console.Write("\nGuess a letter, or the entire word: ");
		return Console.ReadLine();
	}

	public static void ShowWinMessage(string correctWord) {
		Console.WriteLine("You won the game!");
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

	public static void PrintError(string message) {
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine(message);
		Console.ResetColor();
	}

}

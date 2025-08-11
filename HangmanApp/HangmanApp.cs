using HangmanApp.Utils;

namespace HangmanApp;

public static class HangmanApp {

	public static void Run() {
		GameLogic gameLogic = new GameLogic(WordProvider.GetRandomWord());

		Console.WriteLine("Welcome to hangman!");
		GameplayLoop(gameLogic);
	}

	private static void GameplayLoop(GameLogic gameLogic) {
		while (!gameLogic.IsGameOver()) {
			Printer.DisplayState(gameLogic.GetMaskedWord(), gameLogic.GetWrongGuesses(), gameLogic.GetRemainingGuesses());

			char guess = Printer.PromptGuess();

			gameLogic.GuessLetter(guess);

			if (gameLogic.HasWon()) {
				Printer.ShowWinMessage(gameLogic.GetFullWord());
			} else if (gameLogic.HasLost()) {
				Printer.ShowLoseMessage(gameLogic.GetFullWord());
			}
		}

		if (Printer.PromptPlayAgain() != 'y') {
			return;
		}

		Console.Clear();
		Run();
	}
}

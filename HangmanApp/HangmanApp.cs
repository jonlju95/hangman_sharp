using HangmanApp.Utils;

namespace HangmanApp;

public static class HangmanApp {

	public static void Run() {
		Console.WriteLine("Welcome to hangman!\n");

		GameLogic gameLogic = new GameLogic(WordProvider.GetRandomWord(), ConsoleUI.SelectDifficulty());
		Console.Clear();
		GameplayLoop(gameLogic);
	}

	private static void GameplayLoop(GameLogic gameLogic) {
		while (!gameLogic.IsGameOver()) {
			ConsoleUI.DisplayState(gameLogic.GetMaskedWord(), gameLogic.GetWrongGuesses(), gameLogic.GetRemainingGuesses());

			string? guess = ConsoleUI.PromptGuess();

			gameLogic.GuessHandler(guess);

			if (gameLogic.HasWon(guess)) {
				ConsoleUI.ShowWinMessage(gameLogic.GetFullWord());
				break;
			}

			if (!gameLogic.HasLost()) {
				continue;
			}

			ConsoleUI.ShowLoseMessage(gameLogic.GetFullWord());
			break;
		}

		if (ConsoleUI.PromptPlayAgain() != 'y') {
			return;
		}

		Run();
	}
}

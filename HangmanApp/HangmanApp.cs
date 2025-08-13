using HangmanApp.Interfaces;
using HangmanApp.Models;
using HangmanApp.Utils;

namespace HangmanApp;

public class HangmanApp(IGameUI gameUi, IWordProvider wordProvider) {

	public void Run() {
		while (true) {
			gameUi.ShowWelcome();

			string word = wordProvider.GetRandomWord();
			Difficulty difficulty = gameUi.SelectDifficulty();

			GameModel gameModel = new GameModel(word, difficulty.rounds);
			GameLogic gameLogic = new GameLogic(gameModel);

			Console.Clear();
			this.GameplayLoop(gameLogic);

			if (gameUi.PromptPlayAgain()) {
				Console.Clear();
				continue;
			}
			break;
		}
	}

	private void GameplayLoop(GameLogic gameLogic) {
		while (!gameLogic.IsGameOver()) {
			gameUi.DisplayState(gameLogic.GetMaskedWord(), gameLogic.GetWrongGuesses(), gameLogic.GetRemainingGuesses());

			string guess = gameUi.PromptGuess();

			GuessResult result = gameLogic.GuessHandler(guess);

			switch (result) {
				case GuessResult.CorrectLetter:
				case GuessResult.CorrectWord:
					gameUi.ShowCorrectGuessMessage();
					break;
				case GuessResult.IncorrectLetter:
				case GuessResult.IncorrectWord:
					gameUi.ShowIncorrectGuessMessage();
					break;
				case GuessResult.AlreadyGuessed:
					gameUi.ShowAlreadyGuessedMessage();
					break;
				case GuessResult.InvalidInput:
					gameUi.ShowInvalidInputMessage();
					break;
				default:
					continue;
			}

			if (gameLogic.HasWon(guess)) {
				gameUi.ShowWinMessage(gameLogic.GetFullWord());
				return;
			}

			if (!gameLogic.HasLost()) {
				continue;
			}

			gameUi.ShowLoseMessage(gameLogic.GetFullWord());
			return;
		}
	}
}

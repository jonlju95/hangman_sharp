using HangmanApp.Interfaces;
using HangmanApp.Models;
using HangmanApp.Utils;

namespace HangmanApp;

public class HangmanApp(IGameUI gameUi, IWordProvider wordProvider) {

	public void Run() {
		gameUi.ShowWelcome();

		GameLogic gameLogic = new GameLogic(wordProvider.GetRandomWord(), gameUi.SelectDifficulty().rounds);

		Console.Clear();
		this.GameplayLoop(gameLogic);
	}

	private void GameplayLoop(GameLogic gameLogic) {
		while (true) {
			GameModel gameModel = gameLogic.GetState();
			gameUi.DisplayState(gameModel.MaskedWord, gameModel.GuessedLetters,
				gameModel.RemainingTries);

			if (gameModel.IsGameOver) {
				if (gameModel.HasWon) {
					gameUi.ShowWinMessage(gameModel.CorrectWord);
				} else {
					gameUi.ShowLoseMessage(gameModel.CorrectWord);
				}

				break;
			}

			GuessResult result = gameLogic.GuessHandler(gameUi.PromptGuess());
			gameUi.ShowGuessFeedback(result);
		}

		if (!gameUi.PromptPlayAgain()) {
			return;
		}

		Console.Clear();
		this.Run();
	}
}

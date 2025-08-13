using HangmanApp.Models;
using HangmanApp.Utils;

namespace HangmanApp;

public class GameLogic(GameModel gameModel) {

	private readonly GameModel gameModel = gameModel ?? throw new ArgumentNullException(nameof(gameModel));

	public GuessResult GuessHandler(string? guess) {
		if (string.IsNullOrWhiteSpace(guess) || !Validator.ValidateInput(guess)) {
			return GuessResult.InvalidInput;
		}

		guess = guess.ToUpperInvariant();

		if (guess.Length == 1) {
			return this.GuessLetter(guess[0]);
		}

		return guess.Length == gameModel.CorrectWord.Length ? this.GuessWord(guess) : GuessResult.InvalidInput;
	}

	private GuessResult GuessLetter(char guessedLetter) {
		if (!gameModel.GuessedLetters.Add(guessedLetter)) {
			return GuessResult.AlreadyGuessed;
		}

		if (!gameModel.CorrectWord.ToUpperInvariant().Contains(guessedLetter)) {
			gameModel.RemainingTries--;
			return GuessResult.IncorrectLetter;
		}

		for (int i = 0; i < gameModel.CorrectWord.Length; i++) {
			if (gameModel.CorrectWord.ToUpperInvariant()[i] == guessedLetter) {
				gameModel.MaskedWord[i] = guessedLetter;
			}
		}

		return GuessResult.CorrectLetter;
	}

	private GuessResult GuessWord(string? guess) {
		if (string.Equals(guess, gameModel.CorrectWord, StringComparison.OrdinalIgnoreCase)) {
			return GuessResult.CorrectWord;
		}

		gameModel.RemainingTries--;
		return GuessResult.IncorrectWord;
	}

	public bool IsGameOver() {
		return gameModel.RemainingTries == 0 || this.HasWon("");
	}

	public bool HasWon(string guess) {
		return string.Equals(guess, gameModel.CorrectWord, StringComparison.OrdinalIgnoreCase) ||
		       !gameModel.CorrectWord.ToUpperInvariant().Where((t, i) => gameModel.MaskedWord[i] != t).Any();
	}

	public bool HasLost() {
		return gameModel.RemainingTries == 0;
	}

	public char[] GetMaskedWord() {
		return gameModel.MaskedWord;
	}

	public HashSet<char> GetWrongGuesses() {
		return gameModel.GuessedLetters;
	}

	public int GetRemainingGuesses() {
		return gameModel.RemainingTries;
	}

	public string GetFullWord() {
		return gameModel.CorrectWord;
	}
	//
	// private void GuessLetter(char guessedLetter) {
	// 	if (!this.GameModel.GuessedLetters.Add(guessedLetter)) {
	// 		ConsoleUI.PrintError("Letter already guessed!");
	// 		return;
	// 	}
	//
	// 	if (!this.GameModel.CorrectWord.Contains(guessedLetter)) {
	// 		this.GameModel.RemainingTries--;
	// 		ConsoleUI.PrintError("Wrong guess!\n");
	// 	} else {
	// 		for (int i = this.GameModel.CorrectWord.IndexOf(guessedLetter);
	// 		     i > -1;
	// 		     i = this.GameModel.CorrectWord.IndexOf(guessedLetter, i + 1)) {
	// 			this.GameModel.MaskedWord[i] = guessedLetter;
	// 		}
	// 	}
	// }
	//
	// private void GuessWord(string guess) {
	// 	if (guess == this.GameModel.CorrectWord) {
	// 		return;
	// 	}
	//
	// 	this.GameModel.RemainingTries--;
	// 	ConsoleUI.PrintError("Wrong guess!\n");
	// }
}

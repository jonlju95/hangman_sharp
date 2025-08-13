using HangmanApp.Utils;

namespace HangmanApp;

public class GameLogic(string word, int difficulty) {
	private GameModel GameModel { get; } = new GameModel(word, difficulty);

	public void GuessHandler(string? guess) {
		if (!string.IsNullOrEmpty(guess) && !Validator.ValidateInput(guess)) {
			ConsoleUI.PrintError("Guess can only contain letters!");
			return;
		}

		if (guess?.Length == 1) {
			this.GuessLetter(guess[0]);
		} else if (guess?.Length == this.GameModel.CorrectWord.Length) {
			this.GuessWord(guess);
		} else {
			ConsoleUI.PrintError("Guess must either be a single letter or the length of the word!\n");
		}
	}

	public bool IsGameOver() {
		return this.GameModel.RemainingTries == 0 || this.HasWon();
	}

	public bool HasWon(string? guess = null) {
		return this.GameModel.CorrectWord == guess ||
		       !this.GameModel.CorrectWord.Where((t, i) => this.GameModel.MaskedWord[i] != t).Any();
	}

	public bool HasLost() {
		return this.GameModel.RemainingTries == 0;
	}

	public char[] GetMaskedWord() {
		return this.GameModel.MaskedWord;
	}

	public HashSet<char> GetWrongGuesses() {
		return this.GameModel.GuessedLetters;
	}

	public int GetRemainingGuesses() {
		return this.GameModel.RemainingTries;
	}

	public string GetFullWord() {
		return this.GameModel.CorrectWord;
	}

	private void GuessLetter(char guessedLetter) {
		if (!this.GameModel.GuessedLetters.Add(guessedLetter)) {
			ConsoleUI.PrintError("Letter already guessed!");
			return;
		}

		if (!this.GameModel.CorrectWord.Contains(guessedLetter)) {
			this.GameModel.RemainingTries--;
			ConsoleUI.PrintError("Wrong guess!\n");
		} else {
			for (int i = this.GameModel.CorrectWord.IndexOf(guessedLetter);
			     i > -1;
			     i = this.GameModel.CorrectWord.IndexOf(guessedLetter, i + 1)) {
				this.GameModel.MaskedWord[i] = guessedLetter;
			}
		}
	}

	private void GuessWord(string guess) {
		if (guess == this.GameModel.CorrectWord) {
			return;
		}

		this.GameModel.RemainingTries--;
		ConsoleUI.PrintError("Wrong guess!\n");
	}
}

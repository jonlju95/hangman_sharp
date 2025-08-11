namespace HangmanApp;

public class GameLogic(string word) {
	private GameState gameState { get; } = new GameState(word);

	public void GuessLetter(char guessedLetter) {
		if (!this.gameState.GuessedLetters.Add(guessedLetter)) {
			return;
		}

		if (!this.gameState.CorrectWord.Contains(guessedLetter)) {
			this.gameState.RemainingTries--;
		} else {
			for (int i = this.gameState.CorrectWord.IndexOf(guessedLetter); i > -1; i = this.gameState.CorrectWord.IndexOf(guessedLetter, i + 1)) {
				this.gameState.MaskedWord[i] = guessedLetter;
			}
		}
	}

	public bool IsGameOver() {
		return this.gameState.RemainingTries == 0 || this.HasWon();
	}

	public bool HasWon() {
		return !this.gameState.CorrectWord.Where((t, i) => this.gameState.MaskedWord[i] != t).Any();
	}

	public bool HasLost() {
		return this.gameState.RemainingTries == 0;
	}

	public char[] GetMaskedWord() {
		return this.gameState.MaskedWord;
	}

	public HashSet<char> GetWrongGuesses() {
		return this.gameState.GuessedLetters;
	}

	public int GetRemainingGuesses() {
		return this.gameState.RemainingTries;
	}

	public string GetFullWord() {
		return this.gameState.CorrectWord;
	}
}

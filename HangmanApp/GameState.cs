namespace HangmanApp;

public class GameState {
	public string CorrectWord { get; private set; }
	public HashSet<char> GuessedLetters { get; private set; } = [];
	public int RemainingTries { get; set; }
	public char[] MaskedWord { get; private set; }

	public GameState(string correctWord) {
		if (string.IsNullOrWhiteSpace(correctWord)) {
			throw new ArgumentNullException(nameof(correctWord));
		}

		this.CorrectWord = correctWord;
		this.RemainingTries = 10;

		this.MaskedWord = new char[correctWord.Length];
		for (int i = 0; i < this.CorrectWord.Length; i++) {
			this.MaskedWord[i] = '_';
		}
	}
}

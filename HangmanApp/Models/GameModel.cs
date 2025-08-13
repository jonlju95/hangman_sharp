namespace HangmanApp;

public class GameModel {
	public string CorrectWord { get; private set; }
	public HashSet<char> GuessedLetters { get; private set; } = [];
	public int RemainingTries { get; set; }
	public char[] MaskedWord { get; private set; }

	public GameModel(string correctWord, int difficulty) {
		if (string.IsNullOrWhiteSpace(correctWord)) {
			throw new ArgumentNullException(nameof(correctWord));
		}

		this.CorrectWord = correctWord;
		this.RemainingTries = difficulty;

		this.MaskedWord = new char[correctWord.Length];
		for (int i = 0; i < this.CorrectWord.Length; i++) {
			this.MaskedWord[i] = '_';
		}
	}
}

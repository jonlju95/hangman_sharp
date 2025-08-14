namespace HangmanApp.Models;

public class GameModel {
	public string CorrectWord { get; init; } = "";
	public HashSet<char> GuessedLetters { get; init; } = [];
	public int RemainingTries { get; set; }
	public string MaskedWord { get; set; } = "";

	public bool HasWon => !this.MaskedWord.Contains('_');
	public bool HasLost => this.RemainingTries <= 0;
	public bool IsGameOver => this.HasWon | this.HasLost;

	// public GameModel(string correctWord, int difficulty) {
	// 	if (string.IsNullOrWhiteSpace(correctWord)) {
	// 		throw new ArgumentNullException(nameof(correctWord));
	// 	}
	//
	// 	this.CorrectWord = correctWord;
	// 	this.RemainingTries = difficulty;
	//
	// 	this.MaskedWord = new char[correctWord.Length];
	// 	for (int i = 0; i < this.CorrectWord.Length; i++) {
	// 		this.MaskedWord[i] = '_';
	// 	}
	// }
}

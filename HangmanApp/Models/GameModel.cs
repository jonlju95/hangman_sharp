namespace HangmanApp.Models;

public class GameModel {
	public string CorrectWord { get; init; } = "";
	public HashSet<char> GuessedLetters { get; init; } = [];
	public int RemainingTries { get; set; }
	public char[] MaskedWord { get; set; } = [];

	public bool HasWon => !this.MaskedWord.Contains('_');
	private bool HasLost => this.RemainingTries <= 0;
	public bool IsGameOver => this.HasWon | this.HasLost;
}

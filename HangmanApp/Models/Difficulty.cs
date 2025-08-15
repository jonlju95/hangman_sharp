namespace HangmanApp.Models;

public class Difficulty(string name, int rounds) {
	public string name { get; set; } = name;
	public int rounds { get; set; } = rounds;

}

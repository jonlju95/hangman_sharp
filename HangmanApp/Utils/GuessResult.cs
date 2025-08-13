namespace HangmanApp.Models;

public enum GuessResult {
	CorrectLetter,
	IncorrectLetter,
	CorrectWord,
	IncorrectWord,
	AlreadyGuessed,
	InvalidInput,
}

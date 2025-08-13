namespace HangmanApp.Interfaces;

public interface IGameUI {
	void ShowWelcome();
	void DisplayState(char[] maskedWord, IEnumerable<char> wrongGuesses, int remainingGuesses);
	string PromptGuess();
	void ShowWinMessage(string correctWord);
	void ShowLoseMessage(string correctWord);
	void ShowCorrectGuessMessage();
	void ShowIncorrectGuessMessage();
	void ShowAlreadyGuessedMessage();
	void ShowInvalidInputMessage();

	bool PromptPlayAgain();
	Difficulty SelectDifficulty();
}

using HangmanApp.Models;
using HangmanApp.Utils;

namespace HangmanApp.Interfaces;

public interface IGameUI {
	void ShowWelcome();
	void DisplayState(char[] maskedWord, IEnumerable<char> wrongGuesses, int remainingGuesses);
	string PromptGuess();
	void ShowWinMessage(string correctWord);
	void ShowLoseMessage(string correctWord);
	void ShowGuessFeedback(GuessResult result);
	bool PromptPlayAgain();
	Difficulty SelectDifficulty();
}

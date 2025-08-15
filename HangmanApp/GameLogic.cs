using HangmanApp.Models;
using HangmanApp.Utils;

namespace HangmanApp;

public class GameLogic(string randomWord, int maxRounds) {

	private readonly GameModel gameModel = new GameModel {
		CorrectWord = randomWord,
		GuessedLetters = [],
		RemainingTries = maxRounds,
		MaskedWord = CreateMaskedWordArray(randomWord)
	};

	public GameModel GetState() {
		return new GameModel {
			CorrectWord = gameModel.CorrectWord,
			GuessedLetters = gameModel.GuessedLetters,
			RemainingTries = gameModel.RemainingTries,
			MaskedWord = gameModel.MaskedWord
		};
	}

	public GuessResult GuessHandler(string? guess) {
		if (string.IsNullOrWhiteSpace(guess) || !Validator.ValidateInput(guess)) {
			return GuessResult.InvalidInput;
		}

		guess = guess.ToUpperInvariant();

		if (guess.Length == 1) {
			return this.GuessLetter(guess[0]);
		}

		return guess.Length == gameModel.CorrectWord.Length ? this.GuessWord(guess) : GuessResult.InvalidInput;
	}

	private GuessResult GuessLetter(char guessedLetter) {
		if (!gameModel.GuessedLetters.Add(guessedLetter)) {
			return GuessResult.AlreadyGuessed;
		}

		if (!gameModel.CorrectWord.ToUpperInvariant().Contains(guessedLetter)) {
			gameModel.RemainingTries--;
			return GuessResult.IncorrectLetter;
		}

		for (int i = 0; i < gameModel.CorrectWord.Length; i++) {
			if (gameModel.CorrectWord.ToUpperInvariant()[i] == guessedLetter) {
				gameModel.MaskedWord[i] = guessedLetter;
			}
		}

		return GuessResult.CorrectLetter;
	}

	private GuessResult GuessWord(string? guess) {
		if (!string.IsNullOrWhiteSpace(guess) &&
		    string.Equals(guess, gameModel.CorrectWord, StringComparison.OrdinalIgnoreCase)) {
			gameModel.MaskedWord = guess.ToCharArray();
			return GuessResult.CorrectWord;
		}

		gameModel.RemainingTries--;
		return GuessResult.IncorrectWord;
	}

	private static char[] CreateMaskedWordArray(string word) {
		char[] wordArray = new char[word.Length];
		for (int i = 0; i < word.Length; i++) {
			wordArray[i] = '_';
		}

		return wordArray;
	}
}

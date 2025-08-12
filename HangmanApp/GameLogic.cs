using HangmanApp.Utils;

namespace HangmanApp;

public class GameLogic(string word) {
    private GameState gameState { get; } = new GameState(word);

    public void GuessHandler(string guess) {
        if (guess.Length == 1) {
            this.GuessLetter(guess[0]);
        } else if (guess.Length == this.gameState.CorrectWord.Length) {
            this.GuessWord(guess);
        } else {
            Printer.PrintError("Guess must either be a single letter or the length of the word!");
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

    private void GuessLetter(char guessedLetter) {
        if (!this.gameState.GuessedLetters.Add(guessedLetter)) {
            return;
        }

        if (!this.gameState.CorrectWord.Contains(guessedLetter)) {
            this.gameState.RemainingTries--;
        } else {
            for (int i = this.gameState.CorrectWord.IndexOf(guessedLetter);
                 i > -1;
                 i = this.gameState.CorrectWord.IndexOf(guessedLetter, i + 1)) {
                this.gameState.MaskedWord[i] = guessedLetter;
            }
        }
    }

    private void GuessWord(string guess) {
        if (guess != this.gameState.CorrectWord) {
            this.gameState.RemainingTries--;
        }
    }
}

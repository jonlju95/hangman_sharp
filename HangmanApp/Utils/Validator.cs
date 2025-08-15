using System.Text.RegularExpressions;

namespace HangmanApp.Utils;

public static partial class Validator {

	public static bool ValidateInput(string input) {
		string cleanedInput = CleanWhitespace(input);
		Regex regex = LetterRegex();
		return regex.IsMatch(cleanedInput);
	}

	private static string CleanWhitespace(string input) {
		return input.Replace(" ", "");
	}

	[GeneratedRegex("^[a-zA-Z]+$")]
	private static partial Regex LetterRegex();
}

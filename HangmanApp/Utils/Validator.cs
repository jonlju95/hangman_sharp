using System.Text.RegularExpressions;

namespace HangmanApp.Utils;

public class Validator {

	public static bool ValidateInput(string input) {
		Regex regex = new Regex("^[a-zA-Z]+$");
		return regex.IsMatch(input);
	}



}

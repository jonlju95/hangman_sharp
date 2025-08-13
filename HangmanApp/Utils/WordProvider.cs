using HangmanApp.Interfaces;

namespace HangmanApp.Utils;

public class WordProvider : IWordProvider {
	private static readonly string[] WordList = [
		"employee",
		"activity",
		"technology",
		"confusion",
		"power",
		"independence",
		"world",
		"cigarette",
		"historian",
		"depth",
		"response",
		"perspective",
		"obligation",
		"opportunity",
		"disk",
		"philosophy",
		"skill",
		"food",
		"girlfriend",
		"tension",
		"child",
		"consequence",
		"understanding",
		"criticism",
		"night",
		"exam",
		"session",
		"thanks",
		"driver",
		"environment",
		"emotion",
		"college",
		"assumption",
		"measurement",
		"moment",
		"strategy",
		"sister",
		"chapter",
		"family",
		"idea",
		"health",
		"bathroom",
		"county",
		"development",
		"cookie",
		"description",
		"speech",
		"bread",
		"disease",
		"vehicle"
	];

	public string GetRandomWord() {
		return WordList[new Random().Next(0, WordList.Length - 1)];
	}
}

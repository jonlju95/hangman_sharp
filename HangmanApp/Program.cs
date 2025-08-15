using HangmanApp.Utils;

namespace HangmanApp;

internal static class Program {
    public static void Main() {
        GameUI gameUI = new GameUI();
        WordProvider wordProvider = new WordProvider();
        HangmanApp app = new HangmanApp(gameUI, wordProvider);
        app.Run();
    }
}

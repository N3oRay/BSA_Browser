using Avalonia;

namespace BSABrowser
{
    internal static class Program
    {
        // Point d'entrée principal de l'application.
        public static void Main(string[] args)
        {
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }

        // Configuration Avalonia Application
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
    }
}

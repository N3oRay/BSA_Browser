using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BSA_Browser.Classes;

namespace BSA_Browser
{
    public partial class App : Application
    {
        public const string Fallout4Nexus = "https://www.nexusmods.com/fallout4/mods/17061";
        public const string SkyrimSENexus = "https://www.nexusmods.com/skyrimspecialedition/mods/1756";
        public const string GitHub = "https://github.com/AlexxEG/BSA_Browser";
        public const string Discord = "https://discord.gg/k97ACqK";
        public const string VersionUrl = "https://raw.githubusercontent.com/AlexxEG/BSA_Browser/master/VERSION";

        public static bool SettingsReset = false;
        public static bool Simulate = false;

        public static readonly string Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
        public static readonly string TempPath = Path.Combine(Path.GetTempPath(), "bsa_browser");

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            // (1) Gestion des arguments de la ligne de commande
            var args = Environment.GetCommandLineArgs().Skip(1).ToArray(); // Skip exe path
            var parsedArgs = new ParsedArguments(args);

            // (2) Gestion du reset et de l’upgrade des paramètres (à adapter à ton système de settings Avalonia)
            // Pseudo-code, à adapter si tu as migré Settings.Default
            // HandleSettingsReset();
            // if (!HandleSettingsUpgrade()) return; // quitte si l'utilisateur refuse le reset

            // (3) Mode simulation
            if (args.Contains("/s", StringComparer.OrdinalIgnoreCase))
                Simulate = true;

            // (4) Extraction directe si demandé
            if (parsedArgs.Extract)
            {
                // Ici, tu pourrais lancer une fenêtre spéciale ou un service d'extraction en mode console/CLI
                // TODO: Portage de la logique d'extraction (voir Common.OpenArchive, etc.)
                // Ex : ExtractArchive(parsedArgs.ExtractFile, parsedArgs.ExtractDestination);
                Environment.Exit(0);
                return;
            }

            // (5) Lancement de la fenêtre principale avec les fichiers à ouvrir
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // BSABrowserWindow est ta fenêtre principale Avalonia
                desktop.MainWindow = new BSABrowserWindow(parsedArgs.Files.ToArray());
            }

            base.OnFrameworkInitializationCompleted();
        }

        // Exemples de méthodes utilitaires à adapter
        public static string CreateTempDirectory()
        {
            string tmp;
            for (int i = 0; i < 32000; i++)
            {
                tmp = Path.Combine(TempPath, i.ToString());
                if (!Directory.Exists(tmp))
                {
                    Directory.CreateDirectory(tmp);
                    return tmp + Path.DirectorySeparatorChar;
                }
            }
            throw new Exception("Could not create temp folder because directory is full");
        }

        // Ajoute tes autres méthodes utilitaires ici (HandleSettingsReset, HandleSettingsUpgrade, SaveException, etc.)
    }

    // Utilise la classe ParsedArguments quasi-identique à l’ancienne version
    public class ParsedArguments
    {
        public bool Extract { get; private set; } = false;
        public string ExtractFile { get; private set; }
        public ExtractDestinations ExtractDestination { get; private set; } = ExtractDestinations.Here;
        public IReadOnlyList<string> Files { get; private set; }

        public ParsedArguments(IList<string> arguments)
        {
            var files = new List<string>();

            for (int i = 0; i < arguments.Count; i++)
            {
                switch (arguments[i].ToLower())
                {
                    case "/extract":
                        this.Extract = true;
                        this.ExtractFile = arguments[++i];
                        break;
                    case "/d":
                        this.ExtractDestination = ExtractDestinations.Directory;
                        break;
                    case "/h":
                        this.ExtractDestination = ExtractDestinations.Here;
                        break;
                    default: // Assume rest are files
                        files.Add(arguments[i]);
                        break;
                }
            }

            this.Files = files.AsReadOnly();
        }
    }

    public enum ExtractDestinations
    {
        Directory,
        Here
    }
}

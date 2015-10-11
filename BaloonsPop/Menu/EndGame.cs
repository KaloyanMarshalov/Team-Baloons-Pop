namespace PoppingBaloons.Menu
{
    using System;
    using System.Linq;

    public class EndGame
    {
        private const string StartGameMarked = "> START GAME <\n";
        private const string StartGameUnMarked = "  START GAME\n";
        private const string QuitGameMarked = "> QUIT GAME <";
        private const string QuitGameUnMarked = "  QUIT GAME";

        public static void QuitGame()
        {
            Console.Clear();
            MainMenu.PrintMenu(StartGameUnMarked, QuitGameMarked);
            var keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                // Quit Game
                Console.WriteLine("Thanks for playing!!!");
                Environment.Exit(0);
            }
            else
            {
                if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.DownArrow)
                {
                    Console.Clear();
                    MainMenu.PrintMenu(StartGameMarked, QuitGameUnMarked);

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        GameMenu.StartGame();
                    }
                }
            }
        }
    }
}

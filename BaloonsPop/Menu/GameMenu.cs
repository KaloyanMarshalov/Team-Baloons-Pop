namespace PoppingBaloons.Menu
{
    using System;
    using System.Linq;

    public class GameMenu
    {              
        private const string StartGameMarked = "> START GAME <\n";
        private const string StartGameUnMarked = "  START GAME\n";
        private const string QuitGameMarked = "> QUIT GAME <";
        private const string QuitGameUnMarked = "  QUIT GAME";

        public static int StartGame()
        {
            Console.Clear();
            Menu.MainMenu.PrintMenu(StartGameMarked, QuitGameUnMarked);
            var keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                NewGame.StartNewGame();
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.UpArrow)
            {
                EndGame.QuitGame();
            }

            return StartGame();
        }
    }
}

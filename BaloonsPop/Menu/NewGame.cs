namespace PoppingBaloons.Menu
{
    using System;
    using System.Linq;
    using PoppingBaloons.Renderers;

    public class NewGame
    {
        public static void StartNewGame()
        {
            const int BoardWidth = 6;
            const int BoardHeight = 10;

            ConsoleRenderer consoleRenderer = ConsoleRenderer.LoggerInstance;
            Game game = new Game(BoardHeight, BoardWidth, consoleRenderer);
            game.Start();
        }
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Game.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that watches for a change in state of the baloons.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace PoppingBaloons
{
    using System;
    using PoppingBaloons.Board;
    using PoppingBaloons.Board.Strategies;
    using PoppingBaloons.Interfaces;
    using PoppingBaloons.Scores;

    /// <summary>
    /// The main class used to execute the whole code.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="Game"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="Start"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="ParseCommand"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="SendCommand"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="Restart"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class Game
    {
        private const int BoardWidth = 5;
        private const int BoardHeight = 10;

        private readonly Score score;
        private readonly IRenderer renderer;
        private readonly Gameboard gameBoard;

        /// <summary>
        /// A constructor for the class.
        /// </summary>
        /// <param name="boardWidth">The board width the constructor uses.</param>
        /// <param name="boardHeight">The board height the constructor uses.</param>
        /// <param name="renderer">The interface passed to the constructor.</param>
        public Game(int boardWidth, int boardHeight, IRenderer renderer)
        {
            this.gameBoard = new Gameboard(boardWidth, boardHeight, new RecursivePopStrategy(), new NormalGravityStrategy());
            this.score = new Score("anonimous", 0);
            this.renderer = renderer;
        }

        /// <summary>
        /// A method used for starting the game.
        /// </summary>
        public void Start()
        {
            while (true)
            {
                this.renderer.ClearScreen();
                this.renderer.RenderMessage(string.Format("Score: {0}", this.score.Points));
                this.renderer.RenderGameboard(this.gameBoard);
                this.ParseCommand(Console.ReadLine());
            }
        }

        /// <summary>
        /// A method that accepts a string. The method first checks for the validity of the string
        /// command. After that depending on the string's length, the method invokes other
        /// methods or prints a message on the console.
        /// </summary>
        /// /// <param name="command">The string the method is called upon.</param>
        public void ParseCommand(string command)
        {
            string[] commands = command.Split(' ');

            if (commands.Length == 2)
            {
                int row;
                int col;

                int.TryParse(commands[0], out row);
                int.TryParse(commands[1], out col);

                if (row >= BoardWidth || col >= BoardHeight)
                {
                    Console.WriteLine("Ivalid coordinates.");
                }
                else
                {
                    this.SendCommand(row, col);
                }
            }
            else if (commands.Length == 1)
            {
                string currentCommand = commands[0];

                switch (currentCommand)
                {
                    case "restart":
                        Console.Clear();
                        this.Restart();
                        break;

                    ////case "top":
                    //    this.DisplayScoreboard();
                    //    break;
                    case "exit":
                        Menu.EndGame.QuitGame();
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }

        /// <summary>
        /// Depending on the passed parameters (row and column), this method checks if they
        /// are in the range of the game board, if baloons are popped and if true game ends and 
        /// result is updated.
        /// </summary>
        /// <param name="row">The integer the method is called upon.</param>
        /// <param name="column">The integer the method is called upon.</param>
        private void SendCommand(int row, int column)
        {
            this.score.Points += this.gameBoard.PopBaloon(row, column);
        }

        /// <summary>
        /// A method that restarts the game.
        /// </summary>
        private void Restart()
        {
            Menu.NewGame.StartNewGame();
        }
    }
}
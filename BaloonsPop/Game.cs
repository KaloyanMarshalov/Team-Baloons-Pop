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
    using Interfaces;
    using Scores;

    /// <summary>
    /// A class that displays and updates the scores on the console:
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="DisplayScoreboard"/>,</description> 
    /// </item>
    /// <item> 
    /// <description><see cref="ParseCommand"/>,</description> 
    /// </item>
    /// <item> 
    /// <description><see cref="SendCommand"/>,</description> 
    /// </item>
    /// <item> 
    /// <description><see cref="UpdateScoreboard"/>,</description> 
    /// </item>
    /// <item> 
    /// <description><see cref="Restart"/>,</description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class Game
    {
        private readonly Score score;
        private readonly IRenderer renderer;
        private Gameboard gameBoard;

        /// <summary>
        /// A constructor used for instantiating the class.
        /// </summary>
        /// <param name="renderer">The interface the constructor demands on instatiation.</param>
        public Game(int boardWidth, int boardHeight, IRenderer renderer)
        {
            this.gameBoard = new Gameboard(boardWidth, boardHeight, new RecursivePopStrategy(), new NormalGravityStrategy());
            this.score = new Score("anonimous", 0);
            this.renderer = renderer;
        }

        /// <summary>
        /// A method that is used to display the score in the form of text.
        /// </summary>
        /// <returns>The method returns a string.</returns>
        //public string DisplayScoreboard()
        //{
        //    ListOfCommands.PrintListOFCommands();
        //    StringBuilder stringBuilder = new StringBuilder();

        //    if (this.score.Count == 0)
        //    {
        //        stringBuilder.AppendLine("The scoreboard is empty");
        //    }
        //    else
        //    {
        //        stringBuilder.AppendLine("Top performers:");

        //        foreach (Tuple<string, int> score in this.score)
        //        {
        //            stringBuilder.AppendLine(score.Item1 + "  " + score.Item2 + " turns ");
        //        }
        //    }

        //    return stringBuilder.ToString();
        //}

        public void Start()
        {
            while (true)
            {
                renderer.RenderGameboard(gameBoard);
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

                this.SendCommand(row, col);
            }
            //else if (commands.Length == 1)
            //{
            //    string currentCommand = commands[0];

            //    switch (currentCommand)
            //    {
            //        case "restart":
            //            Console.Clear();
            //            this.Restart();
            //            break;
            //        case "top":
            //            //this.DisplayScoreboard();
            //            break;
            //        case "exit":
            //            //this.renderer.LogMessage("Thanks for playing!!!");
            //            Environment.Exit(0);
            //            break;
            //        default:
            //            //ListOfCommands.PrintListOfCommands();
            //            //this.renderer.LogMessage("Unknown command");
            //            break;
            //    }
            //}
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
            int scoreFromMove;
            scoreFromMove = this.gameBoard.PopBaloon(row, column);            
        }        

        /// <summary>
        /// A method used for making a new instance of the <see cref="BaloonsState()"/> method.
        /// </summary>
        private void Restart()
        {
            this.Start();
        }
    }
}
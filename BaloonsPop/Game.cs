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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
            this.score = new Score("anon", 0);
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
                Console.Clear();
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

                bool validRow = int.TryParse(commands[0], out row);
                bool validCol = int.TryParse(commands[1], out col);

                if (validRow && validCol)
                {
                    ListOfCommands.PrintListOfCommands();    
                    this.SendCommand(row, col);
                }
                else
                {
                    ListOfCommands.PrintListOfCommands();
                    //this.renderer.LogMessage("Unknown command");
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
                    case "top":
                        //this.DisplayScoreboard();
                        break;
                    case "exit":
                        //this.renderer.LogMessage("Thanks for playing!!!");
                        Environment.Exit(0);
                        break;
                    default:
                        ListOfCommands.PrintListOfCommands();
                        //this.renderer.LogMessage("Unknown command");
                        break;
                }
            }
            else
            {
                ListOfCommands.PrintListOfCommands();
                //this.renderer.LogMessage("Unknown Command");
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
            bool endOfTheGame = false;
            int maxRows = 5;

            if (row > maxRows)
            {
                ListOfCommands.PrintListOfCommands();
                //this.renderer.LogMessage("Indexes too big");
            }
            else
            {
                int scoreFromMove;
                scoreFromMove = this.gameBoard.PopBaloon(row, column);

                ////if this turn ends the game, try to update the scoreboard
            }

            if (endOfTheGame)
            {
                //this.renderer.LogMessage("Congratulations!! You popped all the baloons in WE NEED TO HAVE SCORE moves!");
                //this.UpdateScoreboard();
                this.Restart();
            }
        }

        /// <summary>
        /// A method used to update the score. It checks if a new player name is inserted and
        /// replaces the old one.
        /// </summary>
        //private void UpdateScoreboard()
        //{
        //    Action<int> add = count => ////function to get the player name and add a tuple to the scoreboard
        //    {
        //        renderer.LogMessage("Enter Name: ");
        //        string playerName = Console.ReadLine();
        //        Tuple<string, int> scoresOfPlayer = Tuple.Create<string, int>(playerName, count);
        //        score.Add(scoresOfPlayer);
        //    };

        //    int maxPlayersInHighScores = 5;

        //    if (this.score.Count < maxPlayersInHighScores)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        // TODO: Total rework, this has to be in the HighScore class
        //        if (this.score.ElementAt<Tuple<string, int>>(4).Item2 >= 1)
        //        {
        //            this.score.RemoveRange(4, 1); ////if the new name replaces one of the old ones, remove the old one
        //        }
        //    }

        //    this.score.Sort((p1, p2) => p1.Item2.CompareTo(p2.Item2));
        //}

        /// <summary>
        /// A method used for making a new instance of the <see cref="BaloonsState()"/> method.
        /// </summary>
        private void Restart()
        {
            ListOfCommands.PrintListOfCommands();
        }
    }
}
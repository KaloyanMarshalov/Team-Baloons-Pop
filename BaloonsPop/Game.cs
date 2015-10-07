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

    using Interfaces;

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
        private readonly List<Tuple<string, int>> highScores;
        private readonly ILogger logger;
        private BaloonsState state;

        /// <summary>
        /// A constructor used for instantiating the class.
        /// </summary>
        /// <param name="logger">The interface the constructor demands on instatiation.</param>
        public Game(ILogger logger)
        {
            this.state = new BaloonsState();
            this.highScores = new List<Tuple<string, int>>();
            this.logger = logger;
        }

        /// <summary>
        /// A method that is used to display the score in the form of text.
        /// </summary>
        /// <returns>The method returns a string.</returns>
        public string DisplayScoreboard()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (this.highScores.Count == 0)
            {
                stringBuilder.AppendLine("The scoreboard is empty");
            }
            else
            {
                stringBuilder.AppendLine("Top performers:");

                foreach (Tuple<string, int> score in this.highScores)
                {
                    stringBuilder.AppendLine(score.Item1 + "  " + score.Item2 + " turns ");
                }
            }

            return stringBuilder.ToString();
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
                    this.SendCommand(row, col);
                }
                else
                {
                    this.logger.Log("Unknown command");
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
                        this.DisplayScoreboard();
                        break;
                    case "exit":
                        this.logger.Log("Thanks for playing!!!");
                        Environment.Exit(0);
                        break;
                    default:
                        this.logger.Log("Unknown command");
                        break;
                }
            }
            else
            {
                this.logger.Log("Unknown Command");
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
                this.logger.Log("Indexes too big");
            }
            else
            {
                ////if this turn ends the game, try to update the scoreboard
                endOfTheGame = this.state.PopBaloon(row + 1, column + 1);
            }

            if (endOfTheGame)
            {
                this.logger.Log("Congratulations!! You popped all the baloons in " + this.state.TurnCounter + " moves!");
                this.UpdateScoreboard();
                this.Restart();
            }
        }

        /// <summary>
        /// A method used to update the score. It checks if a new player name is inserted and
        /// replaces the old one.
        /// </summary>
        private void UpdateScoreboard()
        {
            Action<int> add = count => ////function to get the player name and add a tuple to the scoreboard
            {
                logger.Log("Enter Name: ");
                string playerName = Console.ReadLine();
                Tuple<string, int> scoresOfPlayer = Tuple.Create<string, int>(playerName, count);
                highScores.Add(scoresOfPlayer);
            };

            int maxPlayersInHighScores = 5;

            if (this.highScores.Count < maxPlayersInHighScores)
            {
                add(this.state.TurnCounter);
                return;
            }
            else
            {
                if (this.highScores.ElementAt<Tuple<string, int>>(4).Item2 >= this.state.TurnCounter)
                {
                    add(this.state.TurnCounter);
                    this.highScores.RemoveRange(4, 1); ////if the new name replaces one of the old ones, remove the old one
                }
            }

            this.highScores.Sort((p1, p2) => p1.Item2.CompareTo(p2.Item2));
            this.state = new BaloonsState();
        }

        /// <summary>
        /// A method used for making a new instance of the <see cref="BaloonsState()"/> method.
        /// </summary>
        private void Restart()
        {
            this.state = new BaloonsState();
        }
    }
}
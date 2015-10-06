namespace PoppingBaloons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;

    public class Game
    {
        private readonly List<Tuple<string, int>> highScores;
        private readonly ILogger logger;
        private BaloonsState state;

        public Game(ILogger logger)
        {
            this.state = new BaloonsState();
            this.highScores = new List<Tuple<string, int>>();
            this.logger = logger;
        }

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

                if (currentCommand == "restart")
                {
                    this.Restart();
                }
                else if (currentCommand == "top")
                {
                    this.DisplayScoreboard();
                }
                else if (currentCommand == "exit")
                {
                    this.logger.Log("Thanks for playing!!!");
                    Environment.Exit(0); 
                }
                else
                {
                    this.logger.Log("Unknown command");
                }
            }
            else
            {
                this.logger.Log("Unknown Command");
            }
        }

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

        private void Restart()
        {
            this.state = new BaloonsState();
        }
    }
}
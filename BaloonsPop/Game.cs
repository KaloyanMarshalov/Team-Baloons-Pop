﻿namespace PoppingBaloons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Game
    {
        private BaloonsState state;
        private List<Tuple<string, int>> highScores;

        public Game()
        {
            state = new BaloonsState();
            highScores = new List<Tuple<string, int>>();
        }

        public string DisplayScoreboard()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (highScores.Count == 0)
                stringBuilder.AppendLine("The scoreboard is empty");
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
                    sendCommand(row, col);
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }
            else if (commands.Length == 1)
            {
                string currentCommand = commands[0];

                if (currentCommand == "restart")
                { 
                    restart();
                }
                else if (currentCommand == "top")
                {
                    DisplayScoreboard();
                }
                else if (currentCommand == "exit")
                {
                    Console.WriteLine("Thanks for playing!!");
                    Environment.Exit(0); 
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }
            else
            {
                Console.WriteLine("Unknown Command");
            }
        }

        private void sendCommand(int fst, int snd)
        {
            bool end = false;
            if (fst > 5)
                Console.WriteLine("Indexes too big");
            else
                end = state.PopBaloon(fst+1, snd+1);//if this turn ends the game, try to update the scoreboard
            if (end)
            { 
                Console.WriteLine("Congratulations!!You popped all the baloons in" + state.turnCounter + "moves!");
                updateScoreboard();
                restart();
            }
        }

        private void updateScoreboard()
        {
            Action<int> add = count =>//function to get the player name and add a tuple to the scoreboard
            {
                Console.WriteLine("Enter Name:");
                string s = Console.ReadLine();
                Tuple<string, int> a = Tuple.Create<string, int>(s, count);
                highScores.Add(a);


            };
            if (highScores.Count < 5)
            {
                add(state.turnCounter);
                return;
            }
            else
            {



                if (highScores.ElementAt<Tuple<string, int>>(4).Item2 >= state.turnCounter)
                {
                    add(state.turnCounter);
                    highScores.RemoveRange(4, 1);//if the new name replaces one of the old ones, remove the old one
                }
            }
            highScores.Sort(delegate(Tuple<string, int> p1, Tuple<string, int> p2)//re-sort the list
                      {
                          return p1.Item2.CompareTo(p2.Item2);
                      });
            state = new BaloonsState();
        }

        private void restart()
        {
            state = new BaloonsState();
        }

    }
}


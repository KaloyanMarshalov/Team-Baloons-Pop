// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that watches for a change in state of the baloons.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace PoppingBaloons.Renderers
{
    using System;
    using System.Collections.Generic;
    using PoppingBaloons.Board;
    using PoppingBaloons.Interfaces;
    
    public sealed class ConsoleRenderer : IRenderer
    {
        private static readonly object syncLock = new object();
        private static volatile ConsoleRenderer loggerInstance;

        private ConsoleRenderer()
        {
        }

        public void RenderMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void RenderGameboard(Gameboard gameboard)
        {
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("    --------------------");
            for (int i = 0; i < gameboard.BoardHeight; i++)
            {
                Console.Write(i.ToString() + " | ");
                for (int j = 0; j < gameboard.BoardWidth; j++)
                {
                    BoardComponent component = gameboard.GetElement(i, j);
                    this.SwitchConsoleColor(component.Color);
                    if (!component.IsActive)
                    {
                        Console.Write('-');
                    }
                    else
                    {
                        Console.Write("O");
                    }

                    Console.ResetColor();
                    Console.Write(" ");
                }

                Console.WriteLine("| ");                
            }

            Console.WriteLine("    --------------------");
            this.PrintListOfCommands();
            Console.WriteLine("Insert row and column or other command");
        }

        /// <summary>
        /// A static method used for checking if an instance of this class is already
        /// available. Implementation of the Singleton Pattern.
        /// </summary>
        /// <returns>The method returns a new instance if none has been instantiated.</returns>
        public static ConsoleRenderer LoggerInstance
        {
            get
            {
                if (loggerInstance == null)
                {
                    lock (syncLock)
                    {
                        if (loggerInstance == null)
                        {
                            loggerInstance = new ConsoleRenderer();
                        }
                    }
                }

                return loggerInstance;
            }
        }

        private void SwitchConsoleColor(string baloonColor)
        {
            switch (baloonColor)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }        

        private void PrintListOfCommands()
        {
            var listOfCommands = new List<string>();

            listOfCommands.Add("List of Commands");
            listOfCommands.Add("---------------------------------------");
            listOfCommands.Add("* Use 'top' to view the top scoreboard!");
            listOfCommands.Add("* Use 'restart' to start a new game!");
            listOfCommands.Add("* Use 'exit' to quit the game!\n");

            foreach (var item in listOfCommands)
            {
                Console.WriteLine(item);
            }
        }
    }
}

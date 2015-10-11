// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleRenderer.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that draws the gameboard on the console.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace PoppingBaloons.Renderers
{
    using System;
    using System.Collections.Generic;
    using PoppingBaloons.Board;
    using PoppingBaloons.Interfaces;

    /// <summary>
    /// A class that draws the gameboard on the console.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="ClearScreen"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="RenderGameboard"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="RenderMessage"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="SwitchConsoleColor"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="PrintListOfCommands"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="LoggerInstance"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public sealed class ConsoleRenderer : IRenderer
    {
        private static readonly object SyncLock = new object();
        private static volatile ConsoleRenderer loggerInstance;

        /// <summary>
        /// An empty constructor for the class.
        /// </summary>
        private ConsoleRenderer()
        {
        }

        /// <summary>
        /// Gets or sets an instance of the class. It checks if an instance of this class is already
        /// available. Implementation of the Singleton Pattern.
        /// </summary>
        /// <returns>Returns a new instance if none has been instantiated.</returns>
        public static ConsoleRenderer LoggerInstance
        {
            get
            {
                if (loggerInstance == null)
                {
                    lock (SyncLock)
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

        /// <summary>
        /// A method used for printing messages on the console.
        /// </summary>
        /// <param name="message">The string the method is called upon.</param>
        public void RenderMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// A method that clears the console.
        /// </summary>
        public void ClearScreen()
        {
            Console.Clear();
        }

        /// <summary>
        /// A method used for drawing the gameboard on the console.
        /// </summary>
        /// <param name="gameboard">The instance of the Gameboard the method is called upon.</param>
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
        /// A method that changes the console foreground color depending on the string
        /// passed to the method.
        /// </summary>
        /// <param name="baloonColor">The string the method is called upon.</param>
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

        /// <summary>
        /// A method used for printing the commands on the console.
        /// </summary>
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

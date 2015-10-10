// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="Team-Baloon-Pop">
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
    using PoppingBaloons.Interfaces;

    /// <summary>
    /// Sealed class used for logging various messages on the console:
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="Log"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public sealed class ConsoleRenderer : IRenderer
    {
        private static readonly object syncLock = new object();
        private static volatile ConsoleRenderer loggerInstance;

        private ConsoleRenderer()
        {
        }

        public void RenderGameboard(Gameboard gameboard)
        {
            Console.WriteLine("new renderer");
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("    --------------------");
            for (int i = 0; i < gameboard.BoardHeight; i++)
            {
                Console.Write(i.ToString() + " | ");
                for (int j = 0; j < gameboard.BoardWidth; j++)
                {
                    int baloonNumber = gameboard.GetElement(i, j);
                    this.SwitchConsoleColor(baloonNumber);
                    //char currentChar = this.GetBaloonChar(baloonNumber);
                    Console.Write(baloonNumber);
                    Console.ResetColor();
                    Console.Write(" ");

                }

                Console.WriteLine("| ");

                
            }

            Console.WriteLine("    --------------------");
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

        private void SwitchConsoleColor(int baloonNumber)
        {
            switch (baloonNumber)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
    }
}

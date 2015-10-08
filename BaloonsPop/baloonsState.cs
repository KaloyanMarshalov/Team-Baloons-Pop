// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaloonsState.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that watches for a change in state of the baloons.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons
{
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// A class that watches for the game development, drawing the game board
    /// on the console and stopping the game using the following methods: 
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="TurnCounter"/>,</description> 
    /// </item>
    /// <item> 
    /// <description><see cref="BaloonsState()"/>,</description> 
    /// </item>
    /// <item> 
    /// <description><see cref="GetBaloonChar"/>,</description> 
    /// </item>
    /// <item> 
    /// <description><see cref="PopBaloon"/>,</description> 
    /// </item>
    /// <item> 
    /// <description><see cref="GameHasEnded"/>,</description> 
    /// </item>
    /// <item> 
    /// <description><see cref="SwitchConsoleColor"/>,</description> 
    /// </item>
    /// <item> 
    /// <description><see cref="PrintArray"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class BaloonsState
    {
        /// <summary>
        /// An integer variable that counts how many times a baloon is popped. When the game
        /// begins it has an initial value 0. After that before the game is over it grows by one
        /// for every baloon po
        /// </summary>
        private const int BoardWidth = 6;
        private const int BoardHeight = 10;
        private const int MinBaloon = 1;
        private const int MaxBaloon = 4;

        private readonly int[,] playField;
        private Random randomGenerator;

        /// <summary>
        /// This method randomly generates the position of the player on the game board
        /// and uses <see cref="PrintArray"/> method to print the board on the console.
        /// </summary>
        public BaloonsState()
        {
            this.TurnCounter = 0;
            this.playField = new int[BoardWidth, BoardHeight];
            this.randomGenerator = new Random();

            for (int i = 0; i < BoardWidth; i++)
            {
                for (int j = 0; j < BoardHeight; j++)
                {
                    this.playField[i, j] = this.randomGenerator.Next(1, 5);
                }
            }

            this.PrintArray();
        }

        public int TurnCounter { get; set; }

        /// <summary>
        /// A method that checks if the number of baloons is in a given range.
        /// </summary>
        /// <param name="baloonNum">The integer the method is called upon.</param>
        /// <returns>The method returns a char or a '-'.</returns>
        public char GetBaloonChar(int baloonNum)
        {
            if (baloonNum >= MinBaloon && baloonNum <= MaxBaloon)
            {
                return baloonNum.ToString()[0];
            }
            else
            {
                return '-';
            }
        }

        /// <summary>
        /// This method accepts two integer parameters and uses them to find where on the field is 
        /// the player. Depending on that tha game contimues or is over.
        /// </summary>
        /// <param name="x">The integer the method is called upon.</param>
        /// <param name="y">The integer the method is called upon.</param>
        /// <returns>The method returns a boolean, which indicates wheather the game is over.</returns>
        public bool PopBaloon(int x, int y)
        {
            ////changes the game state and returns boolean,indicating wheater the game is over
            if (this.playField[x - 1, y - 1] == 0)
            {
                Console.WriteLine("Invalid Move! Can not pop a baloon at that place!!");
                return false;
            }
            else
            {
                this.TurnCounter++;
                int currentCell = this.playField[x - 1, y - 1];
                int top = x - 1;
                int bottom = x - 1;
                int left = y - 1;
                int right = y - 1;
                while (top > 0 && (this.playField[top - 1, y - 1] == currentCell))
                {
                    top--;
                }

                while (bottom < 5 && this.playField[bottom + 1, y - 1] == currentCell)
                {
                    bottom++;
                }

                while (left > 0 && this.playField[x - 1, left - 1] == currentCell)
                {
                    left--;
                }

                while (right < 9 && this.playField[x - 1, right + 1] == currentCell)
                {
                    right++;
                }

                for (int i = left; i <= right; i++)
                {
                    ////first remove the elements on the same row and float the elemnts above down
                    if (x == 1)
                    {
                        this.playField[x - 1, i] = 0;
                    }
                    else
                    {
                        for (int j = x - 1; j > 0; j--)
                        {
                            this.playField[j, i] = this.playField[j - 1, i];
                            this.playField[j - 1, i] = 0;
                        }
                    }
                }

                ////if that's enough,just stop
                if (top == bottom)
                {
                    return this.EndGame();
                }
                else
                {   ////otherwise fix the problematic column as well
                    for (int i = top; i > 0; --i)
                    {   ////first float the elements above down and replace them
                        this.playField[i + bottom - top, y - 1] = this.playField[i, y - 1];
                        this.playField[i, y - 1] = 0;
                    }

                    if (bottom - top > top - 1)
                    {   ////is there are more baloons to pop in the column than elements above them, need to pop them as well
                        for (int i = top; i <= bottom; i++)
                        {
                            if (this.playField[i, y - 1] == currentCell)
                            {
                                this.playField[i, y - 1] = 0;
                            }
                        }
                    }
                }

                return this.EndGame();
            }
        }

        /// <summary>
        /// This method accespts no parameters. It checks if the game has ended by searching for
        /// entries in the playfield coordinates that are equal to 0.
        /// </summary>
        /// <returns>The method returns a boolean, which indicates wheather the game is over.</returns>
        public bool GameHasEnded()
        {
            foreach (var s in this.playField)
            {
                if (s != 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This method is used for printing the game board on the console.
        /// </summary>
        public void PrintArray()
        {
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("    --------------------");
            for (int i = 0; i < BoardWidth; i++)
            {
                Console.Write(i.ToString() + " | ");
                for (int j = 0; j < BoardHeight; j++)
                {
                    int baloonNumber = this.playField[i, j];
                    this.SwitchConsoleColor(baloonNumber);
                    char currentChar = this.GetBaloonChar(baloonNumber);
                    Console.Write(currentChar + " ");
                }

                Console.ResetColor();
                Console.WriteLine("| ");
            }

            Console.WriteLine("    --------------------");
            Console.WriteLine("Insert row and column or other command");
        }

        /// <summary>
        /// This method accepts an integer parameter and depending on that it changes the
        /// color with which the baloon number will be printed on the console.
        /// </summary>
        /// <param name="baloonNumber">The integer the method is called upon.</param>
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

        private bool EndGame() 
        {
            Console.WriteLine();
            this.PrintArray();
            Console.WriteLine();
            return this.GameHasEnded();
        }
    } 
}
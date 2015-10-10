// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaloonsState.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that watches for a change in state of the baloons.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Board
{
    using System;
    using System.Linq;

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
    public class Gameboard
    {
        /// <summary>
        /// An integer variable that counts how many times a baloon is popped. When the game
        /// begins it has an initial value 0. After that before the game is over it grows by one
        /// for every baloon po
        /// </summary>
        //private int boardWidth;
        //private int boardHeight;

        //private const int MinBaloon = 1;
        //private const int MaxBaloon = 4;

        private readonly BoardComponent[,] contents;         

        /// <summary>
        /// This method randomly generates the position of the player on the game board
        /// and uses <see cref="PrintArray"/> method to print the board on the console.
        /// </summary>
        public Gameboard(int boardWidth, int boardHeight)
        {
            this.BoardWidth = boardWidth;
            this.BoardHeight = boardHeight;
            this.contents = new BoardComponent[this.BoardHeight, this.BoardWidth]; 
            GetBalloonsOnBoard();                   
        }

        public int BoardWidth { get; protected set; }

        public int BoardHeight { get; protected set; }        

        /// <summary>
        /// This Method generades differnt colors of balloons on the gameboard
        /// </summary>
        public void GetBalloonsOnBoard()
        {    
            Random randomGenerator = new Random();

            for (int i = 0; i < this.BoardHeight; i++)
            {
                for (int j = 0; j < BoardWidth; j++)
                {                       
                    int seed = randomGenerator.Next(0, 4);
                    var balloonFactory = new BalloonMaker();

                    switch (seed)
                    {
                        case 0:
                            this.contents[i, j] = balloonFactory.MakeBalloon(BaloonColor.Red);
                            continue;
                        case 1:
                            this.contents[i, j] = balloonFactory.MakeBalloon(BaloonColor.Blue);
                            continue;
                        case 2:
                            this.contents[i, j] = balloonFactory.MakeBalloon(BaloonColor.Green);
                            continue;
                        case 3:
                            this.contents[i, j] = balloonFactory.MakeBalloon(BaloonColor.Yellow);
                            continue;
                        default:
                            throw new ArgumentException();
                    }
                }
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
            if (!this.contents[x - 1, y - 1].IsActive)
            {
                Console.WriteLine("Invalid Move! Can not pop a baloon at that place!!");
                return false;
            }
            else
            {
                //this.TurnCounter++;
                BoardComponent currentCell = this.contents[x - 1, y - 1];
                int top = x - 1;
                int bottom = x - 1;
                int left = y - 1;
                int right = y - 1;
                while (top > 0 && (this.contents[top - 1, y - 1] == currentCell))
                {
                    top--;
                }

                while (bottom < 5 && this.contents[bottom + 1, y - 1] == currentCell)
                {
                    bottom++;
                }

                while (left > 0 && this.contents[x - 1, left - 1] == currentCell)
                {
                    left--;
                }

                while (right < 9 && this.contents[x - 1, right + 1] == currentCell)
                {
                    right++;
                }

                for (int i = left; i <= right; i++)
                {
                    ////first remove the elements on the same row and float the elemnts above down
                    if (x == 1)
                    {
                        this.contents[x - 1, i].IsActive = false;
                    }
                    else
                    {
                        for (int j = x - 1; j > 0; j--)
                        {
                            this.contents[j, i] = this.contents[j - 1, i];
                            this.contents[j - 1, i].IsActive = false;
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
                        this.contents[i + bottom - top, y - 1] = this.contents[i, y - 1];
                        this.contents[i, y - 1].IsActive = false;
                    }

                    if (bottom - top > top - 1)
                    {   ////is there are more baloons to pop in the column than elements above them, need to pop them as well
                        for (int i = top; i <= bottom; i++)
                        {
                            if (this.contents[i, y - 1] == currentCell)
                            {
                                this.contents[i, y - 1].IsActive = false;
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
            foreach (var s in this.contents)
            {
                if (s.IsActive)
                {
                    return false;
                }
            }

            return true;
        }        

        private bool EndGame() 
        {
            Console.WriteLine();
            //this.PrintArray();
            Console.WriteLine();
            return this.GameHasEnded();
        }

        public BoardComponent GetElement(int row, int col)
        {
            return this.contents[row, col];
        }
    } 
}
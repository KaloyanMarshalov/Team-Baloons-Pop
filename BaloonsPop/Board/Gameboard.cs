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

    using Strategies;

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
        public Gameboard(int boardWidth, int boardHeight, PopStrategy popStrategy, GravityStrategy gravityStrategy)
        {
            this.BoardWidth = boardWidth;
            this.BoardHeight = boardHeight;
            this.contents = new BoardComponent[this.BoardHeight, this.BoardWidth];
            GetBalloonsOnBoard();
            this.PopStrategy = popStrategy;
            this.GravityStrategy = gravityStrategy;

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

        public PopStrategy PopStrategy { get; set; }

        public GravityStrategy GravityStrategy { get; set; }

        /// <summary>
        /// This method accepts two integer parameters and uses them to find where on the field is 
        /// the player. Depending on that tha game contimues or is over.
        /// </summary>
        /// <param name="x">The integer the method is called upon.</param>
        /// <param name="y">The integer the method is called upon.</param>
        /// <returns>The method returns a boolean, which indicates wheather the game is over.</returns>
        public int PopBaloon(int x, int y)
        {
            int result = this.PopStrategy.PopBalloons(x, y, this);
            this.GravityStrategy.Apply(this);
            Console.WriteLine("Result from move {0}", result);
            return result;
        }
        
        public BoardComponent GetElement(int row, int col)
        {
            return this.contents[row, col];
        }

        public void SetElement(int row, int col, BoardComponent component)
        {
            this.contents[row, col] = component;
        }
    }
}
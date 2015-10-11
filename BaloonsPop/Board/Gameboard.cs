// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gameboard.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that holds the state of the gameboard.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace PoppingBaloons.Board
{
    using System;
    using Board.Strategies;
    using PoppingBaloons.Board.BalloonFactory;

    /// <summary>
    /// A class that holds the state of the gameboard.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="Gameboard"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="GetBalloonsOnBoard"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="PopBaloon"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="SetElement"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class Gameboard
    {       
        private readonly BoardComponent[,] contents;

        /// <summary>
        /// A constructor for the class.
        /// </summary>
        /// <param name="boardWidth">The integer the constructor uses.</param>
        /// <param name="boardHeight">The integer the constructor uses.</param>
        /// <param name="popStrategy">The PopStrategy the constructor uses.</param>
        /// <param name="gravityStrategy">The GravityStrategy the constructor uses.</param>
        public Gameboard(int boardWidth, int boardHeight, PopStrategy popStrategy, GravityStrategy gravityStrategy)
        {
            this.BoardWidth = boardWidth;
            this.BoardHeight = boardHeight;
            this.contents = new BoardComponent[this.BoardHeight, this.BoardWidth];
            this.GetBalloonsOnBoard();
            this.PopStrategy = popStrategy;
            this.GravityStrategy = gravityStrategy;
        }

        /// <summary>
        /// Gets or sets the boardwidth.
        /// </summary>
        public int BoardWidth { get; protected set; }

        /// <summary>
        /// Gets or sets the boardheight.
        /// </summary>
        public int BoardHeight { get; protected set; }
        
        /// <summary>
        /// Gets or sets the popstartegy property.
        /// </summary>
        public PopStrategy PopStrategy { get; set; }

        /// <summary>
        /// Gets or sets the gravitystrategy property.
        /// </summary>
        public GravityStrategy GravityStrategy { get; set; }

        /// <summary>
        /// This Method fills the board with balloons of random color.
        /// </summary>
        public void GetBalloonsOnBoard()
        {
            Random randomGenerator = new Random();

            for (int i = 0; i < this.BoardHeight; i++)
            {
                for (int j = 0; j < this.BoardWidth; j++)
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
        /// A method that checks for popped baloons and emprty space below them.
        /// </summary>
        /// <param name="x">The x coordinate the method is called upon.</param>
        /// <param name="y">The y coordinate the method is called upon.</param>
        /// <returns>Returns the number of popped baloons.</returns>
        public int PopBaloon(int x, int y)
        {
            int result = this.PopStrategy.PopBalloons(x, y, this);
            this.GravityStrategy.Apply(this);
            Console.WriteLine("Result from move {0}", result);
            return result;
        }

        /// <summary>
        /// A method that gives the status of the element on given coordinates.
        /// </summary>
        /// <param name="row">The integer the method is called upon.</param>
        /// <param name="col">The integer the method is called upon.</param>
        /// <returns>Return the status of the element on the coordinates.</returns>
        public BoardComponent GetElement(int row, int col)
        {
            return this.contents[row, col];
        }

        /// <summary>
        /// A method that sets the status of the element on given coordinates.
        /// </summary>
        /// <param name="row">The integer the method is called upon.</param>
        /// <param name="col">The integer the method is called upon.</param>
        /// <param name="component">Sets the status of the element on the coordinates.</param>
        public void SetElement(int row, int col, BoardComponent component)
        {
            this.contents[row, col] = component;
        }
    }
}
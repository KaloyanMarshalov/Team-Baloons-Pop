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
    using PoppingBaloons.Board.BalloonFactory;
    using Board.Strategies;
    
    public class Gameboard
    {       
        private readonly BoardComponent[,] contents;
        
        public Gameboard(int boardWidth, int boardHeight, PopStrategy popStrategy, GravityStrategy gravityStrategy)
        {
            this.BoardWidth = boardWidth;
            this.BoardHeight = boardHeight;
            this.contents = new BoardComponent[this.BoardHeight, this.BoardWidth];
            GetBalloonsOnBoard();
            this.PopStrategy = popStrategy;
            this.GravityStrategy = gravityStrategy;
        }

        public int BoardWidth { get; protected set; }

        public int BoardHeight { get; protected set; }

        /// <summary>
        /// This Method fills the board with balloons of random color
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
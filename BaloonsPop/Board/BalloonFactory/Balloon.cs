// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Balloon.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that sets the color and state of a baloon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Board.BalloonFactory
{
    /// <summary>
    /// A class that updates and prints the highscore:
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="Balloon"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="GetValue"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class Balloon : BoardComponent
    {
        private readonly int value = 2;         

        /// <summary>
        /// A constructor that creates new baloons.
        /// </summary>
        /// <param name="color">The string the constructor uses.</param>
        public Balloon(string color)
        {
            this.Color = color;
            this.IsActive = true;
        }   
        
        /// <summary>
        /// A method that gets the value of the current baloon.
        /// </summary>                                                                                       
        public override int GetValue()
        {
            return this.value;
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BonusDecorator.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that returns the sum of the value of the base class and a onus value.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Board
{
    /// <summary>
    /// A class that sets the components of the gameboard.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="GetValue"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class BonusDecorator : BoardComponentDecorator
    {
        private const int BonusValue = 5;

        /// <summary>
        /// A constructor for the class inheriting the base class.
        /// </summary>
        /// <param name="component">The BoardComponent the constructor uses.</param>
        public BonusDecorator(BoardComponent component)
            : base(component)
        { 
        }

        /// <summary>
        /// A method that gets the value of the board component
        /// </summary>
        /// <returns>Returns the sum of it's value and a bonus value.</returns>
        public override int GetValue()
        {
            return base.GetValue() + BonusValue;
        }
    }
}

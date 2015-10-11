// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoardComponentsDecorator.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class used for the decorator pattern.
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
    public abstract class BoardComponentDecorator : BoardComponent
    {
        /// <summary>
        /// An instance of the new decorated component.
        /// </summary>
        private BoardComponent decoratedComponent;

        /// <summary>
        /// The constructor that adds the properties of BoardComponent to the decorated component.
        /// </summary>
        /// <param name="component">An instance of the BoardComponent is passed as parameter.</param>
        protected BoardComponentDecorator(BoardComponent component) 
        {
            this.decoratedComponent = component;
        }

        /// <summary>
        ///  A method that returns the value of the decorated component.
        /// </summary>
        /// <returns>Returns it's value.</returns>
        public override int GetValue()
        {
            return this.decoratedComponent.GetValue();
        }
    }
}
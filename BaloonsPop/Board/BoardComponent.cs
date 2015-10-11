// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoardComponents.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that sets the components of the gameboard.
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
    public abstract class BoardComponent
    {
        private bool isAcctive;
        private string color;

        /// <summary>
        /// Gets or sets if a component of the game board is active or not.
        /// </summary>
        public bool IsActive 
        {
            get
            {
                return this.isAcctive;
            }

            set
            {
                this.isAcctive = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the gameboard components.
        /// </summary>
        public string Color
        {
            get
            {
                return this.color;
            }

            set 
            {
                this.color = value;
            }
        }

        /// <summary>
        /// A void abstarct method that will be overriden by it's inheritors.
        /// </summary>
        public abstract int GetValue();
    }
}
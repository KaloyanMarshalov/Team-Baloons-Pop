// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainMenu.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that prints the main menu on console.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Menu
{
    using System;

    /// <summary>
    /// A class that implements the logic of starting the game.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="PrintMenu"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class MainMenu
    {
        /// <summary>
        /// A method that prints the main menu on the console.
        /// </summary>
        /// <param name="startGame">The string the maethod is called upon.</param>
        /// <param name="quitGame">The string the maethod is called upon.</param>
        public static void PrintMenu(string startGame, string quitGame)
        {
            const string Logo = "         ____  _____  _     _     _____  _____  _     _     _____  _____  _____ \n " +
                          "       | _  ||  _  || |   | |   |  _  ||  _  ||  \\  | |   |  _  ||  _  ||  _  |\n " +
                          "       |   / | |_| || |   | |   | | | || | | || |\\ \\| |   | |_| || | | || |_| |\n" +
                          "        | _ \\ |  _  || |__ | |__ | |_| || |_| || |  \\  |   |  _ _|| |_| ||  _ _|\n" +
                          "        |____||_| |_||____||____||_____||_____||_|   |_|   |_|    |_____||_| \n\n" +
                          "                           Welcome to “Balloons Pops” game :)\n\n" +
                          "                            Please try to pop the balloons!\n" +
                          "__________________________________________________________________________________________\n";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Logo);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                   " + startGame);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                   " + quitGame);
        }
    }
}

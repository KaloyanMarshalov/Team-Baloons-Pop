// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListOfCommands.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that prints a lista of commands on the console.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A class that watches for the game development, drawing the game board
    /// on the console and stopping the game using the following methods: 
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="PrintListOfCommands"/>,</description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class ListOfCommands
    {
        /// <summary>
        /// A void method that prints a list of commands on the console.
        /// </summary>
        public static void PrintListOfCommands()
        {    
            var listOfCommands = new List<string>();

            listOfCommands.Add("List of Commands");
            listOfCommands.Add("---------------------------------------");
            listOfCommands.Add("* Use 'top' to view the top scoreboard!");
            listOfCommands.Add("* Use 'restart' to start a new game!");
            listOfCommands.Add("* Use 'exit' to quit the game!\n");

            foreach (var item in listOfCommands)
            {
                Console.WriteLine(item);
            }
        }
    }
}

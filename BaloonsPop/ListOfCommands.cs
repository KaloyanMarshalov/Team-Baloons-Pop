namespace PoppingBaloons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;     

    public class ListOfCommands
    {
        public static void PrintListOFCommands()
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

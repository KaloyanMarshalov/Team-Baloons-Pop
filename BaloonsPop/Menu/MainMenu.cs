namespace PoppingBaloons.Menu
{
    using System;

    public class MainMenu
    {
        public static void PrintMenu(string startGame, string quitGame)
        {
            string logo = "         ____  _____  _     _     _____  _____  _     _     _____  _____  _____ \n " +
                          "       | _  ||  _  || |   | |   |  _  ||  _  ||  \\  | |   |  _  ||  _  ||  _  |\n " +
                          "       |   / | |_| || |   | |   | | | || | | || |\\ \\| |   | |_| || | | || |_| |\n" +
                          "        | _ \\ |  _  || |__ | |__ | |_| || |_| || |  \\  |   |  _ _|| |_| ||  _ _|\n" +
                          "        |____||_| |_||____||____||_____||_____||_|   |_|   |_|    |_____||_| \n\n" +
                          "                           Welcome to “Balloons Pops” game :)\n\n" +
                          "                            Please try to pop the balloons!\n" +
                          "__________________________________________________________________________________________\n";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(logo);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                   " + startGame);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                   " + quitGame);
        }
    }
}

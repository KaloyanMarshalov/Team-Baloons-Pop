﻿namespace PoppingBaloons
{
    using System;
    using System.Linq;
    using PoppingBaloons.Interfaces;

    public class MainMenu
    {
        public static void Main()
        {
            ILogger logger = ConsoleLogger.LoggerInstance;
            logger.Log(" ____  _____  _     _     _____  _____  _     _     _____  _____  _____  _____ ");
            logger.Log("| _  ||  _  || |   | |   |  _  ||  _  ||  \\  | |   |  _  ||  _  ||  _  ||  ___| ");
            logger.Log("|   / | |_| || |   | |   | | | || | | || |\\ \\| |   | |_| || | | || |_| || |___ ");
            logger.Log("| _ \\ |  _  || |__ | |__ | |_| || |_| || |  \\  |   |  _ _|| |_| ||  _ _| ___  |");
            logger.Log("|____||_| |_||____||____||_____||_____||_|   |_|   |_|    |_____||_|    |_____|  ");
            logger.Log("");
            logger.Log("Welcome to “Balloons Pops” game. Please try to pop the balloons.");
            logger.Log("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            Game game = new Game(logger);

            while (true)
            {
                game.ParseCommand(Console.ReadLine());
            }
        }
    }
}
namespace PoppingBaloons
{
    using System;
    using System.Linq;

    public class BaloonsState
    {
        private int[,] playField;
        public int TurnCounter;
        private Random randomGenerator;
        private int boardWidth = 6;
        private int boardHeight = 10;
        private int minBaloon = 1;
        private int maxBaloon = 4;
       
        public BaloonsState()
        {
            this.TurnCounter = 0;
            this.playField = new int[boardWidth, boardHeight];
            this.randomGenerator = new Random();

            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    playField[i, j] = randomGenerator.Next(1, 5);
                }
            }

            PrintArray();
        }

        char GetBaloonChar(int baloonNum)
        {
            if (baloonNum >= minBaloon && baloonNum <= maxBaloon)
            {
                return baloonNum.ToString()[0];
            }
            else
            {
                return '-';
            }
        }

        public bool PopBaloon(int x, int y)
        {
            //changes the game state and returns boolean,indicating wheater the game is over
            if (playField[x - 1, y - 1] == 0)
            {
                Console.WriteLine("Invalid Move! Can not pop a baloon at that place!!");
                return false;
            }
            else
            {
                TurnCounter++;
                int currentCell = playField[x - 1, y - 1];
                int top = x - 1;
                int bottom = x - 1;
                int left = y - 1;
                int right = y - 1;
                while (top > 0 && (playField[top - 1, y - 1] == currentCell))
                {
                    top--;
                }

                while (bottom < 5 && playField[bottom + 1, y - 1] == currentCell)
                {
                    bottom++;
                }

                while (left > 0 && playField[x - 1, left - 1] == currentCell)
                {
                    left--;
                }

                while (right < 9 && playField[x - 1, right + 1] == currentCell)
                {
                    right++;
                }

                for (int i = left; i <= right; i++)
                {
                    //first remove the elements on the same row and float the elemnts above down
                    if (x == 1)
                    {
                        playField[x - 1, i] = 0;
                    }
                    else
                    {
                        for (int j = x - 1; j > 0; j--)
                        {
                            playField[j, i] = playField[j - 1, i];
                            playField[j - 1, i] = 0;
                        }
                    }
                }

                //if that's enough,just stop
                if (top == bottom)
                {
                    Console.WriteLine();
                    this.PrintArray();
                    Console.WriteLine();
                    return GameHasEnded();
                }
                else
                {   //otherwise fix the problematic column as well
                    for (int i = top; i > 0; --i)
                    {//first float the elements above down and replace them
                        playField[i + bottom - top, y - 1] = playField[i, y - 1];
                        playField[i, y - 1] = 0;
                    }

                    if (bottom - top > top - 1)
                    {   //is there are more baloons to pop in the column than elements above them, need to pop them as well
                        for (int i = top; i <= bottom; i++)
                        {
                            if (playField[i, y - 1] == currentCell)
                            {
                                playField[i, y - 1] = 0;
                            }
                        }
                    }
                }

                Console.WriteLine();
                this.PrintArray();
                Console.WriteLine();
                return GameHasEnded();
            }
        }

        bool GameHasEnded()
        {
            foreach (var s in playField)
            {
                if (s != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public void PrintArray()
        {
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("    --------------------");
            for (int i = 0; i < boardWidth; i++)
            {
                Console.Write(i.ToString() + " | ");
                for (int j = 0; j < boardHeight; j++)
                {
                    int baloonNumber = playField[i, j];
                    SwitchConsoleColor(baloonNumber);
                    char currentChar = GetBaloonChar(baloonNumber);
                    Console.Write(currentChar + " ");
                }
                Console.ResetColor();
                Console.WriteLine("| ");
            }

            Console.WriteLine("    --------------------");
            Console.WriteLine("Insert row and column or other command");
        }
        private void SwitchConsoleColor(int baloonNumber)
        {
            switch (baloonNumber)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
    }
}
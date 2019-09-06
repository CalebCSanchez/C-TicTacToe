using System;

namespace TicTacToe
{
    
    class Program
    {
        static int [,] board;
        class PlayerStatistics
        {
            public string name;
            public int numOfGames = 0;
            public int numOfWins = 0;
            private float percentageWins;
        }
        static void PressToContinue()         //Created to allow fast executions to be seen on Console
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
        
        static bool WinCondition(int player)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (k == 0)
                    {
                        if (board[j,k] == player && board[j,k+1] == player && board[j,k+2] == player)
                        {
                            return true;
                        }
                    }
                    if (j == 0)
                    {
                        if (board[j,k] == player && board[j+1,k] == player && board[j+2,k] == player)
                        {
                            return true;
                        }
                    }
                    if (j == 0 && k == 0)
                    {
                        if (board[j,k] == player && board[j+1,k+1] == player && board[j+2,k+2] == player)
                        {
                            return true;
                        }
                        if (board[j,k+2] == player && board[j+1,k+1] == player && board[j+2,k] == player)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        static int CheckWin(PlayerStatistics player)
        {
            if (WinCondition(1))
            {
                return 1;
            }
            if (WinCondition(2))
            {
                return 2;
            }
            int checkTie = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i,j] != 0)
                    {
                        ++checkTie;
                    } 
                }
            }
            if (checkTie == 9)
            {
                return 3;
            }
            return 0;
        }

        static void TTT_AI(int difficulty)
        {
            if (difficulty == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i,j] == 0)
                        {
                            board[i,j] = 2;
                            return;
                        }
                    }
                }
            }
        }
        static void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(board[i,0] + "|" + board[i,1] + "|" + board[i,2]);
                if (i != 2)
                {
                Console.WriteLine("__________");
                }
            }
        }
        static void NewGame(PlayerStatistics player, int difficulty)
        {
            player.numOfGames += 1;
            board = new int[3,3];
            while(true)
            {
                PrintBoard();
                if (CheckWin(player) != 0)
                {
                    if (CheckWin(player) == 1)
                    {
                        Console.WriteLine(player.name + " wins!");
                        player.numOfWins += 1;
                    }
                    if (CheckWin(player) == 2)
                    {
                        Console.WriteLine("You loose. :(");

                    }
                    if (CheckWin(player) ==3)
                    {
                        Console.WriteLine("Tie Game!");
                    }
                    break;
                }
                while (true)
                {
                    int row = -1;
                    int column = -1;
                    Console.WriteLine("Pick the row");
                    row = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("Pick the column");
                    column = int.Parse(Console.ReadLine()) - 1;

                    if (column < 0 || column > 2)
                    {
                        Console.WriteLine("Column " + column + " does not exist.");
                        continue;
                    }
                    if (row < 0 || row > 2)
                    {
                        Console.WriteLine("Row " + row + " does not exist.");
                        continue;

                    }
                    if (board[row,column] == 1 || board[row,column] == 2)
                    {
                        Console.WriteLine("space is already taken by player " + board[row, column]);
                        continue;
                    }
                    board[row,column] = 1;
                    break;
                }
                TTT_AI(difficulty);


            }
        }
        static void Main(string[] args)
        {
            PlayerStatistics currentPlayer;
            //TODO: Check for save file.
            //TODO: If no save. 
            PlayerStatistics newPlayer = new PlayerStatistics();
            currentPlayer = newPlayer;
            Console.WriteLine("Type your name: ");
            currentPlayer.name = Console.ReadLine();
            
            NewGame(currentPlayer, 0);



            PressToContinue();

        }
    }
}

using System;

namespace TicTacToe
{
    
    class Program
    {
        
        static void PressToContinue()         //Created to allow fast executions to be seen on Console

        {
            Console.WriteLine("Press any key to continue.");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PressToContinue();
        }
    }
}

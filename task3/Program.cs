using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace task3
{
    class Program
    {
        static void Main(string[] movesArgs)
        {
            var moves = new List<string>(movesArgs);
            PrintIfIncorrectInput(moves);
            var table = new HelpTable(moves);
            var key = new KeyGenerator();
            var pcMove = PCPlays(moves);
            var playerMove = 0;

            Console.WriteLine("HMAC: " + HMACGenerator.HMACGenerating(key.keyLoc, moves[pcMove]));
            playerMove = PlayerPlays(moves, table);
            Console.WriteLine("Computer move: " + moves[pcMove]);
            PrintResult(moves, pcMove, playerMove);
            key.PrintingKey(key.keyLoc);
        }

        private static int PlayerPlays(List<string> moves, HelpTable table)
        {
            int playerMove;

            while (true)
            {
                PrintMenu(moves);
                playerMove = CheckingPlayerMove(moves, PlayerMakesMove(), table) - 1;
                if (playerMove >= 0)
                {
                    Console.WriteLine("Your move: " + moves[playerMove]);
                    break;
                }
            }

            return playerMove;
        }

        private static void PrintMenu(List<string> moves)
        {
            Console.WriteLine("Available moves:");
            for(int i = 0; i < moves.Count; i++)
                Console.WriteLine(i + 1 + " - " + moves[i]);
            Console.WriteLine("0 - exit\n? - help");
        }

        private static int PCPlays(List<string> moves)
        {
            return RNGCryptoServiceProvider.GetInt32(0, moves.Count);
        }

        private static string PlayerMakesMove()
        {
            Console.Write("Enter your move: ");

            return Console.ReadLine();
        }

        private static void PrintResult(List<string> moves, int pcMove, int playerMove)
        {
            string result = WinCondition.DetermingTheResult(moves, pcMove, playerMove);

            if (result != "DRAW")
                Console.WriteLine("You " + result + "!");
            else
                Console.WriteLine(result);
        }

        private static int CheckingPlayerMove(List<string> moves, string playerMove, HelpTable table)
        {
            switch(playerMove)
            {
                case "0":
                    Console.WriteLine("Bye)");
                    Environment.Exit(0);
                    return 0;
                case "?":
                    Console.WriteLine();
                    table.DrawTable(table.tableLoc);
                    return -1;
            }

            return CheckingOutOfMovesRange(moves, playerMove);
        }

        private static int CheckingOutOfMovesRange(List<string> moves, string playerMove)
        {
            int move;

            try
            {
                move = Convert.ToInt32(playerMove);
                if (move > 0 & move <= moves.Count)
                return move;
            }
            catch{}

            return -1;
        }

        private static bool CheckingCorrectInput(List<string> moves)
        {
            if (moves.Count < 3 || moves.Count % 2 != 1)
                return false;
            if (moves.Count != moves.Distinct().Count())
                return false;

            return true;
        }

        private static void PrintIfIncorrectInput (List<string> moves)
        {
            if (!CheckingCorrectInput(moves))
            {
                Console.WriteLine("Incorrect input!\nExample of correct input: rock paper scissors");
                Environment.Exit(0);
            }
        }
    }
}

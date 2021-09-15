using System.Collections.Generic;

namespace task3
{
    static class WinCondition
    {
        public static string DetermingTheResult(List<string> moves, int pcMove, int playerMove)
        {
            if (pcMove == playerMove)
                return "DRAW";
            else 
                return CalculatingTheWinner(AddingTheFirstHalf(moves), pcMove, playerMove, moves.Count / 2);
        }

        private static string CalculatingTheWinner(List<string> movesExt, int pcMove, int playerMove, int halfMoves)
        {
            for (int i = halfMoves; i > 0; i--)
                if (movesExt[pcMove + i] == movesExt[playerMove])
                    return "WIN";

            return "LOSE";
        }

        private static List<string> AddingTheFirstHalf(List<string> moves)
        {
            List<string> movesExt = new List<string>(moves);

            for (int i = 0; i <= moves.Count / 2; i++)
                movesExt.Add(moves[i]);

            return movesExt;
        }
    }
}

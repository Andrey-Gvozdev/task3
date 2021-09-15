using System.Collections.Generic;
using ConsoleTables;

namespace task3
{
    class HelpTable
    {
        public ConsoleTable tableLoc;

        public HelpTable(List<string> moves)
        {
            tableLoc = CreateTable(moves);
        }

        private void AddingRows(List<string> moves, ConsoleTable table)
        {
            for (int i = 0; i < moves.Count; i++)
            {
                List<string> rowList = new List<string>();
                rowList.Add(moves[i]);
                for (int j = 0; j < moves.Count; j++)
                    rowList.Add(WinCondition.DetermingTheResult(moves, i, j));
                table.AddRow(rowList.ToArray());
            }
        }

        private ConsoleTable CreateTable(List<string> moves)
        {
            var table = new ConsoleTable("PC\\User");

            table.AddColumn(moves);
            AddingRows(moves, table);

            return table;
        }

        public void DrawTable(ConsoleTable table)
        {
            table.Write(Format.Alternative);
        }
    }
}

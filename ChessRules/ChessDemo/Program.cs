using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChessRules;

namespace ChessDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Chess chess = new Chess();

            while (true)
            {
                Console.WriteLine(chess.fen);
                Console.WriteLine(ChessToAscii(chess));
                foreach (string moves in chess.YieldValidMoves())
                    Console.WriteLine(moves);
                string move = Console.ReadLine();
                if (move == "") break;
                chess = chess.Move(move);
            }
        }
        static int NextMoves(int step, Chess chess)
        {
            if (step == 0)
                return 1;
            int count = 0;
            foreach (string moves in chess.YieldValidMoves())
                count += NextMoves(step - 1, chess.Move(moves));
            return count;
        }
        static string ChessToAscii(Chess chess)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  +-----------------+");
            for (int y = 7; y >= 0; y--)
            {
                sb.Append(y + 1);
                sb.Append(" | ");
                for (int x = 0; x < 8; x++)
                    sb.Append(chess.GetFigureAt(x, y) + " ");
                sb.AppendLine("| ");
            }
            sb.AppendLine("  +-----------------+");
            sb.AppendLine("    a b c d e f g h  ");
            if (chess.IsCheck)
                sb.AppendLine("IS CHECK");
            if (chess.IsCheckmate)
                sb.AppendLine("IS CHECKMATE");
            if (chess.IsStalemate)
                sb.AppendLine("IS STALEMATE");
            return sb.ToString();
        }
    }
}

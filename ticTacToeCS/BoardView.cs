
using System;

namespace ticTacToeCS
{
    class BoardView
    {
        public static void Show(BoardModel boardModel)
        {
            Console.Clear();
            var checkWinner = boardModel.isWinner();

            var content = boardModel.Content;
            Console.WriteLine("  a b c");
            Console.WriteLine(" ┌─────┐");
            ShowOneLine(0, content);
            ShowOneLine(3, content);
            ShowOneLine(6, content);
            Console.WriteLine(" └─────┘");
            if (checkWinner != CellContent.None)
            {
                var Winner = checkWinner == CellContent.Circle ? "Computeren" : "Du";
                Console.WriteLine("\n" + Winner + " har VUNNET!");
                Environment.Exit(0);
            }
        }

        private static void ShowOneLine(int startIndex, CellContent[] content)
        {
            var lineNo = 1 + startIndex / 3;
            Console.Write(lineNo + "│");
            for (var i = startIndex; i < startIndex + 3 ; i++)
            {
                if (i> startIndex) Console.Write(" ");
                var isBlank = content[i] == CellContent.None;
                var isCross = content[i] == CellContent.Cross;

                Console.Write(isBlank ? ' ' : isCross ? 'x' : 'o');
            }

            Console.WriteLine("│");
        }
    }
}

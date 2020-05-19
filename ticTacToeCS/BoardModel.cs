
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ticTacToeCS
{

    class BoardModel
    {
        public bool IsGameStopped { get; private set; }
        public CellContent[] Content { get; private set; }
        private readonly Random _random = new Random();
        private readonly Combo[] _winningCombos;

        public BoardModel()
        {
            Content = new CellContent[9];
            _winningCombos = new[]
            {
                new Combo(Content, 0, 1, 2),
                new Combo(Content, 3, 4, 5),
                new Combo(Content, 6, 7, 8),
                new Combo(Content, 0, 3, 6),
                new Combo(Content, 1, 4, 7),
                new Combo(Content, 2, 5, 8),
                new Combo(Content, 0, 4, 8),
                new Combo(Content, 2, 4, 6),
            };


        }

        public CellContent isWinner()
        {
            return _winningCombos.Select(c => c.IsWinner()).FirstOrDefault(x => x != CellContent.None);
        }

        public bool setCross(string positionStr)
        {
            var col = positionStr[0] == 'a' ? 0 : positionStr[0] == 'b' ? 1 : 2;
            var row = Convert.ToInt32(positionStr[1].ToString()) -1;

            var position = row * 3 + col;
            Content[position] = CellContent.Cross;
            return true;
        }

        public void SetRandomCircle()
        {
            var randomIndex = _random.Next(0, 8);
            while (Content[randomIndex] != CellContent.None)
            {
                randomIndex = _random.Next(0, 8);
            }

            Content[randomIndex] = CellContent.Circle;
        }
    }
}

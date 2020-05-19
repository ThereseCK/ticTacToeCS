
using System;
using System.IO;
using System.Threading;

namespace ticTacToeCS
{
    class Program
    {
        static void Main(string[] args)
        {
           var boardModel = new BoardModel();
           while (true)
           {
                BoardView.Show(boardModel);
                Console.Write("Skriv inn hvor du vil sette kryss ( f.eks \"a2\"; )");
                var validInput = true;
                do
                {
                    if (!validInput) Console.WriteLine("Ta ett nytt trekk");
                    var position = Console.ReadLine();

                    validInput = boardModel.setCross(position);
                } while (!validInput);

               BoardView.Show(boardModel);
               
               Thread.Sleep(1000);

               boardModel.SetRandomCircle();


           }
        }

        
    }
}

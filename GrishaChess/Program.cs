using ChessGameLibrary;
using System;

namespace GrishaChess
{
    class Program
    {
        public const int x = 50;//32;
        public const int y = 50;
        private 
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.SetWindowSize(x + 1, y + 1);
            Console.CursorVisible = false;

            new GameBoard().SetPlayersName().PlayGame();
        }
    }
}

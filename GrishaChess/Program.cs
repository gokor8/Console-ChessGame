using ChessGameLibrary;
using ChessGameLibrary.FieldFactory;
using System;

namespace GrishaChess
{
    class Program
    {
        public const int x = 46;//32;
        public const int y = 27;
        private 
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.SetWindowSize(x + 1, y + 1);
            Console.SetBufferSize(x + 1, y + 1);
            Console.CursorVisible = false;

            new GameBoard().PlayGame();
        }
    }
}

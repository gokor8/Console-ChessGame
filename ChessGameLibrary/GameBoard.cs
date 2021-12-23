using ChessGameLibrary.FieldFactory;
using ChessGameLibrary.FieldFactory.Fields;
using ChessGameLibrary.Players;
using ChessGameLibrary.Printers;
using System;

namespace ChessGameLibrary
{
    public class GameBoard
    {
        bool canPlay = true;
        public Player1 player1 = new Player1();
        public Player2 player2 = new Player2();
        public IFigure[,] boardField { get; private set; }
        IField gamefield;

        public GameBoard()
        {
            gamefield = new DefaultFactoryField().CreateField(player1.figures, player2.figures);
            boardField = gamefield.GetField();
        }

        public GameBoard SetPlayersName()
        {
            Console.WriteLine("Введите имя первого игрока");
            player1.Name = Console.ReadLine();

            Console.WriteLine("Введите имя второго игрока");
            player2.Name = Console.ReadLine();

            return this;
        }

        public void PlayGame()
        {
            int motion = 1;
            IPlayer currentPlayer = player1;
            int y = 0, x = 0;
            ConsolePrinter printer = new ConsolePrinter();

            while (canPlay)
            {
                CollectField();

                if (motion % 2 == 0)
                    currentPlayer = player1;
                else
                    currentPlayer = player2;

                IFigure currentFigure = null;

                while (currentFigure == null)
                {
                    printer.Print("Введите координаты");
                    CoordinatsChoosing(ref x, ref y, currentPlayer);
                    currentFigure = currentPlayer.GetFigure(y, x);
                }

                bool WasMotion = false;
                while (WasMotion == false)
                {
                    Console.WriteLine("Выберите куда вы сделаете ход: ");
                    CoordinatsChoosing(ref x, ref y, currentPlayer);
                    WasMotion = currentFigure.TryGoMotion(boardField);
                }
            }
        }

        void CoordinatsChoosing(ref int x, ref int y, in IPlayer currentPlayer)
        {
            ConsolePrinter printer = new ConsolePrinter();

            x = Convert.ToInt32(printer.GetInsertedText());
            printer.Print($"{currentPlayer.Name} Выберите координату X:");
            y = Convert.ToInt32(printer.GetInsertedText());
            printer.Print($"{currentPlayer.Name} Выберите координату Y:");
        }

        public string CollectField()
        {
            string field = "";
            var fieldArray = gamefield.GetField();

            for(int y = 0; y < fieldArray.GetLength(0); y++)
            {
                for(int x =0; x < fieldArray.GetLength(1); x++)
                {
                    field += $"|{fieldArray[y,x].figureChar}|";
                }
                field += "\r\n";
                for(int x = 0;x < fieldArray.GetLength(1); x++)
                    field += "----";

                field += "\r\n";
            }

            return field;
        }
    }
}

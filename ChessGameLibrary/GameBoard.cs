using ChessGameLibrary.FieldFactory;
using ChessGameLibrary.FieldFactory.Fields;
using ChessGameLibrary.Figures;
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

        IField gameFactoryField;
        public IFigure[,] boardField { get; private set; }

        ConsolePrinter printer = new ConsolePrinter();

        public GameBoard()
        {
            gameFactoryField = new DefaultFactoryField().CreateField(player1.figures, player2.figures);
            boardField = gameFactoryField.GetField();
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
            int motionCount = 1;
            IPlayer currentPlayer = player1;

            while (canPlay)
            {
                int y = 0, x = 0;

                printer.Print(MakeLayout());
                printer.Print($"Число ходов: {motionCount - 1}");

                if (!currentPlayer.figures.Exists(f => f is King))
                    break;

                if (motionCount % 2 != 0)
                    currentPlayer = player1;
                else
                    currentPlayer = player2;

                IFigure currentFigure = null;

                while (currentFigure == null)
                {
                    printer.Print("------------------");
                    printer.Print("Введите координаты");
                    printer.Print("------------------\r\n");
                    CoordinatsChoosing(ref x, ref y, currentPlayer);
                    currentFigure = currentPlayer.GetFigure(new Point(x, y));
                }

                bool WasMotion = false;
                while (WasMotion == false)
                {
                    printer.Print("-----------------------------");
                    printer.Print("Выберите куда вы сделаете ход");
                    printer.Print("-----------------------------\r\n");
                    CoordinatsChoosing(ref x, ref y, currentPlayer);
                    WasMotion = currentFigure.TryGoMotion(boardField, currentPlayer, x, y);
                }

                motionCount++;
            }

            Console.WriteLine($"Победил {currentPlayer.Name}");
        }

        void CoordinatsChoosing(ref int x, ref int y, in IPlayer currentPlayer)
        {
            char key;
            printer.Print($"{currentPlayer.Name} Выберите координату X: ");
            key = printer.GetInsertedKey().KeyChar;

            if (char.IsDigit(key))
                x = int.Parse(key.ToString());
            else
                x = -1;
            printer.Print("\r\n");

            printer.Print($"{currentPlayer.Name} Выберите координату Y: ");
            key = printer.GetInsertedKey().KeyChar;
            if (char.IsDigit(key))
                y = int.Parse(key.ToString());
            else
                y = -1;

            printer.Print("\r\n");
        }

        string MakeLayout()
        {
            string field = " |0||1||2||3||4||5||6||7|\r\n";
                  field += " ------------------------\r\n";
            var fieldArray = boardField;

            for(int y = 0; y < fieldArray.GetLength(0); y++)
            {
                field += y;
                for(int x =0; x < fieldArray.GetLength(1); x++)
                {
                    field += $"|{fieldArray[y,x].figureChar}|";
                }
                field += "\r\n";
                for(int x = 0;x < fieldArray.GetLength(1); x++)
                    field += "---";

                field += "\r\n";
            }

            return field;
        }
    }
}

using ChessGameLibrary.FieldFactory;
using ChessGameLibrary.FieldFactory.Fields;
using ChessGameLibrary.Players;
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
            while(canPlay)
            {
                PrintField();
            }
        }

        public string PrintField()
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

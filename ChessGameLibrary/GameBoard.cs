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
        IField field;

        public GameBoard()
        {
            field = new DefaultFactoryField().CreateField(player1.figures, player2.figures);
            boardField = field.GetField();
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
                 
            }
        }

        public void PrintField()
        {
           // for(int i = 0; i< )
        }
    }
}

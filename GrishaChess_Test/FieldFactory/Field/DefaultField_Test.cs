using ChessGameLibrary;
using ChessGameLibrary.FieldFactory.Fields;
using ChessGameLibrary.Players;
using System;
using Xunit;

namespace GrishaChess_Test
{
    public class DefaultField_Test
    {
        [Fact]
        public void SetFigures_EmptyArray_ReturnFull()
        {
            Player1 player1 = new Player1();
            Player2 player2 = new Player2();
            IFigure[,] chessFigures = new IFigure[8, 8];

            chessFigures = new DefaultField(chessFigures ,player1.figures, player2.figures).GetField();

            Assert.NotNull(chessFigures);
        }
    }
}

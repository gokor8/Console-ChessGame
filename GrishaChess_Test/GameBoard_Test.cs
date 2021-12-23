using ChessGameLibrary;
using ChessGameLibrary.Figures;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace GrishaChess_Test
{
    public class GameBoard_Test
    {
        GameBoard gameBoard; 
        public GameBoard_Test()
        {
            gameBoard = new GameBoard();
        }

        [Fact]
        public void InitializeGM_ReturnNotNullboardField()
        {
            Assert.NotNull(gameBoard.boardField);
        }

        [Fact]

        public void InitializeGM_ReturnNotNullPlayer1()
        {
            int elephantPositionY1 = gameBoard.player1.figures.First(f => f is Elephant).points.PositionY;
            int elephantPositionY2 = gameBoard.player1.figures.Last(f => f is Elephant).points.PositionY;

            Assert.True(gameBoard.player1.figures.Count == 16 && (elephantPositionY1 != elephantPositionY2));
        }

        [Fact]
        public void InitializeGM_ReturnNotNullPlayer2()
        {
            int elephantPositionX1 = gameBoard.player2.figures.First(f => f is Elephant).points.PositionX;
            int elephantPositionX2 = gameBoard.player2.figures.Last(f => f is Elephant).points.PositionX;

            Assert.True(gameBoard.player2.figures.Count == 16 && (elephantPositionX1 != elephantPositionX2));
        }

        [Fact]
        public void PrintField_ReturnFullField()
        {
            string field = gameBoard.CollectField();

            Debug.WriteLine(field);
        }
    }
}

using ChessGameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GrishaChess_Test
{
    public class GameBoard_Test
    {
        [Fact]
        public void InitializeGM_ReturnNotNullboardField()
        {
            GameBoard gameBoard = new GameBoard();

            Assert.NotNull(gameBoard.boardField);
        }

        [Fact]

        public void InitializeGM_ReturnNotNullPlayer1()
        {
            GameBoard gameBoard = new GameBoard();

            Assert.True(gameBoard.player1.figures.Count == 16 && gameBoard.player1.Name != null);
        }

        [Fact]
        public void InitializeGM_ReturnNotNullPlayer2()
        {
            GameBoard gameBoard = new GameBoard();

            Assert.True(gameBoard.player2.figures.Count != 16 && gameBoard.player2.Name != null);
        }
    }
}

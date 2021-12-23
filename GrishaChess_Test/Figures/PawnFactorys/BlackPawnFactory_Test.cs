using ChessGameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GrishaChess_Test.Figures.PawnFactorys
{
    public class BlackPawnFactory_Test
    {
        GameBoard gameBoard;
        public BlackPawnFactory_Test()
        {
            gameBoard = new GameBoard();
        }

        [Theory]
        [InlineData(1,3)]
        [InlineData(1,4)]
        public void TryGoMotion_TheoryData_ReturnPawnY5(int x, int y)
        {

        }
    }

}

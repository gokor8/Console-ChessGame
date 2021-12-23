using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    public class EmptyPoint : IFigure
    {
        public char figureChar => ' ';

        public int[] triggers { get; private set; } = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };

        public Point points { get; set; } = new Point(0, 0);

        public IFigure CreateColne()
        {
            return new EmptyPoint();
        }

        public bool TryGoMotion(IFigure[,] figures, IPlayer currentPlayer, int x, int y)
        {
            return true;
        }
    }
}

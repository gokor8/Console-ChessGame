using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    public class EmptyPoint : IFigure
    {
        public char figureChar => '☆';

        public int[] triggers { get; private set; } = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };

        public int PostitionX { get; set; }
        public int PostitionY { get; set; }

        public IFigure CreateColne()
        {
            return new EmptyPoint();
        }

        public bool TryGoMotion(IFigure[,] figures = null)
        {
            return true;
        }
    }
}

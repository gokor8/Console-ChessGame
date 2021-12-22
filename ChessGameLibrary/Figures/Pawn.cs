using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    class Pawn : IFigure
    {
        public int[] triggers { get; private set; } = new int[] {0,1,2,3,4,5,6,7};
        public int PostitionX { get; set; }
        public int PostitionY { get; set; }
        public char figureChar => '♙';

        public void TryGoMotion()
        {

        }
    }
}

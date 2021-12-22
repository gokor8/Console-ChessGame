using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    class Rook : IFigure
    {
        public Rook(params int[] triggers)
        {
            this.triggers = triggers;
        }
        public int PostitionX { get; set; }
        public int PostitionY { get; set; }
        public int[] triggers { get; private set; }
        public char figureChar => '♖';

        public void TryGoMotion()
        {

        }
    }
}

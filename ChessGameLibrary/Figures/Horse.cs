using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    class Horse : IFigure
    {
        public Horse(params int[] triggers)
        {
            this.triggers = triggers;
        }
        public int[] triggers { get; private set; }
        public int PostitionX { get; set; }
        public int PostitionY { get; set; }
        public char figureChar => '♘';

        public void TryGoMotion()
        {

        }
    }
}

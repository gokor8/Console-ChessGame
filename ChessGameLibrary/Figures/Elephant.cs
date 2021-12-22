using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    class Elephant : IFigure
    {
        public Elephant(params int[] triggers)
        {
            this.triggers = triggers;
        }
        public int[] triggers { get; private set; }
        public char figureChar => '♖';
        public int PostitionX { get; set; }
        public int PostitionY { get; set; }
        public void TryGoMotion()
        {

        }
    }
}

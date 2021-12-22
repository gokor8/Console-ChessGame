using ChessGameLibrary.FieldFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    public class Pawn : IFigure
    {
        public Pawn(int[] triggres = default)
        {
            PostitionX = 0;
            PostitionY = 0;
        }
        public int[] triggers { get; private set; } = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        public int PostitionX { get; set; }
        public int PostitionY { get; set; }
        public char figureChar => '♙';

        public IFigure CreateColne()
        {
            return new Pawn(triggers);
        }

        public void TryGoMotion()
        {

        }
    }
}

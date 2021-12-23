using ChessGameLibrary.FieldFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    public class King : IFigure
    {
        public King(params int[] triggers)
        {
            this.triggers = triggers;

            points = new Point(0, 0);
        }
        public int[] triggers { get; private set; }
        public Point points { get; set; }
        public char figureChar => '♔';

        public IFigure CreateColne()
        {
            return new King(triggers);
        }

        public bool TryGoMotion(IFigure[,] figures, int x, int y)
        {
            return true;
        }
    }
}

using ChessGameLibrary.FieldFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    public abstract class Pawn : IFigure
    {
        public Pawn()
        {
            points = new Point(0, 0);
        }
        public int[] triggers { get; private set; } = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        public Point points { get; set; }
        public char figureChar => '♙';

        protected bool _isFirstMotion = true;

        protected List<Point> _motions;

        protected List<Point> _attacks;

        public abstract IFigure CreateColne();

        public abstract bool TryGoMotion(IFigure[,] figures, int x, int y);
    }
}

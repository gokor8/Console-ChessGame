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
            points = new Point(0, 0);
        }
        public int[] triggers { get; private set; } = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        public Point points { get; set; }
        public char figureChar => '♙';

        private bool _isFirstMotion = true;

        private List<Point> _motions;

        public IFigure CreateColne()
        {
            return new Pawn(triggers);
        }

        public bool TryGoMotion(IFigure[,] figures, int x, int y)
        {
            List<int> motions = new List<int>();
            if (_isFirstMotion)
                motions = new List<int>() { PostitionY + 2 };
        }

        private void GoHorizontalMotion(IFigure[,] figures, int x, int y)
        {
            
        }
    }
}

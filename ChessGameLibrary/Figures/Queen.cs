using ChessGameLibrary.FieldFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    public class Queen : IFigure
    {
        public Queen(params int[] triggers)
        {
            this.triggers = triggers;

            points = new Point(0, 0);
        }
        public Point points { get; set; }
        public int[] triggers { get; private set; }
        public char figureChar => '♕';

        public IFigure CreateColne()
        {
            return new Queen(triggers);
        }

        public bool TryGoMotion(IFigure[,] figures, int x, int y)
        {
            
        }
    }
}

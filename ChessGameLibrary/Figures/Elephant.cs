using ChessGameLibrary.FieldFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    public class Elephant : IFigure
    {
        public Elephant(params int[] triggers)
        {
            this.triggers = triggers;

            points = new Point(0,0);
        }
        public int[] triggers { get; private set; }
        public char figureChar => '♖';
        public Point points { get; set; }

        public IFigure CreateColne()
        {
            return new Elephant(triggers);
        }

        public bool TryGoMotion(IFigure[,] figures)
        {
            
        }
    }
}

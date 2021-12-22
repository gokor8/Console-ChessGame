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

            PostitionX = 0;
            PostitionY = 0;
        }
        public int PostitionX { get; set; }
        public int PostitionY { get; set; }
        public int[] triggers { get; private set; }
        public char figureChar => '♕';

        public IFigure CreateColne()
        {
            return new Queen(triggers);
        }

        public void TryGoMotion()
        {
            
        }
    }
}

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

            PostitionX = 0;
            PostitionY = 0;
        }
        public int[] triggers { get; private set; }
        public char figureChar => '♖';
        public int PostitionX { get; set; }
        public int PostitionY { get; set; }

        public IFigure CreateColne()
        {
            return new Elephant(triggers);
        }

        public void TryGoMotion()
        {
            
        }
    }
}

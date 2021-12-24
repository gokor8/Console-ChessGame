using ChessGameLibrary.FieldFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    public class Horse : IFigure
    {
        public Horse(params int[] triggers)
        {
            this.triggers = triggers;

            points = new Point(0, 0);
        }
        public int[] triggers { get; private set; }
        public Point points { get; set; }
        public char figureChar => '♘';
        public List<IFigure> playerFigures { get; private set; }

        public Horse(List<IFigure> playerFigures, params int[] triggers)
        {
            this.triggers = triggers;

            this.playerFigures = playerFigures;
            points = new Point(0, 0);
        }
        public IFigure CreateColne()
        {
            return new Horse(playerFigures, triggers);
        }
        public void Destroy()
        {
            playerFigures.Remove(this);
        }

        public bool TryGoMotion(IFigure[,] figures, IPlayer currentPlayer, int x, int y)
        {
            return true;
        }
    }
}

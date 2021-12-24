using ChessGameLibrary.FieldFactory;
using System.Collections.Generic;

namespace ChessGameLibrary.Figures
{
    public class Queen : IFigure, ICloneableFigure
    {
        public Point points { get; set; }
        public int[] triggers { get; private set; }
        public char figureChar => '♕';
        public List<IFigure> playerFigures { get; private set; }

        public Queen(List<IFigure> playerFigures, params int[] triggers)
        {
            this.triggers = triggers;

            this.playerFigures = playerFigures;
            points = new Point(0, 0);
        }
        public IFigure CreateColne()
        {
            return new Queen(playerFigures, triggers);
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

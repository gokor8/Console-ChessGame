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

        protected List<Point> motions
        {
            get
            {
                return getMotions();
            }
        }

        public abstract IFigure CreateColne();
        protected abstract List<Point> getMotions();

        public bool TryGoMotion(IFigure[,] figures, IPlayer currentPlayer, int x, int y)
        {
            bool isExcecuting = false;
            Point action = null;

            action = motions?.FirstOrDefault(m => m.PositionX == x && m.PositionY == y);

            if (action != null)
                if (currentPlayer.GetFigure(action) == null)
                {
                    if (figures[action.PositionY, action.PositionX] is EmptyPoint
                        || (figures[action.PositionY, action.PositionX] is IFigure && figures[action.PositionY, action.PositionX] is not EmptyPoint))
                    {
                        figures[action.PositionY, action.PositionX] = figures[points.PositionY, points.PositionX];
                        figures[points.PositionY, points.PositionX] = new EmptyPoint();
                        points.PositionY = action.PositionY;
                        points.PositionX = action.PositionX;
                        isExcecuting = true;
                    }
                }

            return isExcecuting;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

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

        protected bool isFirstMotion = true;

        public List<Point> attacks
        {
            get
            {
                return getAttacks();
            }
        }
        public List<Point> motions
        {
            get
            {
                return getMotions();
            }
        }

        public abstract IFigure CreateColne();
        protected abstract List<Point> getMotions();
        protected abstract List<Point> getAttacks();

        public bool TryGoMotion(IFigure[,] figures, IPlayer currentPlayer, int x, int y)
        {
            bool Executed = false;
            Point actualAction = null;
            
            Point motion = motions?.FirstOrDefault(m => m.PositionX == x && m.PositionY == y);
            Point attack = attacks?.FirstOrDefault(m => m.PositionX == x && m.PositionY == y);

            if(motion != null)
                if (figures[motion.PositionY, motion.PositionX] is EmptyPoint)
                    actualAction = motion;
            if (attack != null)
                 if (figures[attack.PositionY, attack.PositionX] is IFigure && figures[attack.PositionY, attack.PositionX] is not EmptyPoint)
                    actualAction = attack;

            if (actualAction != null && currentPlayer.GetFigure(actualAction) == null)
            {
                figures[actualAction.PositionY, actualAction.PositionX] = figures[points.PositionY, points.PositionX];
                figures[points.PositionY, points.PositionX] = new EmptyPoint();
                points.PositionY = actualAction.PositionY;
                points.PositionX = actualAction.PositionX;

                isFirstMotion = false;
                Executed = true;
            }

            return Executed;
        }
    }
}

using ChessGameLibrary.FieldFactory;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameLibrary.Figures
{
    public abstract class Pawn : IFigure, ICloneableFigure
    {
        public int[] triggers { get; private set; } = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        public Point points { get; set; }
        public char figureChar => '♙';

        protected bool isFirstMotion = true;

        public List<IFigure> playerFigures {get; private set;}

        public Pawn(List<IFigure> playerFigures)
        {
            this.playerFigures = playerFigures;
            points = new Point(0, 0);
        }

        public abstract void Destroy();

        public abstract IFigure CreateColne();
        protected abstract List<Point> getMotions();
        protected abstract List<Point> getAttacks();

        public bool TryGoMotion(IFigure[,] figures, IPlayer currentPlayer, int x, int y)
        {
            bool Executed = false;
            
            Point motion = getMotions()?.FirstOrDefault(m => m.PositionX == x && m.PositionY == y);
            Point attack = getAttacks()?.FirstOrDefault(m => m.PositionX == x && m.PositionY == y);

            if(motion != null)
                if (figures[motion.PositionY, motion.PositionX] is EmptyPoint && currentPlayer.GetFigure(motion) == null)
                {
                    figures[motion.PositionY, motion.PositionX] = figures[points.PositionY, points.PositionX];
                    figures[points.PositionY, points.PositionX] = new EmptyPoint();
                    points.PositionY = motion.PositionY;
                    points.PositionX = motion.PositionX;

                    isFirstMotion = false;
                    Executed = true;
                }

            if (attack != null)
                if (figures[attack.PositionY, attack.PositionX] is IFigure && figures[attack.PositionY, attack.PositionX] is not EmptyPoint
                    && currentPlayer.GetFigure(attack) == null)
                {
                    figures[attack.PositionY, attack.PositionX] = figures[points.PositionY, points.PositionX];
                    figures[points.PositionY, points.PositionX].Destroy();
                    figures[points.PositionY, points.PositionX] = new EmptyPoint();
                    points.PositionY = attack.PositionY;
                    points.PositionX = attack.PositionX;

                    isFirstMotion = false;
                    Executed = true;
                }

            return Executed;
        }
    }
}

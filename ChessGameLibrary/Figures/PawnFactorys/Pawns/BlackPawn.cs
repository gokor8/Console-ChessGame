using ChessGameLibrary.FieldFactory;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameLibrary.Figures.Pawns
{
    class BlackPawn : Pawn, IFigure, ICloneableFigure
    {
        List<Point> attacks
        {
            get
            {
                _attacks = new List<Point>();

                _attacks.Add(new Point(points.PositionX + 1, points.PositionY - 1));
                _attacks.Add(new Point(points.PositionX - 1, points.PositionY - 1));

                return _attacks;
            }
        }

        List<Point> motions
        {
            get
            {
                _motions = new List<Point>();

                if (_isFirstMotion)
                    _motions.Add(new Point(points.PositionX, points.PositionY - 2));

                _motions.Add(new Point(points.PositionX, points.PositionY - 1));

                return _motions;
            }
        }

        public BlackPawn() : base()
        {

        }

        public override IFigure CreateColne()
        {
            return new BlackPawn();
        }

        public override bool TryGoMotion(IFigure[,] figures, int x, int y)
        {
            bool isExcecuted = false;

            var motion = motions.First(m => m.PositionX == x && m.PositionY == y);

            if(motion != null && (figures[motion.PositionY,motion.PositionX] is EmptyPoint))
            {
                figures[motion.PositionY, motion.PositionX] = figures[points.PositionY, points.PositionX];
                figures[points.PositionY, points.PositionX] = new EmptyPoint();
                isExcecuted = true;
            }

            var attack = attacks.First(m => m.PositionX == x && m.PositionY == y);

            if (attack != null && (figures[attack.PositionY, attack.PositionX] is IFigure && figures[attack.PositionY, attack.PositionX] is not EmptyPoint))
            {
                figures[motion.PositionY, motion.PositionX] = figures[points.PositionY, points.PositionX];
                figures[points.PositionY, points.PositionX] = new EmptyPoint();
                isExcecuted = true;
            }

            return isExcecuted;
        }
    }
}

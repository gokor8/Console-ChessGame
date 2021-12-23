using ChessGameLibrary.FieldFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures.Pawns
{
    class BlackPawn : Pawn, IFigure, ICloneableFigure
    {
        List<Point> attack
        {
            get
            {
                _attack = new List<Point>();

                _attack.Add(new Point(points.PositionX + 1, points.PositionY - 1));
                _attack.Add(new Point(points.PositionX - 1, points.PositionY - 1));

                return _attack;
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

        public IFigure CreateColne()
        {
            return new BlackPawn();
        }

        public override bool TryGoMotion(IFigure[,] figures, int x, int y)
        {
            var motion = motions.First(m => m.PositionX == x && m.PositionY == y);

            if(figures[motion.PositionY,motion.PositionX] is EmptyPoint)
            {

            }
        }
    }
}

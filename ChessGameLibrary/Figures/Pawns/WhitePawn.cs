using ChessGameLibrary.FieldFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures.Pawns
{
    class WhitePawn : Pawn, IFigure, ICloneableFigure
    {
        List<Point> attack
        {
            get
            {
                _attack = new List<Point>();

                _attack.Add(new Point(points.PositionX + 1, points.PositionY + 1));
                _attack.Add(new Point(points.PositionX - 1, points.PositionY + 1));

                return _attack;
            }
        }

        List<Point> motions
        {
            get
            {
                _motions = new List<Point>();

                if (_isFirstMotion)
                    _motions.Add(new Point(points.PositionX, points.PositionY + 2));

                _motions.Add(new Point(points.PositionX, points.PositionY + 1));

                return _motions;
            }
        }

        public BlackPawn() : base()
        {

        }

        public IFigure CreateColne()
        {
            return new WhitePawn();
        }

        public override bool TryGoMotion(IFigure[,] figures, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}

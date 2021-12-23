using ChessGameLibrary.FieldFactory;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameLibrary.Figures.Pawns
{
    class BlackPawn : Pawn, IFigure, ICloneableFigure
    {
        public BlackPawn() : base()
        {

        }

        protected override List<Point> getMotions()
        {
            List<Point> motions = new List<Point>();

            if (_isFirstMotion)
                motions.Add(new Point(points.PositionX, points.PositionY - 2));

            motions.Add(new Point(points.PositionX, points.PositionY - 1));
            motions.Add(new Point(points.PositionX + 1, points.PositionY - 1));
            motions.Add(new Point(points.PositionX - 1, points.PositionY - 1));

            return motions;
        }

        public override IFigure CreateColne()
        {
            return new BlackPawn();
        }
    }
}

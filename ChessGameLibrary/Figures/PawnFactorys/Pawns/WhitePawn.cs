using ChessGameLibrary.FieldFactory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameLibrary.Figures.Pawns
{
    class WhitePawn : Pawn, IFigure, ICloneableFigure
    {
        public WhitePawn(List<IFigure> playerFigures) : base(playerFigures)
        {

        }

        protected override List<Point> getAttacks()
        {
            List<Point> attacks = new List<Point>();

            attacks.Add(new Point(points.PositionX + 1, points.PositionY + 1));
            attacks.Add(new Point(points.PositionX - 1, points.PositionY + 1));

            return attacks;
        }

        public override void Destroy()
        {
            playerFigures.Remove(this);
        }

        protected override List<Point> getMotions()
        {
            List<Point> motions = new List<Point>();

            if (isFirstMotion)
                motions.Add(new Point(points.PositionX, points.PositionY + 2));

            motions.Add(new Point(points.PositionX, points.PositionY + 1));

            return motions;
        }

        public override IFigure CreateColne()
        {
            return new WhitePawn(playerFigures);
        }

    }
}

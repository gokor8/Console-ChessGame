using ChessGameLibrary.Figures.Pawns;
using System.Collections.Generic;

namespace ChessGameLibrary.Figures.PawnFactorys
{
    class BlackPawnFactory : IPawnFactory
    {
        public FiguresType figuresType { get; set; } = FiguresType.Black;

        public Pawn CreatePawn(List<IFigure> figures)
        {
            return new BlackPawn(figures);
        }
    }
}

using System.Collections.Generic;

namespace ChessGameLibrary.Figures.PawnFactorys
{
    interface IPawnFactory
    {
        FiguresType figuresType { get; set; }
        Pawn CreatePawn(List<IFigure> figures);
    }
}

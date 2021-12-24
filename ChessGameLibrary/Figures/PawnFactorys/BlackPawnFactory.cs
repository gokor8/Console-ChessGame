using ChessGameLibrary.Figures.Pawns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

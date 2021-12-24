using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures.PawnFactorys
{
    interface IPawnFactory
    {
        FiguresType figuresType { get; set; }
        Pawn CreatePawn(List<IFigure> figures);
    }
}

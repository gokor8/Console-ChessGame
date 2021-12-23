using ChessGameLibrary.Figures.Pawns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures.PawnFactorys
{
    class WhitePawnFactory : IPawnFactory
    {
        public FiguresType figuresType { get; set; } = FiguresType.White;

        public Pawn CreatePawn()
        {
            return new WhitePawn();
        }
    }
}

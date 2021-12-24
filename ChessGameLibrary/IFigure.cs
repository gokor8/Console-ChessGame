using ChessGameLibrary.FieldFactory;
using ChessGameLibrary.Figures;
using System.Collections.Generic;

namespace ChessGameLibrary
{
    public interface IFigure : ICloneableFigure
    {
        int[] triggers { get; }
        Point points { get; set; }
        char figureChar { get; }
        List<IFigure> playerFigures { get; }

        void Destroy();

        bool TryGoMotion(IFigure[,] figures, IPlayer currentPlayer, int x, int y);
    }
}

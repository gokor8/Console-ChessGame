using ChessGameLibrary.FieldFactory;
using ChessGameLibrary.Figures;

namespace ChessGameLibrary
{
    public interface IFigure : ICloneableFigure
    {
        int[] triggers { get; }
        Point points { get; set; }
        char figureChar { get; }

        bool TryGoMotion(IFigure[,] figures, IPlayer currentPlayer, int x, int y);
    }
}

using ChessGameLibrary.FieldFactory;

namespace ChessGameLibrary
{
    public interface IFigure : ICloneableFigure
    {
        int[] triggers { get; }
        int PostitionX { get; set; }
        int PostitionY { get; set; }
        char figureChar { get; }

        void TryGoMotion();
    }
}

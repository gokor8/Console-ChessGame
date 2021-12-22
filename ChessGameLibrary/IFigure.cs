using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public interface IFigure
    {
        int[] triggers { get; }
        int PostitionX { get; set; }
        int PostitionY { get; set; }
        char figureChar { get; }

        void TryGoMotion();
    }
}

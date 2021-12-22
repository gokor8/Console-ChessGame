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
        char figureChar { get; }

        void TryGoMotion();
    }
}

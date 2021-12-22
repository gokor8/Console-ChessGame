using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    interface IPlayer
    {
        string Name { get; set; }
        List<IFigure> figures { get; set; }
    }
}

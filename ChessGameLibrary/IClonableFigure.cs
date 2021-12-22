using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.FieldFactory
{
    public interface ICloneableFigure
    {
        IFigure CreateColne(); 
    }
}

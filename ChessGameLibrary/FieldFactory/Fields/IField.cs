using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.FieldFactory.Fields
{
    public interface IField
    {
        public IFigure[,] GetField();
    }
}

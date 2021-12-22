using ChessGameLibrary.FieldFactory.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.FieldFactory
{
    public class DefaultFactoryField
    {
        IFigure[,] chessFigures = new IFigure[8,8];

        public IField CreateField(List<IFigure> player1Figures, List<IFigure> player2Figures)
        {
            return new DefaultField(chessFigures, player1Figures, player2Figures);
        }
    }
}

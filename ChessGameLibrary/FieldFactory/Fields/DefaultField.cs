using ChessGameLibrary.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.FieldFactory.Fields
{
    public class DefaultField : IField
    {
        public List<IFigure> whiteFigures { get; private set; }
        public List<IFigure> blackFigures { get; private set; }
        IFigure[,] field;

        public DefaultField(IFigure[,] field, List<IFigure> player1Figures, List<IFigure> player2Figures)
        {
            whiteFigures = player1Figures;
            blackFigures = player2Figures;
            this.field = field;
            InitializeFigures();
        }

        void InitializeFigures()
        {
            List<IFigure> generalFigures = new List<IFigure>()
            {
                new Rook(2,field.GetLength(1)-3),
                new Elephant(0,field.GetLength(1)-1),
                new Horse(1,field.GetLength(1)-2)
            };

            whiteFigures.AddRange(new List<IFigure>()
            {
                new King(4),
                new Queen(3)
            });
            whiteFigures.AddRange(generalFigures);

            blackFigures.AddRange(new List<IFigure>()
            {
                new King(3),
                new Queen(4)
            });
            blackFigures.AddRange(generalFigures);
        }

        public IFigure[,] GetField()
        {
            setFigures(whiteFigures);
            setFigures(blackFigures);

            return field;
        }

        private void setFigures(List<IFigure> figures)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                    if (i == 0 || i == field.GetLength(0) - 1)
                    {
                        field[i, j] = figures.First(f => f.triggers.Any(t => t == j));
                    }
                    else if (i == 1 || i == field.GetLength(0) - 2)
                        field[i, j] = new Pawn();
            }
        }
    }
}

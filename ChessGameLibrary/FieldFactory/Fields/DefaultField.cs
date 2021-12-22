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

        List<IFigure> baseFigures;

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
            baseFigures = new List<IFigure>()
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

            blackFigures.AddRange(new List<IFigure>()
            {
                new King(3),
                new Queen(4)
            });
        }

        public IFigure[,] GetField()
        {
            setFigures(whiteFigures, FiguresType.White);
            setFigures(blackFigures, FiguresType.Black);
            FillNullPixels(field);

            return field;
        }

        private void setFigures(List<IFigure> figures, FiguresType figuresType)
        {
            for (int y = (int)figuresType-2; y < (int)figuresType; y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    if (y == 0 || y == field.GetLength(0) - 1)
                    {
                        IFigure figure;
                        int index;

                        if (x == 3 || x == 4)
                        {
                            figure = figures.First(f => f.triggers.Any(t => t == x)).CreateColne();

                            index = figures.FindIndex(s => s == figure);
                        }
                        else
                        {
                            index = -1;
                            figure = baseFigures.First(f => f.triggers.Any(t => t == x)).CreateColne();
                        }

                        figure.PostitionX = x;
                        figure.PostitionY = y;

                        if (index != -1)
                            figures[index] = figure;
                        else
                            figures.Add(figure);

                        field[y, x] = figure;
                    }
                    else if (y == 1 || y == field.GetLength(0) - 2)
                    {
                        Pawn pawn = new Pawn();
                        pawn.PostitionX = x;
                        pawn.PostitionY = y;

                        figures.Add(pawn);
                        field[y, x] = pawn;
                    }
                }
            }
        }

        public void FillNullPixels(IFigure[,] figures)
        {
            for (int y = 0; y < figures.GetLength(0); y++)
                for (int x = 0; x < figures.GetLength(1); x++)
                    if (field[y, x] is null)
                        field[y, x] = new EmptyPoint();
        }
    }
}

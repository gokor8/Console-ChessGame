using ChessGameLibrary.Figures;
using ChessGameLibrary.Figures.PawnFactorys;
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
            whiteFigures.Clear();
            whiteFigures.AddRange(new List<IFigure>()
            {
                new King(whiteFigures,4),
                new Queen(whiteFigures,3)
            });

            blackFigures.Clear();
            blackFigures.AddRange(new List<IFigure>()
            {
                new King(blackFigures,3),
                new Queen(blackFigures,4)
            });
        }

        public IFigure[,] GetField()
        {
            setFigures(whiteFigures, new WhitePawnFactory());
            setFigures(blackFigures, new BlackPawnFactory());
            FillNullPixels(field);

            return field;
        }

        private void setFigures(List<IFigure> figures, IPawnFactory pawnFactory)
        {
            List<IFigure> baseFigures = new List<IFigure>()
            {
                new Rook(figures, 2,field.GetLength(1)-3),
                new Elephant(figures, 0,field.GetLength(1)-1),
                new Horse(figures, 1,field.GetLength(1)-2)
            };

            for (int y = (int)pawnFactory.figuresType- 2; y < (int)pawnFactory.figuresType; y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    if (y == 0 || y == field.GetLength(0) - 1)
                    {
                        IFigure figure;
                        int index;

                        if (x == 3 || x == 4)
                        {
                            figure = figures.First(f => f.triggers.Any(t => t == x));

                            index = figures.FindIndex(s => s == figure);
                            figure = figure.CreateColne();
                        }
                        else
                        {
                            index = -1;
                            figure = baseFigures.First(f => f.triggers.Any(t => t == x)).CreateColne();
                        }

                        figure.points.PositionX = x;
                        figure.points.PositionY = y;

                        if (index != -1)
                            figures[index] = figure;
                        else
                            figures.Add(figure);

                        field[y, x] = figure;
                    }
                    else if (y == 1 || y == field.GetLength(0) - 2)
                    {
                        Pawn pawn = pawnFactory.CreatePawn(figures);
                        pawn.points.PositionX = x;
                        pawn.points.PositionY = y;

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

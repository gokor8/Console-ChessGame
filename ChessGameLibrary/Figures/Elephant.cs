using ChessGameLibrary.FieldFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    public class Elephant : IFigure
    {
        public Elephant(params int[] triggers)
        {
            this.triggers = triggers;

            points = new Point(0,0);
        }
        public int[] triggers { get; private set; }
        public char figureChar => '♖';
        public Point points { get; set; }

        private List<Point> getActions()
        {
            List<Point> actions = new List<Point>();
            for(int y = points.PositionY; y < 8; y++)
            {
                for(int x = points.PositionX; x < 8; x++)
                    actions.Add(new Point(x,y));
                for (int x = points.PositionX; x > 0; x--)
                    actions.Add(new Point(x, y));
            }
            for (int y = points.PositionY; y > 0; y--)
            {
                for (int x = points.PositionX; x < 8; x++)
                    actions.Add(new Point(x, y));
                for (int x = points.PositionX; x > 0; x--)
                    actions.Add(new Point(x, y));
            }

            return actions;
        }

        public IFigure CreateColne()
        {
            return new Elephant(triggers);
        }

        public bool TryGoMotion(IFigure[,] figures, IPlayer currentPlayer, int x, int y)
        {
            bool Executed = false;
            Point actualAction = getActions()?.FirstOrDefault(m => m.PositionX == x && m.PositionY == y);

            if (actualAction == null)
                return Executed;

            if(currentPlayer.GetFigure(actualAction) == null)
            {
                figures[actualAction.PositionY, actualAction.PositionX] = figures[points.PositionY, points.PositionX];
                figures[points.PositionY, points.PositionX] = new EmptyPoint();
                points.PositionY = actualAction.PositionY;
                points.PositionX = actualAction.PositionX;

                Executed = true;
            }

            return Executed;
        }
    }
}

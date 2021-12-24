using ChessGameLibrary.FieldFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    public class King : IFigure, ICloneableFigure
    {
        public int[] triggers { get; private set; }
        public Point points { get; set; }
        public char figureChar => '♔';
        public List<IFigure> playerFigures { get; private set; }

        public King(List<IFigure> playerFigures, params int[] triggers)
        {
            this.triggers = triggers;

            this.playerFigures = playerFigures;
            points = new Point(0, 0);
        }
        public IFigure CreateColne()
        {
            return new King(playerFigures, triggers);
        }
        public void Destroy()
        {
            playerFigures.Remove(this);
        }

        private List<Point> getActions()
        {
            List<Point> motions = new List<Point>();

            motions.Add(new Point(points.PositionX - 1, points.PositionY - 1));
            motions.Add(new Point(points.PositionX, points.PositionY - 1));
            motions.Add(new Point(points.PositionX + 1, points.PositionY - 1));
            motions.Add(new Point(points.PositionX + 1, points.PositionY));
            motions.Add(new Point(points.PositionX + 1, points.PositionY + 1));
            motions.Add(new Point(points.PositionX, points.PositionY + 1));
            motions.Add(new Point(points.PositionX - 1, points.PositionY + 1));
            motions.Add(new Point(points.PositionX - 1, points.PositionY));

            return motions;
        }

        public bool TryGoMotion(IFigure[,] figures, IPlayer currentPlayer, int x, int y)
        {
            bool Executed = false;
            Point actualAction = getActions()?.FirstOrDefault(m => m.PositionX == x && m.PositionY == y);

            if (actualAction == null)
                return Executed;

            if (currentPlayer.GetFigure(actualAction) == null)
            {
                figures[actualAction.PositionY, actualAction.PositionX].Destroy();
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

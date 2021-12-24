using ChessGameLibrary.FieldFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    public class Rook : IFigure
    {
       
        public Point points { get; set; }
        public int[] triggers { get; private set; }
        public char figureChar => '♗';
        public List<IFigure> playerFigures { get; private set; }

        public Rook(List<IFigure> playerFigures, params int[] triggers)
        {
            this.triggers = triggers;

            this.playerFigures = playerFigures;
            points = new Point(0, 0);
        }
        public IFigure CreateColne()
        {
            return new Rook(playerFigures, triggers);
        }
        public void Destroy()
        {
            playerFigures.Remove(this);
        }

        private List<Point> getActions(IFigure[,] figures)
        {
            List<Point> actions = new List<Point>();
            PositionSearcher searcher = new PositionSearcher(figures, actions);
            searcher.SetUpRightXY(points.PositionX, points.PositionY);
            searcher.SetUpLeftXY(points.PositionX, points.PositionY);

            return actions;
        }

        public bool TryGoMotion(IFigure[,] figures, IPlayer currentPlayer, int x, int y)
        {
            bool Executed = false;
            Point actualAction = getActions(figures)?.FirstOrDefault(m => m.PositionX == x && m.PositionY == y);

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

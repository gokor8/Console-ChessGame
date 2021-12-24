using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Figures
{
    internal class PositionSearcher
    {
        IFigure[,] figures;
        List<Point> actions;

        public PositionSearcher(IFigure[,] figures, List<Point> actions)
        {
            this.figures = figures;
            this.actions = actions;
        }

        public void SetUpY(int figureX, int figureY)
        {
            for (int y = figureY; y < 8; y++)
            {
                actions.Add(new Point(figureX, y));
                if (figures[y, figureX] is not EmptyPoint)
                    break;
            }
        }

        public void SetDownY(int figureX, int figureY)
        {
            for (int y = figureY; y >= 0; y--)
            {
                actions.Add(new Point(figureX, y));
                if (figures[y, figureX] is not EmptyPoint)
                    break;
            }
        }

        public void SetLeftX(int figureX, int figureY)
        {
            for (int x = figureX; x >= 0; x--)
            {
                actions.Add(new Point(x, figureY));
                if (figures[figureY, x] is not EmptyPoint)
                    break;
            }
        }

        public void SetRightX(int figureX, int figureY)
        {
            for (int x = figureX; x < 8; x++)
            {
                actions.Add(new Point(x, figureY));
                if (figures[figureY, x] is not EmptyPoint)
                    break;
            }
        }

        public void SetUpRightXY(int figureX, int figureY)
        {
            for (int y = figureY + 1; y < 8; y++)
            {
                int clearY = y - figureY;
                if (figureX + clearY < 8)
                {
                    actions.Add(new Point(figureX + clearY, y));
                    if (figures[y, figureX + clearY] is not EmptyPoint)
                        break;
                }
            }
        }
        public void SetUpLeftXY(int figureX, int figureY)
        {
            for (int y = figureY + 1; y < 8; y++)
            {
                int clearY = y - figureY;
                if(figureX - clearY >= 0)
                { 
                    actions.Add(new Point(figureX - clearY, y));
                    if (figures[y, figureX - clearY] is not EmptyPoint)
                        break;
                }
            }
        }

        public void SetDownLeftXY(int figureX, int figureY)
        {
            for (int y = figureY - 1; y >= 0; y--)
            {
                int clearY = figureY - y;
                if (figureX - clearY >= 0)
                {
                    actions.Add(new Point(figureX - clearY, y));
                    if (figures[y, figureX - clearY] is not EmptyPoint)
                        break;
                }
            }
        }

        public void SetDownRightXY(int figureX, int figureY)
        {
            for (int y = figureY - 1; y >= 0; y--)
            {
                int clearY = figureY - y;
                if (figureX + clearY < 8)
                {
                    actions.Add(new Point(figureX + clearY, y));
                    if (figures[y, figureX + clearY] is not EmptyPoint)
                        break;
                }
            }
        }
    }
}
/*for(int y = points.PositionY+1; y < 8; y++)
            {
                actions.Add(new Point(points.PositionX, y));
                if (figures[y, points.PositionX] is not EmptyPoint)
                    break;
            }
            for (int y = points.PositionY-1; y >= 0; y--)
            {
                actions.Add(new Point(points.PositionX, y));
                if (figures[y, points.PositionX] is not EmptyPoint)
                    break;
            }
            for (int x = points.PositionX-1; x >= 0; x--)
            {
                actions.Add(new Point(x, points.PositionY));
                if (figures[points.PositionY, x] is not EmptyPoint)
                    break;
            }
            for (int x = points.PositionX+1; x < 8; x++)
            {
                actions.Add(new Point(x, points.PositionY));
                if (figures[points.PositionY, x] is not EmptyPoint)
                    break;
            }

 
 
 for (int y = points.PositionY + 1; y < 8; y++)
            {
                int clearY = y - points.PositionY;
                for (int x = points.PositionX + clearY; x < 8; x++)
                {
                    actions.Add(new Point(x, y));
                    if (figures[y, x] is not EmptyPoint)
                        goto breakLoop;
                }
            }
 
 
 */
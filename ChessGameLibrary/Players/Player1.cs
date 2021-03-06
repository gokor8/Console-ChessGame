using ChessGameLibrary.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Players
{
    public class Player1 : IPlayer
    {
        public string Name { get; set; } = "Player 1";
        public List<IFigure> figures { get; set; } = new List<IFigure>();

        public IFigure GetFigure(Point point)
        {
            return figures?.FirstOrDefault(f => f.points.PositionY == point.PositionY && f.points.PositionX == point.PositionX);
        }
    }
}

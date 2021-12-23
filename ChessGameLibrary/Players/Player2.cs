using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Players
{
    public class Player2 : IPlayer
    {
        public string Name { get; set; } = "Player 2";
        public List<IFigure> figures { get; set; } = new List<IFigure>();

        public IFigure GetFigure(int y, int x)
        {
            return figures?.First(f => f.points.PositionY == y && f.points.PositionX == x);
        }
    }
}

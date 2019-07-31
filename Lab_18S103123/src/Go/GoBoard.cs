using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Go
{
    class GoBoard : Board
    {
        public GoBoard(int _boardsize)
        {
            size = 700;
            pieceList = new List<Piece>();
            h_pos = -1;
            BoardSize = _boardsize;
            CellSize = size / (BoardSize + 2);
            history = new List<List<Piece>>();
            bmp = new Bitmap(size, size);
            Draw();
        }
    }
}

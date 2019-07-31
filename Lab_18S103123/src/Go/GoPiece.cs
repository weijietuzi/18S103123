using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Go
{
    class GoPiece : Piece
    {
        public GoPiece() { }
        public GoPiece(int _id, string _name, int _CellSize, int _x, int _y)
        {
            id = _id;
            name = _name;
            pos = new Position(_x, _y);
            CellSize = _CellSize;
        }
        public override void Draw(Graphics gr)
        {
            int CircleX = pos.x * CellSize-CellSize/4;
            int CircleY = pos.y * CellSize-CellSize/4;
            if (id == 0)
            {
                gr.FillEllipse(Brushes.White, CircleX, CircleY, CellSize/2, CellSize/2);
                gr.DrawEllipse(new Pen(Color.Black,1), CircleX, CircleY, CellSize/2, CellSize/2);
            }
            else
                gr.FillEllipse(Brushes.Black, CircleX, CircleY, CellSize/2, CellSize/2);
        }
    }
}

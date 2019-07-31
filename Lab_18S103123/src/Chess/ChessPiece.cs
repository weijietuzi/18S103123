using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Game.Chess
{
    class ChessPiece : Piece
    {
        public ChessPiece() { }
        public ChessPiece(int _id,string _name, int _CellSize, int _x, int _y)
        {
            id = _id;
            name = _name;
            pos = new Position(_x,_y);
            CellSize = _CellSize;
        }
        public override void Draw(Graphics gr)
        {
            int CircleX = pos.x * CellSize;
            int CircleY = pos.y * CellSize;
            if(id==0)
                gr.FillEllipse(Brushes.Black, CircleX, CircleY, CellSize, CellSize);
            else
                gr.FillEllipse(Brushes.Gray, CircleX, CircleY, CellSize, CellSize);
            Font drawfont = new Font("宋体", 18);
            SolidBrush drawbrush;
            if (id == 0)
                drawbrush = new SolidBrush(Color.White);
            else
                drawbrush = new SolidBrush(Color.Black);
            PointF drawpointf = new PointF(CircleX+CellSize/4, CircleY+CellSize/4);
            gr.DrawString(name, drawfont, drawbrush, drawpointf);
        }
    }
}

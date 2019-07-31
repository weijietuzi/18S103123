using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Game
{
    class Piece
    {
        public Piece() { }
        public Piece(int _id,string _name,int _CellSize,int _x,int _y)
        {
            id = _id;
            name = _name;
            pos = new Position(_x,_y);
            CellSize = _CellSize;
        }
        public void SetPosition(int x,int y)
        {
            pos.x = x;
            pos.y = y;
        }
        public int GetId() { return id; }
        public string GetName() { return name; }
        public Position GetPosition() { return pos; }
        public int GetCellSize() { return CellSize; }
        public virtual void Draw(Graphics gr) { }
        protected int id;
        protected string name;
        protected Position pos;
        protected int CellSize;
    }
}

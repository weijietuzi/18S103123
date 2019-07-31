using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Game.Chess;

namespace Game
{
    class Board
    {
        public Board() { }
        public Board(int _boardsize)
        {
            size = 700;
            pieceList = new List<Piece>();
            
            BoardSize = _boardsize;
            CellSize = size / (BoardSize + 2);
            h_pos = -1;
            history = new List<List<Piece>>();
            Draw();
        }
        public int GetBoardSize()
        {
            return BoardSize;
        }
        public int GetCellSize()
        {
            return CellSize;
        }
        public void SetCellSize(int _cellsize)
        {
            CellSize = _cellsize;
        }
        public void Draw()
        {
            bmp = new Bitmap(size, size);
            Graphics gr = Graphics.FromImage(bmp);
            //竖线
            for (int i = 1; i <= BoardSize; i++)
            {
                Point start = new Point(i * CellSize, CellSize);
                Point end = new Point(i * CellSize, BoardSize * CellSize);
                gr.DrawLine(Pens.Gray, start, end);
            }
            //横线
            for(int i=1;i<=BoardSize;++i)
            {
                Point start = new Point(CellSize, i * CellSize);
                Point end = new Point(BoardSize * CellSize, i * CellSize);
                gr.DrawLine(Pens.Gray, start, end);
            }
            //横坐标
            for (int i = 1; i <= BoardSize; i++)
            {
                string drawstr = i.ToString();
                Font drawfont = new Font("宋体", 12);
                SolidBrush drawbrush = new SolidBrush(Color.Gray);
                PointF drawpointf = new PointF((float)(i * CellSize), 0);
                gr.DrawString(drawstr, drawfont, drawbrush, drawpointf);
            }
            //纵坐标
            for (int i = 1; i <= BoardSize; i++)
            {
                string drawstr = i.ToString();
                Font drawfont = new Font("宋体", 12);
                SolidBrush drawbrush = new SolidBrush(Color.Gray);
                PointF drawpointf = new PointF(0, (float)(i * CellSize));
                gr.DrawString(drawstr, drawfont, drawbrush, drawpointf);
            }
            System.Diagnostics.Debug.WriteLine("{0}",pieceList.Count);
            for (int i = 0; i < pieceList.Count; ++i)
                pieceList[i].Draw(gr);
        }
        public Bitmap GetBmp()
        {
            return bmp;
        }
        public List<Piece> pieceList;
        public List<List<Piece>> history;
        public int h_pos;
        protected int BoardSize;
        protected int size;
        protected int CellSize;
        protected Bitmap bmp;
    }
}

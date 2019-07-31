using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Chess
{
    class ChessBoard : Board
    {
        public ChessBoard(int _boardsize)
        {
            size = 700;
            pieceList = new List<Piece>();
            
            BoardSize = _boardsize;
            h_pos = -1;
            CellSize = size / (BoardSize + 2);
            history = new List<List<Piece>>();
            bmp = new Bitmap(size, size);
            for (int i = 1; i <= 8; ++i)
                pieceList.Add(new ChessPiece(1, "兵", CellSize, i, 2));
            pieceList.Add(new ChessPiece(1, "车", CellSize, 1, 1));
            pieceList.Add(new ChessPiece(1, "车", CellSize, 8, 1));
            pieceList.Add(new ChessPiece(1, "马", CellSize, 2, 1));
            pieceList.Add(new ChessPiece(1, "马", CellSize, 7, 1));
            pieceList.Add(new ChessPiece(1, "象", CellSize, 3, 1));
            pieceList.Add(new ChessPiece(1, "象", CellSize, 6, 1));
            pieceList.Add(new ChessPiece(1, "后", CellSize, 4, 1));
            pieceList.Add(new ChessPiece(1, "王", CellSize, 5, 1));
            for (int i = 0; i < 16; ++i)
            {
                Position pos = pieceList[i].GetPosition();
                pieceList.Add(new ChessPiece(0, pieceList[i].GetName(), CellSize, pos.x, 9-pos.y));
            }
            Draw();
        }
    }
}

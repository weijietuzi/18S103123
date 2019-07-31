using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Go
{
    class GoAction : Action
    {
        public GoAction(int _id)
        {
            id = _id;
            num = 0;
        }
        public override bool Take_Put(Board board, int X, int Y)
        {
            int p = -1;
            for(int i=0;i<board.pieceList.Count;++i)
            {
                var pos = board.pieceList[i].GetPosition();
                if(pos.x==X&&pos.y==Y)
                {
                    p = i;
                    break;
                }
            }
            if (p < 0)
                return Put(board, X, Y);
            else
                return Take(board, X, Y);
        }
        public bool Put(Board board, int X, int Y)
        {
            int p = -1;
            var list = board.pieceList;
            for(int i=0;i<list.Count;++i)
            {
                var pos = list[i].GetPosition();
                if(pos.x==X&&pos.y==Y)
                {
                    p = i;
                    break;
                }
            }
            if (p >= 0)
                return false;
            board.h_pos++;
            board.history.Add(new List<Piece>());
            for (int i = 0; i < board.pieceList.Count; ++i)
            {
                var piece = board.pieceList[i];
                var pos = piece.GetPosition();
                board.history[board.history.Count - 1].Add(new GoPiece(piece.GetId(), piece.GetName(), piece.GetCellSize(), pos.x, pos.y));
            }
            list.Add(new GoPiece(id, "", board.GetCellSize(), X, Y));
            ++num;
            return true;
        }
        public bool Take(Board board, int X, int Y)
        {
            int p = -1;
            var list = board.pieceList;
            for(int i=0;i<list.Count;++i)
            {
                var pos = list[i].GetPosition();
                if(pos.x==X&&pos.y==Y)
                {
                    p = i;
                    break;
                }
            }
            if (p < 0 || list[p].GetId() == id)
                return false;
            board.history.Add(new List<Piece>());
            for (int i = 0; i < board.pieceList.Count; ++i)
            {
                var piece = board.pieceList[i];
                var pos = piece.GetPosition();
                board.history[board.history.Count - 1].Add(new GoPiece(piece.GetId(), piece.GetName(), piece.GetCellSize(), pos.x, pos.y));
            }
            list.RemoveAt(p);
            ++num;
            return true;
        }
    }
}

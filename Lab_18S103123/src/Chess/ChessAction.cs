using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Chess
{
    class ChessAction : Action
    {
        public ChessAction(int _id)
        {
            id = _id;
            num = 0;
        }
        public override bool Move_Eat(Board board, int srcX, int srcY, int desX, int desY)
        {
            int src_p=-1, des_p=-1;
            for(int i=0;i<board.pieceList.Count;++i)
            {
                Position pos = board.pieceList[i].GetPosition();
                if (pos.x == srcX && pos.y == srcY)
                    src_p = i;
                if (pos.x == desX && pos.y == desY)
                    des_p = i;
            }
            if (src_p < 0)
                return false;
            if (des_p>=0&&board.pieceList[des_p].GetId()==id)
                return false;
            board.h_pos++;
            board.history.Add(new List<Piece>());
            for (int i = 0; i < board.pieceList.Count; ++i)
            {
                var piece = board.pieceList[i];
                var pos = piece.GetPosition();
                board.history[board.history.Count - 1].Add(new ChessPiece(piece.GetId(),piece.GetName(),piece.GetCellSize(),pos.x,pos.y));
            }
            board.pieceList[src_p].SetPosition(desX, desY);
            if(des_p>=0)
                board.pieceList.RemoveAt(des_p);//如果目标位置存在棋子则说明为吃子动作，删去该棋子
            ++num;
            return true;
        }
    }
}

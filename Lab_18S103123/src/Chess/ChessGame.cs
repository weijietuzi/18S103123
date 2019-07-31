using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Chess
{
    class ChessGame : Game
    {
        public ChessGame(string name1,string name2)
        {
            board = new ChessBoard(9);
            click = false;
            stop = false;
            flag = 0;
            player1 = new Player(name1, 0, new ChessAction(0));
            player2 = new Player(name2, 1, new ChessAction(1));
        }
        public override bool Run(int X,int Y)
        {
            //根据鼠标点击位置，计算出棋子的横纵坐标
            int intX = X/board.GetCellSize();
            int intY = Y/board.GetCellSize();
            //如果点击位置不在棋盘范围则返回
            if (intX > board.GetBoardSize() || intY > board.GetBoardSize()) return false;
            if (intX == 0 || intY == 0) return false;
            if (stop)
                return false;
            if(!click)//第一次鼠标点击
            {
                srcX = intX;
                srcY = intY;
                int p = -1;
                for(int i=0;i<board.pieceList.Count;++i)
                {
                    Position pos = board.pieceList[i].GetPosition();
                    if(pos.x==srcX&&pos.y==srcY)
                    {
                        p = i;
                        break;
                    }
                }
                if (p < 0||board.pieceList[p].GetId()!=flag)//判断是否为己方棋子
                    return false;
                click=true;
                return true;
            }
            click = false;
            bool ret;
            if (flag==0)
            {
                ret=player1.action.Move_Eat(board, srcX, srcY, intX, intY);
            }
            else
            {
                ret=player2.action.Move_Eat(board, srcX, srcY, intX, intY);
            }
            if (ret) flag ^= 1;
            return ret;
        }
        private bool click;//标记鼠标点击的是第一次还是第二次
        private int srcX, srcY;//记录每轮第一次鼠标点击的坐标
    }
}

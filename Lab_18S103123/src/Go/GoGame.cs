using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Go
{
    class GoGame : Game
    {
        public GoGame(string name1, string name2)
        {
            board = new GoBoard(12);
            flag = 0;
            stop = false;
            player1 = new Player(name1, 0, new GoAction(0));
            player2 = new Player(name2, 1, new GoAction(1));
        }
        public override bool Run(int X, int Y)
        {
            //根据鼠标点击位置，计算出棋子的横纵坐标
            double dbX = X * 1.0 / board.GetCellSize() - 0.5;
            int intX = (int)Math.Ceiling(dbX);
            double dbY = Y * 1.0 / board.GetCellSize() - 0.5;
            int intY = (int)Math.Ceiling(dbY);
            //如果点击位置不在棋盘范围则返回
            if (intX > board.GetBoardSize() || intY > board.GetBoardSize()) return false;
            if (intX == 0 || intY == 0) return false;
            if (stop)
                return false;
            bool ret;
            if (flag==0)
            {
                ret=player1.action.Take_Put(board, intX, intY);
            }
            else
            {
                ret=player2.action.Take_Put(board, intX, intY);
            }
            if (ret)
                flag ^= 1;
            return ret;
        }
    }
}

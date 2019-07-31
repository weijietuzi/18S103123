using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Game
    {
        public Game(){ }
        public virtual bool Run(int X,int Y) { return false; }
        public Player player1, player2;
        public Board board;
        public bool stop;
        public int flag;
    }
}

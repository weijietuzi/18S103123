using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Action
    {
        public Action() { }
        public virtual bool Move_Eat(Board board,int srcX,int srcY,int desX,int desY) { return false; }
        public virtual bool Take_Put(Board board,int X,int Y) { return false; }
        protected int id;
        protected int num;
    }
}

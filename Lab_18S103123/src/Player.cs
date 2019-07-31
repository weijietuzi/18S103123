using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player
    {
        public Player() { }
        public Player(string _name,int _id,Action _action)
        {
            id = _id;
            name = _name;
            action = _action;
        }
        public Action action;
        public string name;
        public int id;
    }
}

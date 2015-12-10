using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    abstract class Board : IBoard
    {
        private int _size;
        protected int _turn;
        

        
        public Board(int size)
        {
            _size = size;
            _turn = 1;
            
        }

        abstract public Boolean gameOver();

        public int Size
        {
            get
            {
                return _size;
            }
            
            
        }

        public int Turn
        {
            get
            {
                return _turn;
            }
        }
        

        abstract public int get(int row, int column);


        abstract public Boolean put(int row, int column);
        
    }
}

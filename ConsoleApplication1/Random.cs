using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Random : IRandom
    {
        public void play(IBoard board)
        {
            
            System.Random rnd = new System.Random();
            int row, col;
            do
            {
                row = rnd.Next(0, board.Size);
                col = rnd.Next(0, board.Size);
            }
            while (!((XoBoard)board).put(row, col));
        }
    }
}

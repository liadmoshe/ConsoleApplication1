using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BoardViewer
    {
        IBoard _board;
        public BoardViewer(IBoard board)
        {
            _board = board;
            ((XoBoard)_board).onUpdate += display;
            

        }

        public void display()
        {
            int size = _board.Size;
            int currPos = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    currPos = _board.get(i,j);
                    if ( currPos == 1)
                        Console.Write("[X]");
                    else if (currPos == -1)
                        Console.Write("[O]");
                    else
                        Console.Write("[ ]");
                }
                Console.WriteLine("");
                
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }
    
    }
}

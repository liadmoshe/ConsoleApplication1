using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Scan : IScan
    {
        
        public void play(IBoard board)
        {
            int boardSize = board.Size; 
            int row = -1;
            int col = -1;
            for(int i=0;i<boardSize;i++)
            {
                for(int j=0;j<boardSize;j++)
                {
                    if(board.get(i,j) ==0)
                    {
                        row = i;
                        col = j; 
                    }
                }
            }
            
            board.put(row, col);
            
            
                
            
            
            
            
        }
    }
}

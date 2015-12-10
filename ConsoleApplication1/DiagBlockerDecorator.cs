using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [player(typeof(IDiagBlockerDecorator))]
    class DiagBlockerDecorator:PlayerDecorator
    {
        public DiagBlockerDecorator(ComputerPlayer player):base(player)
        {
            
        }

        

        public override void play(IBoard board)
        {
            int diag1Sum=0, diag2Sum=0,diag1Fill=0,diag2XFill=0,diag2YFill=0,size;
            int opponentSign = board.Turn * -1;
            size = board.Size;
            for (int i=0;i<size;i++)
            //find a place on the board on one of the diags where a block is needed
            {
                diag1Sum += board.get(i, i);
                if(board.get(i,i)==0)
                {
                    diag1Fill = i;
                }

                diag2Sum += board.get(i, size - i-1);
                if(board.get(i,size-i-1)==0)
                {
                    diag2XFill = i;
                    diag2YFill = size - i-1;
                }
                

            }

            if(diag1Sum==((size-1) *opponentSign))
            //block a spot on first diag
            {
                board.put(diag1Fill, diag1Fill);
                announce(diag1Fill, diag1Fill);
                return;
            }
            if(diag2Sum==((size-1) * opponentSign))
            //block a spot on second diag
            {
                board.put(diag2XFill, diag2YFill);
                announce(diag2XFill, diag2YFill);
                return;
            }

            //reached here so diag decorator didnt need to block. Continue to player's original play method
            base.play(board);
           
        }

        public static void announce(int row,int col)
        {
            Console.WriteLine("Diag decorator in use in: " + row + "," + col);
        }
    }
}

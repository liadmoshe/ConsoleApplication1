using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [player(typeof(IRowBlockerDecorator))]
    class RowBlockerDecorator:PlayerDecorator
    {
        public RowBlockerDecorator(ComputerPlayer player):base(player)
        {
            
        }

        public override void play(IBoard board)
        {
            
            int opponentSign=board.Turn*-1;
            int boardSize = board.Size;
            int rowSum = 0;
            int toFillRow=0, toFillCol=0;
            for(int i=0;i<boardSize;i++)
            {
                for(int j=0;j<boardSize;j++)
                {
                    int currentPos = board.get(i, j);
                    rowSum += currentPos;
                    if (currentPos == 0)
                    {
                        toFillRow = i;
                        toFillCol = j;
                    }
                }
                if (rowSum == ((boardSize - 1) * opponentSign))
                {
                    board.put(toFillRow, toFillCol);
                    Console.WriteLine("RowBlocker activated");
                    return;
                }
                rowSum = 0;

            }
            base.play(board);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [player(typeof(IColumnBlockerDecorator))]
    class ColumnBlockerDecorator:PlayerDecorator
    {
        public ColumnBlockerDecorator(ComputerPlayer player):base(player)
        {
            
        }

        public override void play(IBoard board)
        {
            int opponentSign = board.Turn * -1;
            int boardSize = board.Size;
            int colSum = 0;
            int toFillRow = 0, toFillCol = 0;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    int currentPos = board.get(j, i);
                    colSum += currentPos;
                    if (currentPos == 0)
                    {
                        toFillRow = j;
                        toFillCol = i;
                    }
                }
                if (colSum == ((boardSize - 1) * opponentSign))
                {
                    Console.WriteLine("ColumnBlocker activated");
                    board.put(toFillRow, toFillCol);
                    return; //decorator move.Don't continue to other decorators or base player play move
                }
                colSum = 0;

            }
            base.play(board);
        }
    }
}

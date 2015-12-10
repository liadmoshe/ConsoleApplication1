using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Human:IHuman
    {
        public Human() { }
        public void play(IBoard board) {
            
            string rowStr, columnStr;
            Console.WriteLine("Enter row");
            rowStr = Console.ReadLine();
            Console.WriteLine("Enter column");
            columnStr = Console.ReadLine();
            while(!checkInput(rowStr,columnStr,board))
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("Enter row");
                rowStr = Console.ReadLine();
                Console.WriteLine("Enter column");
                columnStr = Console.ReadLine();
            }
        }

        private Boolean checkInput(string rowStr,string columnStr,IBoard board)
        {
            int boardSize = board.Size;
            int row=-1, column=-1;
            return (int.TryParse(rowStr, out row) && int.TryParse(columnStr, out column) &&
            row > -1 && column > -1 && row < boardSize && column<boardSize && board.put(row, column));
        }
    }
}

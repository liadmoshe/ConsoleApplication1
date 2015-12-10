using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IBoard
    {
        int get(int row, int column);
        Boolean put(int row, int column);
        Boolean gameOver();
        int Size { get; }
        int Turn { get; }
    }
}

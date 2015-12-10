using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [player(typeof(IRandom))]
    class RandomPlayer:ComputerPlayer,IRandom
    {
        Random _random = new Random();
        public override void play(IBoard board) {
           
            _random.play(board);
        }
    }
}

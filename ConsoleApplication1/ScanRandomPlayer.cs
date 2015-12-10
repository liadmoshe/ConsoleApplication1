using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [player(typeof(IScanRandom))]
    class ScanRandomPlayer:ComputerPlayer,IScanRandom
    {
        ScanRandom _scanRandom = new ScanRandom();

        public override void play(IBoard board)
        {
            _scanRandom.play(board);
        }
    }
}

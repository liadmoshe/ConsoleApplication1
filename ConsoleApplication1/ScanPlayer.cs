using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [player(typeof(IScan))]
    class ScanPlayer:ComputerPlayer,IScan
    {
        Scan _scan;
        public ScanPlayer()
        {
           _scan = new Scan();
        }

        public override void play(IBoard board)
        {
            
            _scan.play(board);
        }
    }
}

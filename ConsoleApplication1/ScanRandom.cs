using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ScanRandom : Player, IScanRandom
    {
        Scan _scan = new Scan();
        Random _random = new Random();
        Boolean _switch=true;
        public override void play(IBoard board)
        {
            
            if(_switch)
            {
                Console.WriteLine("NOW PLAYING AS RANDOM");
                _random.play(board);
                _switch = false;
            }
            else
            {
                Console.WriteLine("NOW PLAYING AS SCAN");
                _scan.play(board);
                _switch = true;
            }
        }
    }
}

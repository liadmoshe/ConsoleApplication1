using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [player(typeof(IHuman))]
    class HumanPlayer:Player,IHuman
    {
        Human _human;
        public HumanPlayer()
        {
            _human = new Human();
        }
        public override void play(IBoard board)
        {
            
            _human.play(board);
        }
    }
}

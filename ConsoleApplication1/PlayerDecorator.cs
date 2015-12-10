using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    abstract class PlayerDecorator:ComputerPlayer
    {
        private ComputerPlayer _player;

        public PlayerDecorator(ComputerPlayer player)
        {
            _player = player;
        }
        
        public override void read()
        {
            _player.read();
        }

        public override void play(IBoard board)
        {
            _player.play(board);
        }

        public override void display()
        {
            _player.display();
        }
        
    }
}

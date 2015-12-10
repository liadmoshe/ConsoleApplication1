using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IPlayer
    {
        String Name { get; set; }
        void read();
        void play(IBoard board);
        void display();
        
    }
}

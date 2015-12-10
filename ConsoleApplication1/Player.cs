using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   
    abstract class Player:IPlayer
    {
        private string _name;
        

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

       

        public virtual void read()
        {
            Console.WriteLine("Enter player name");
            Name = Console.ReadLine();
        }
        
        abstract public void play(IBoard board);

        public virtual void display()
        {
            Console.WriteLine("Player name is:" + Name);
        }


    }
}

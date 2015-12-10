using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program 
    {
        static void Main(string[] args)
        {
           
            startGame();
        }

        static void startGame()
        {
            Factory factory = new Factory();
            IGame game = getGame(factory);
            game.start(factory);
        }    
            
        static IGame getGame(Factory factory)
        {
            IGame retVal = null;
            retVal = factory.createGame();
            return retVal;
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [GameAttriubutes("ticTacToe")]
    class Game:IGame
    {
        const int BOARD_SIZE = 3;
        public Game()
        {
            
        }
        static Dictionary<string, Type> _uioptions;
        public void start(Factory factory)
        {
            _uioptions = new Dictionary<string, Type>();
            _uioptions.Add("1", typeof(IHuman));
            _uioptions.Add("2", typeof(IScan));
            _uioptions.Add("3", typeof(IRandom));
            _uioptions.Add("4", typeof(IScanRandom));
            _uioptions.Add("5", typeof(IRowBlockerDecorator));
            _uioptions.Add("6", typeof(IColumnBlockerDecorator));
            _uioptions.Add("7", typeof(IDiagBlockerDecorator));

            IMemento onePlay = null;
            IMemento twoPlays = null;
            IPlayer firstPlayer = getPlayer(factory);
            firstPlayer.read();
            
            IPlayer secondPlayer = getPlayer(factory);
            secondPlayer.read();

            IPlayer activePlayer;
            

            IBoard board = getBoard(factory);
        
            while(!board.gameOver())
            {
                if (board.Turn == 1)
                {
                    activePlayer = firstPlayer;
                }
                else
                {
                    activePlayer = secondPlayer;
                }

                if (twoPlays!=null && suggestUndo(activePlayer))
                {
                    ((XoBoard)board).setMemento(twoPlays);
                    onePlay = null;
                    twoPlays = null;
                }
                else
                {
                    twoPlays = ((XoBoard)board).copyMemento(onePlay);
                    onePlay = ((XoBoard)board).createMemento();
                    activePlayer.play(board);
                    
                }
            }
        }

        Boolean suggestUndo (IPlayer player)
        {
            if (!(player is ComputerPlayer) )
            {
                Console.WriteLine("Insert 1 to play or anything else to UnDo");
                string choice = Console.ReadLine();
                return !(choice.Equals("1"));

            }
            return false;
        }

         IPlayer getPlayer(Factory factory)
        {
            IPlayer retVal = null;
            
            Console.WriteLine("Enter player type");
            string player = Console.ReadLine();
            retVal=factory.createPlayer(_uioptions[player]);
            List<Type> decorationTypes = new List<Type>();
            Console.WriteLine("Enter Decoration");
            string i = Console.ReadLine();
            while ((i.Equals("5")) || (i.Equals("6") || (i.Equals("7"))))
            {
                decorationTypes.Add(_uioptions[i]);
                Console.WriteLine("Enter Decoration");
                i = Console.ReadLine();
            }

            retVal = factory.createDecoratedPlayer(_uioptions[player], decorationTypes, retVal);
            return retVal;
        }
    
        static IBoard getBoard(Factory factory)
        {
            IBoard retVal = null;
            retVal = factory.createBoard(BOARD_SIZE);
            return retVal;
        }



    }
}

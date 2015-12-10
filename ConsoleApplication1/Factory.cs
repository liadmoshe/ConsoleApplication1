using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Factory
    {
        Dictionary<string, Type> _playerType;
        Type _gameType;
        Type _boardType;
        public Factory()
        {
            _playerType = new Dictionary<string, Type>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type objType in assembly.GetTypes())
            {
                playerAttribute attr =
                    objType.GetCustomAttribute<playerAttribute>();
                GameAttriubutes gameAttr =
                    objType.GetCustomAttribute<GameAttriubutes>();
                BoardAttributes boardAttr =
                    objType.GetCustomAttribute<BoardAttributes>();

                if (attr != null)
                {
                    RegisterPlayerType(attr.InterfaceType, objType);
                }

                if (gameAttr != null)
                {
                    registerGameType(objType);
                }

                if (boardAttr != null)
                {
                    registerBoardType(objType);
                }
            }
          

        }

        public void RegisterPlayerType(Type uiOption, Type playerType)
        {
            _playerType.Add(uiOption.Name, playerType);
        }

        public void registerGameType(Type gameType)
        {
            _gameType = gameType;
        }

        public void registerBoardType(Type boardType)
        {
            _boardType = boardType;
        }

        public IGame createGame()
        {
            IGame retVal = null;
            retVal = (IGame)Activator.CreateInstance(_gameType);
            return retVal;
        }
        public IPlayer createPlayer(Type playerType)
        {
            IPlayer retVal = null;
            string plType = playerType.Name;
            Type plClass = _playerType[plType];
            retVal = (IPlayer)Activator.CreateInstance(plClass);
            return retVal;
        }
        public IPlayer createDecoratedPlayer(Type playerType,List<Type> decorationOptions,IPlayer retVal)
        {
            //create decorators
            
            foreach (Type decorationInterface in decorationOptions)
            {
                Type playerDecorationClass = _playerType[decorationInterface.Name];
                
                Console.WriteLine("creating decorator");
                retVal = (IPlayer)
                         Activator.CreateInstance(playerDecorationClass, retVal);
            }
            
            return retVal;
        }

       

        public IBoard createBoard(int size)
        {
            IBoard retVal = null;
            retVal = (IBoard)Activator.CreateInstance(_boardType,size);
            BoardViewer bv = new BoardViewer(retVal);
            return retVal;
        }
    }
}

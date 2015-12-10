using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public delegate void BoardUpdate();
    
    [BoardAttributes("ticTacToe")]
    
    class XoBoard : Board
    {
        
        public event  BoardUpdate onUpdate = null;
        private int[,] _matrix;
        
   
        public XoBoard(int size):base(size)
        {
            _matrix = new int[size, size];
            resetBoard();
        }
        
        public override Boolean put(int row,int column)
        {
            try
            {
                if (_matrix[row, column] != 0)
                    return false;
                _matrix[row, column] = Turn;
                _turn *= -1;
                if (onUpdate != null)
                {
                    onUpdate();
                }
                return true;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidRowOrColumnException(this, row, column);  
            }

        }

        public class InvalidRowOrColumnException:Exception
        {
            public int BoardSize { get; private set; }
            public int Row { get; private set; }
            public int Col { get; private set; }

            public InvalidRowOrColumnException(IBoard board,int row,int col):base("Invalid row and column:"+row+":"+col+":"+board.Size)
            {
                BoardSize = board.Size;
                Row = row;
                Col = col;
            }
        }

        public override int get(int row, int column)
        {
            return _matrix[row, column];
        }

        private void resetBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _matrix[i, j] = 0;
                }
            }
        }

        public override Boolean  gameOver()
        {
            Boolean retVal = false;
            int size = Size;
            int maxCo = Math.Abs(maxColumn());
            int maxRo = Math.Abs(maxRow());
            int maxDi = Math.Abs(maxDiag());
            retVal = (maxCo == size);
            retVal |= (maxRo == size);
            retVal |= (maxDi == size);
            retVal |= tie();

            if (retVal)
            {
                Console.WriteLine("GAME OVER");
            }
            return retVal;
        }

        private Boolean tie()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (get(i, j) == 0)
                        return false;
                }
            }
            return true;
        }

        private int maxRow()
        {
            int rowSum = 0;
            int max = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    rowSum += get(i, j);

                if (Math.Abs(rowSum) > Math.Abs(max))
                    max = rowSum;
                rowSum = 0;
            }
            return max;
        }

        private int maxColumn()
        {
            int columnSum = 0;
            int max = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    columnSum += get(j, i);

                if (Math.Abs(columnSum) > Math.Abs(max))
                    max = columnSum;
                columnSum = 0;
            }
            return max;
        }

        private int maxDiag()
        {
            
            int firstAlahsonSum = 0, secondAlahsonSum = 0;
            int leftI = 0, leftJ = 0, rightI = 0, rightJ = Size - 1;
            while (leftI < Size && leftJ < Size)
            {

                firstAlahsonSum += get(leftI, leftJ);
                secondAlahsonSum += get(rightI, rightJ);
                leftI++;
                leftJ++;
                rightI++;
                rightJ--;
            }
            if (Math.Abs(firstAlahsonSum) >= Math.Abs(secondAlahsonSum))
                return firstAlahsonSum;
            else
                return secondAlahsonSum;
        }


        public IMemento createMemento()
        {
            return new Memento(this);
        }

        public IMemento copyMemento(IMemento memento)
        {
            if (memento == null)
                return null;
            return new Memento(memento);
        }
        

        public void setMemento(IMemento memento)
        {
            Memento boardMemento = (Memento)memento;
            Array.Copy(boardMemento.Matrix, _matrix, _matrix.Length);
            _turn = boardMemento.Sign;
            if(onUpdate!=null)
            {
                onUpdate();
            }
        }

        private class Memento:IMemento
        {
            private int[,] _mat;
            private int _sign;
            public Memento(XoBoard board)
            {
                _mat = new int[board._matrix.Length, board._matrix.Length];
                _sign = board.Turn;
                Array.Copy(board._matrix, _mat,board._matrix.Length);
            }

            public Memento(IMemento memento)
            //copy constructor
            {
                Memento mem = ((Memento)memento);
                if (memento != null)
                {
                    
                    _mat = new int[mem._mat.Length, mem._mat.Length];
                    _sign = mem.Sign;
                    Array.Copy(mem._mat, _mat, mem._mat.Length);
                }
            }
            /*
            public IMemento cloneMemento(IMemento memento)
            {
                IMemento retVal = null;
                if (memento != null)
                {
                    retVal = new Memento(memento);
                }
                return retVal;

            }*/

            public int[,] Matrix
            {
                get
                {
                    return _mat;
                }
            }

            public int Sign
            {
                get
                {
                    return _sign;
                }
            }
        }
    }
}

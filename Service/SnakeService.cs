using System;
using SnakeArray.Model;


namespace SnakeArray.Service
{
        ///<summary>
        /// Класс для заполнения массива числами "змейкой".
        /// </summary>
        public class SnakeService : ISnakeService
        {
            private int[,] _array;
            private int _numColumns;
            private int _numRows;

            // Текущий элемент строки x.  
            private int _x = 0;
            // Текущая строка y.
            private int _y = 0;
            private enum Direction { Right, Down, Left, Up };
            private Direction _currentDir = Direction.Right;

            public SnakeModel CalculateModel(int numColumns, int numRows)
            {
                _numRows = numRows;
                _numColumns = numColumns;
                _array = new int[numColumns, numRows];
                var counter = 0;
                do
                {
                    counter++;
                    _array[_x, _y] = counter;
                }
                while (FindNext());
                return new SnakeModel (_numColumns, _numRows, _array);
            }





            // Поиск следующего элемента массива в заданном порядке;
            // возвращает false, если элемент отсутствует.
            private bool FindNext()
            {
                var tmpX = _x;
                var tmpY = _y;
                var fails = 0;
                while (true)
                {
                    switch (_currentDir)
                    {
                        case Direction.Right:
                            tmpX++;
                            break;
                        case Direction.Down:
                            tmpY++;
                            break;
                        case Direction.Left:
                            tmpX--;
                            break;
                        case Direction.Up:
                            tmpY--;
                            break;
                    }

                    if (tmpX >= 0 && tmpX < _numColumns &&
                         tmpY >= 0 && tmpY < _numRows)
                    {
                        if (_array[tmpX, tmpY] == 0)
                        {
                            _x = tmpX;
                            _y = tmpY;
                            return true;
                        }
                    }
                    // Вышли за границу массива или элемент уже преобразован.
                    tmpX = _x;
                    tmpY = _y;
                    _currentDir = NewDirection(_currentDir);
                    // Нет подходящих элементов по всем направлениям.
                    if (++fails == 4) 
						return false;
                }
            }

            private Direction NewDirection(Direction dir)
            {
                switch (dir)
                {
                    case Direction.Right:
                        return Direction.Down;
                    case Direction.Down:
                        return Direction.Left;
                    case Direction.Left:
                        return Direction.Up;
                    case Direction.Up:
                        return Direction.Right;
                }
                throw new MissingMemberException("Enum Direction do not contains such element");
            }
        }
}

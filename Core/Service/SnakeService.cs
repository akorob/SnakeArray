using System;
using Core.Model;
using UserInterfaceDevExpress;
using UserInterfaceWinForms;

namespace Core.Service
{
        ///<summary>
        /// Класс для заполнения массива числами "змейкой".
        /// </summary>
        public class SnakeService : ISnakeService
        {
            private int[,] _array;
            private int _numColumns;
            private int _numRows;


            private int _x ;
            private int _y ;
            private enum Direction { Right, Down, Left, Up };

            private Direction _currentDir; 

            /// <summary>
            /// Заполнение массива задаваемой размерности числами "змейкой".
            /// </summary>
            /// <param name="numColumns"></param>
            /// <param name="numRows"></param>
            /// <returns></returns>
            public ArrayInfo CalculateModel(int numRows, int numColumns )
            {
                _numRows = numRows;
                _numColumns = numColumns;
                _array = new int[numRows, numColumns];
                _currentDir = Direction.Right;
                _x = 0;
                _y = 0;
                var counter = 0;
                do
                {
                    counter++;
                    _array[_x, _y] = counter;
                }
                while (FindNext());
                return new ArrayInfo(_numRows, _numColumns, _array);
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
                            tmpY++;
                            break;
                        case Direction.Down:
                            tmpX++;
                            break;
                        case Direction.Left:
                            tmpY--;
                            break;
                        case Direction.Up:
                            tmpX--;
                            break;
                    }

                    if (tmpX >= 0 && tmpX < _numRows &&
                         tmpY >= 0 && tmpY < _numColumns)
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

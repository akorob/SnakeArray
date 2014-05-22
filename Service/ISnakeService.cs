using System;
using SnakeArray.Model;

namespace SnakeArray.Service
{
    public interface ISnakeService
    {
        /// Заполняет массив "змейкой".
        /// <exception cref="MissingMemberException">
        /// Неверное использование перечисления Direction
        /// </exception>
        SnakeModel CalculateModel(int numColumns, int numRows);
    }
}
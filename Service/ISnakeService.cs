using System;
using SnakeArray.Model;

namespace SnakeArray.Service
{
    /// <summary>
    /// Интерфейс сервис класса для заполнения массива числами "змейкой".
    /// </summary>
    public interface ISnakeService
    {
        /// <summary>
        /// Заполняет массив "змейкой".
        /// </summary>
        /// <param name="numColumns"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        /// <exception cref="MissingMemberException">
        /// Неверное использование перечисления Direction
        /// </exception>
        ArrayInfo CalculateModel(int numColumns, int numRows);
    }
}
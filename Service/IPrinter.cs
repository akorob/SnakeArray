using SnakeArray.Model;

namespace SnakeArray.Service
{
    public interface IPrinter
    {
        /// <summary>
        /// Вывод массива.
        /// </summary>
        /// <param name="model"></param>
        void Print(ArrayInfo model);
    }
}

using SnakeArray.Model;

namespace SnakeArray.Service
{
    interface IPrinter
    {
        ///<summary> Вывод заполненного массива. </summary>
        void Print(SnakeModel model);
    }
}

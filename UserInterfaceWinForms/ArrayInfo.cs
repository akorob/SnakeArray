namespace UserInterfaceDevExpress
{
    /// <summary>
    /// Класс описывающий результирующий массив.
    /// </summary>
    public class ArrayInfo
    {
        /// <summary>
        /// Количество строк массива.
        /// </summary>
        public int NumRows { get; private set; }

        /// <summary>
        /// Количество столбцов массива.
        /// </summary>
        public int NumColumns { get; private set; }

        /// <summary>
        /// Заполненный "змейкой" массив.
        /// </summary>
        public int[,] Array { get; private set; }

        public ArrayInfo(int numRows, int numColumns, int[,] array)
        {
            NumColumns = numColumns;
            NumRows = numRows;
            Array = array;
        }
    }
}

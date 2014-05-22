namespace SnakeArray.Model
{
    /// <summary>
    /// Класс для хранения заполненного массива, M в MVP.
    /// </summary>
    public class SnakeModel
    {
        public int NumRows { get; private set; }
        public int NumColumns { get; private set; }
        public int[,] Array { get; private set; }

        public SnakeModel(int numColumns, int numRows, int[,] array)
        {
            NumColumns = numColumns;
            NumRows = numRows;
            Array = array;
        }
    }
}

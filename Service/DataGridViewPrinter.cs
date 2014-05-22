using System;
using System.Windows.Forms;
using NLog;
using SnakeArray.Model;

namespace SnakeArray.Service
{
    ///<summary>
    /// Вывод заполненного массива на экран в объект DataGridView.
    /// </summary>
    class DataGridViewPrinter: IPrinter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public DataGridView DataGrid { get; set; }

        public void Print(SnakeModel model)
        {
 			try
	        {
				DataGrid.Rows.Clear();
				DataGrid.ColumnCount = model.NumColumns;
				DataGrid.RowCount = model.NumRows;
                for (var j = 0; j < model.NumRows; j++)
				{
                    for (var i = 0; i < model.NumColumns; i++)
					{
						DataGrid.Rows[j].Cells[i].Value = model.Array[i, j];
					}
				}
                logger.Info("Массив успешно отображен в DataGrid.");
	        }
	        catch (InvalidOperationException ex)
	        {
                logger.Warn("Ошибка отображения массива в DataGrid. "+ ex.ToString());    
		        MessageBox.Show(ex.ToString());
	        }
			catch (ArgumentException ex)
	        {
                logger.Warn("Ошибка отображения массива в DataGrid. " + ex.ToString());
		        MessageBox.Show(ex.ToString());
	        }
			catch (IndexOutOfRangeException ex)
			{
                logger.Warn("Ошибка отображения массива в DataGrid. " + ex.ToString());
				MessageBox.Show(ex.ToString());
			}

		
        }
    }
}

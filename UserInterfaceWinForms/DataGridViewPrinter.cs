using System;
using System.Windows.Forms;
using NLog;
using UserInterfaceDevExpress;

namespace UserInterfaceWinForms
{
    ///<summary>
    /// Вывод заполненного массива на экран в объект DataGridView.
    /// </summary>
    class DataGridViewPrinter: IPrinter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        ///<summary>
        /// Элемент DataGridView главной формы приложения.
        /// </summary>
        public DataGridView DataGrid { get; set; }

        /// <summary>
        /// Отображает матрицу в DataGridView.
        /// </summary>
        /// <param name="model"></param>
        public void Print(ArrayInfo model)
        {
 			try
            {
                
				DataGrid.Rows.Clear();
				DataGrid.ColumnCount = model.NumColumns;
				DataGrid.RowCount = model.NumRows;
                for (var i = 0; i < model.NumColumns; i++)
				{
                    for (var j = 0; j < model.NumRows; j++)
					{
						DataGrid.Rows[j].Cells[i].Value = model.Array[i, j];
					}
				}
                logger.Info("Массив успешно отображен в DataGrid.");
	        }
	        catch (Exception ex)
	        {
                logger.Warn("Ошибка отображения массива в DataGrid. "+ ex.ToString());    
		        MessageBox.Show(ex.ToString());
	        }
			

		
        }
    }
}

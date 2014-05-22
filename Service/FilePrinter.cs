using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NLog;
using SnakeArray.Model;

namespace SnakeArray.Service
{
    ///<summary>
    /// Вывод заполненного массива в файл.
    /// </summary>
    class FilePrinter : IPrinter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public String Path { get; set; }

	    public void Print(SnakeModel model)
	    {
		    var sb = new StringBuilder();
		    for (var j = 0; j < model.NumRows; j++)
		    {
			    for (var i = 0; i < model.NumColumns; i++)
			    {
				    sb.AppendFormat("{0,4}", model.Array[i, j]);
			    }
			    sb.AppendLine();
		    }
		    try
		    {
			    using (var w = new StreamWriter(Path))
			    {
				    w.WriteLine(sb.ToString());
					MessageBox.Show("Данные успешно сохранены", 
					"Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.None );
                    logger.Info("Массив успешно сохранен в файл.");
			    }

		    }
		    catch (IOException ex)
		    {
                logger.Info("Ошибка сохранения в файл. " + ex.ToString());
			    MessageBox.Show("Произошла ошибка \n" + ex.ToString(),
				    "Печать в файл", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }


	    }

    }
}

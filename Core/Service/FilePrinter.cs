using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Core.Model;
using NLog;
using UserInterfaceDevExpress;

namespace Core.Service
{
    ///<summary>
    /// Вывод заполненного массива в файл.
    /// </summary>
    class FilePrinter : IPrinter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Путь к файлу для сохранения результатов.
        /// </summary>
        public String Path { get; set; }

        /// <summary>
        /// Вывод результатов в файл.
        /// </summary>
        /// <param name="model"></param>
        public void Print(ArrayInfo model)
       {
		    var sb = new StringBuilder();
            for (var i = 0; i < model.NumRows; i++)
		    {
			    for (var j = 0; j < model.NumColumns; j++)
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
                    logger.Info("Массив успешно сохранен в файл. Файл: " + Path);
					MessageBox.Show("Массив успешно сохранен в файл", 
					"Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.Information );            
			    }

		    }
		    catch (IOException ex)
		    {
                logger.Info("Ошибка сохранения в файл: " + Path + "\n" + ex.ToString());
			    MessageBox.Show("Произошла ошибка \n" + ex.ToString(),
				    "Печать в файл", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }


	    }
    }
}

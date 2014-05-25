using System;
using System.Windows.Forms;


namespace UserInterfaceWinForms 
{
    ///<summary>
    /// Главная форма приложения.
    /// </summary>
    public partial class SnakeFormView : Form, ISnakeView
    {
        
        public SnakeFormView() 
        {
            InitializeComponent();
        }

        /// <summary>
        /// Путь к файлу вывода.
        /// </summary>
        public string FilePath
        {
            get { return textBoxFilePath.Text; }
            set { textBoxFilePath.Text = value; }
        }

        /// <summary>
        /// Количество строк матрицы.
        /// </summary>
        public int NumRows
        {
            get { return (int)rowsUpDown.Value; }
            set { rowsUpDown.Value = value; }
        }

        /// <summary>
        /// Количество столбцов матрицы.
        /// </summary>
        public int NumColumns
        {
            get { return (int)columnsUpDown.Value; }
            set { columnsUpDown.Value = value; }
        }

        /// <summary>
        /// Метод возвращает объект DataGridViewPrinter для вывода матрицы на экран.
        /// </summary>
        public IPrinter GetViewPrinter()
        {
            IPrinter dgPrinter = new DataGridViewPrinter { DataGrid = this.dataGrid};
            return dgPrinter;

        }

        /// <summary>
        /// Нажатие кнопки "Построить".
        /// </summary>
        public event EventHandler<EventArgs> BuildClicked;

        /// <summary>
        /// Нажатие кнопки для выбора файла.
        /// </summary>
        public event EventHandler<EventArgs> FileSelectClicked;

        /// <summary>
        /// Закрытие приложения.
        /// </summary>
        public event EventHandler<EventArgs> AppFormClosing;

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (BuildClicked != null)
            {
                BuildClicked(this, EventArgs.Empty);
            }
        }


        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            if (FileSelectClicked != null)
            {
                FileSelectClicked(this, EventArgs.Empty);
            }
            
        }

        private void SnakeFormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppFormClosing != null)
            {
                AppFormClosing(this, EventArgs.Empty);
            }

        }

    }

}

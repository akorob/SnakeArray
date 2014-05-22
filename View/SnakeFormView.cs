using System;

using System.Windows.Forms;
using Microsoft.Practices.Unity;
using NLog;
using SnakeArray.Model;
using SnakeArray.Presenter;
using SnakeArray.Service;

namespace SnakeArray.View 
{
    ///<summary>
    /// Главная форма приложения.
    /// </summary>
    public partial class SnakeFormView : Form, ISnakeView
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private SnakePresenter _presenter;
        
        public SnakeFormView() 
        {
            InitializeComponent();
            logger.Debug("Создана главная форма приложения");
        }

        [Dependency]
        public SnakePresenter MyPresenter
        {
            get { return _presenter; }
            set
            {
                _presenter = value;
                _presenter.SetView(this);
            }
        }

        public string FilePath
        {
            get { return textBoxFilePath.Text; }
            set { textBoxFilePath.Text = value; }
        }

        public int NumRows
        {
            get { return (int)rowsUpDown.Value; }
            set { rowsUpDown.Value = value; }
        }

        public int NumColumns
        {
            get { return (int)columnsUpDown.Value; }
            set { columnsUpDown.Value = value; }
        }

        public DataGridView MyDataGridView
        {
            get { return this.dataGrid; }
        }

        public event EventHandler<EventArgs> BuildClicked;

        public event EventHandler<EventArgs> FileSelectClicked;


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

    }

}

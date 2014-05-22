using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using NLog;
using SnakeArray.View;
using SnakeArray.Service;

namespace SnakeArray.Presenter
{
    /// <summary>
    /// Класс для взаимодействия с view, P в MVP паттерне.
    /// </summary>
    public class SnakePresenter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ISnakeView _view;

        /// <summary>
        /// Инициализация класса.
        /// </summary>
        public void SetView(ISnakeView view)
        {
            this._view = view;
            _view.BuildClicked += new EventHandler<EventArgs>(OnBuildClick);
            _view.FileSelectClicked += new EventHandler<EventArgs>(OnFileSelectClick);
        }

        [Dependency]
        public ISnakeService SnakeService { get; set; }

        private void OnBuildClick(object sender, EventArgs e)
        {
            logger.Info("Нажата кнопка 'построить', количество строк массива " + _view.NumRows+
                ", количество столбцов " + _view.NumColumns+".");
            var model = SnakeService.CalculateModel(_view.NumColumns, _view.NumRows);
            IPrinter dgPrinter = new DataGridViewPrinter {DataGrid = _view.MyDataGridView};
            dgPrinter.Print(model);

            var result = MessageBox.Show("Сохранить в файл?", "Сохранение в файл",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result != DialogResult.OK)
            {
                logger.Info("Отказ сохранить построенный массив в файл");
                return;
            }

            if (string.IsNullOrEmpty(_view.FilePath))
            {
                logger.Info("Ошибка сохранения массива в файл - не указан путь.");
                MessageBox.Show("Файл не указан", "Сохранение файла",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IPrinter fPrinter = new FilePrinter { Path = _view.FilePath };
            fPrinter.Print(model);
        }

        private void OnFileSelectClick(object sender, EventArgs e)
        {
            var openFileDlg = new OpenFileDialog
            {
                Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = false
            };
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                logger.Info("Нажата кнопка выбора файла, выбран файл: " + openFileDlg.FileName);
                _view.FilePath = openFileDlg.FileName;
            }
            logger.Info("Нажата кнопка выбора файла, файл не выбран.");
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using NLog;
using SnakeArray.Model;
using SnakeArray.View;
using SnakeArray.Service;

namespace SnakeArray.Presenter
{
    /// <summary>
    /// Класс для взаимодействия с view, P в MVP паттерне.
    /// </summary>
    public class SnakePresenter : IDisposable
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ISnakeView _view;
        private readonly ISnakeService _snakeService;

        public SnakePresenter(ISnakeView view, ISnakeService service, Settings settings)
        {
            this._view = view;
            this._snakeService = service;

            SignViewEvents();

            if (settings == null)
                return;
            view.FilePath = settings.Path;
            try
            {
                view.NumRows = settings.NumRows;
                view.NumColumns = settings.NumColumns;
                logger.Info("Приложение запущено, последние настройки успешно загружены из файла.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //MessageBox.Show("В конфигурационном файле неверные данные \n" + ex.ToString(),
                //"Инициализация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Info("Приложение запущено, в конфигурационном файле неверные данные. \n" + ex.ToString());
            }
        }

        private void OnBuildClick(object sender, EventArgs e)
        {
            logger.Info("Нажата кнопка 'построить', количество строк массива " + _view.NumRows+
                ", количество столбцов " + _view.NumColumns+".");
            var model = _snakeService.CalculateModel(_view.NumColumns, _view.NumRows);
            var printer = _view.GetViewPrinter();
            printer.Print(model);

            if (!string.IsNullOrEmpty(_view.FilePath))
            {
                IPrinter fPrinter = new FilePrinter { Path = _view.FilePath };
                fPrinter.Print(model);
            }
           
            
        }

        private void OnFileSelectClick(object sender, EventArgs e)
        {
            var openFileDlg = new OpenFileDialog
            {
                Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = false,
            };
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                logger.Info("Нажата кнопка выбора файла, выбран файл: " + openFileDlg.FileName);
                _view.FilePath = openFileDlg.FileName;
            }
            logger.Info("Нажата кнопка выбора файла, файл не выбран.");
        }


        private void OnFormClosing(object sender, EventArgs e)
        {
            logger.Info("Приложение закрыто, настройки будут сохранены.");
            var appSettings = Settings.Instance;
            appSettings.Path = _view.FilePath;
            appSettings.NumRows = _view.NumRows;
            appSettings.NumColumns = _view.NumColumns;
        }


        public void Dispose()
        {
            UnSignViewEvents();
        }

        private void SignViewEvents()
        {
            _view.BuildClicked += OnBuildClick;
            _view.FileSelectClicked += OnFileSelectClick;
            _view.AppFormClosing += OnFormClosing;
        }

        private void UnSignViewEvents()
        {
            _view.BuildClicked -= OnBuildClick;
            _view.FileSelectClicked -= OnFileSelectClick;
            _view.AppFormClosing -= OnFormClosing;
        }
    }
}

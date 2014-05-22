using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using NLog;
using SnakeArray.Model;
using SnakeArray.Service;
using SnakeArray.View;

namespace SnakeArray 
{
    static class Program 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Главная точка входа в приложение.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ISnakeService, SnakeService>();
            var view = container.Resolve<SnakeFormView>();

            var appSettingsPath = System.IO.Path.Combine(Application.CommonAppDataPath, "app.config");
            var settings = Serializer.DeserializeObject<Settings>(appSettingsPath);
            LoadAppSettings(settings, view);
            Application.Run(view);
            settings = SaveAppSettings(view);
            Serializer.SerializeObject(appSettingsPath, settings);

        }



        private static void LoadAppSettings(Settings settings, ISnakeView view)
        {
            if (settings == null)
            {
                return;
            }
            view.FilePath = settings.Path;
            try
            {
                view.NumRows = settings.NumRows;
                view.NumColumns = settings.NumColumns;
                logger.Info("Приложение запущено, последние настройки успешно загружены из файла.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("В конфигурационном файле неверные данные \n" + ex.ToString(),
                "Инициализация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Info("Приложение запущено, в конфигурационном файле неверные данные :" + ex.ToString());
            }
        }

        private static Settings SaveAppSettings(ISnakeView view)
        {
            logger.Info("Приложение закрыто, настройки будут сохранены.");
            logger.Debug(view.FilePath);
            var appSettings = Settings.Instance;
            appSettings.Path = view.FilePath;
            appSettings.NumRows = view.NumRows;
            appSettings.NumColumns = view.NumColumns;
            return appSettings;
        }
    }
}

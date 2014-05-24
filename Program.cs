using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using NLog;
using SnakeArray.Model;
using SnakeArray.Presenter;
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
            var view = new SnakeFormView();
            var service = new SnakeService();
            var appSettingsPath = System.IO.Path.Combine(Application.CommonAppDataPath, "app.config");
            var settings = Serializer.DeserializeObject<Settings>(appSettingsPath);

            var presenter = new SnakePresenter(view, service, settings);

            Application.Run(view);

            Serializer.SerializeObject(appSettingsPath, Settings.Instance);
        }


    }
}

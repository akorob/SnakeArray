using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Model;
using Core.Presenter;
using Core.Service;
using UserInterfaceWinForms;

namespace Core
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



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

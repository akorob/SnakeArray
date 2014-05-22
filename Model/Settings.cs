using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using NLog;

namespace SnakeArray.Model
{
    ///<summary>
	/// Класс - singlton для хранения и сериализации/десереализации 
	/// настроек приложения в XML.
    /// </summary>
    [Serializable]
    public class Settings
    {

        private static  Settings _instance = new Settings();

        ///<summary>
        /// Возвращает экземпляр класса.
        /// </summary>
        public static Settings Instance
        {
                get { return _instance; }
        }
        private Settings() { }

        ///<summary>
        /// Количество столбцов матрицы.
        /// </summary>
        [XmlElement]
	    public int NumColumns { get; set; }

        ///<summary>
        /// Количество строк матрицы.
        /// </summary>
        [XmlElement]
        public int NumRows { get; set; }

        ///<summary>
        /// Путь к файлу вывода.
        /// </summary>
        [XmlElement]
        public string Path { get; set; }


    }
}

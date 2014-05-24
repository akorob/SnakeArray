using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using NLog;

namespace SnakeArray.Model
{
    ///<summary>
    /// Класс - синглтон для хранения настроек приложения.
    /// </summary>
    [Serializable]
    public class Settings
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private int _numColumns;
        private int _numRows;
        private string _path;

        private XmlSerializer _mySerializer = new XmlSerializer(typeof (Settings));
        private static Settings _instance = new Settings();

        ///<summary>
        /// Возвращает экземпляр класса.
        /// </summary>
        public static Settings Instance
        {
            get { return _instance; }
        }

        private Settings()
        {
        }

        ///<summary>
        /// Количество столбцов матрицы.
        /// </summary>
        [XmlElement]
        public int NumColumns
        {
            get { return _numColumns; }
            set { _numColumns = value; }
        }

        ///<summary>
        /// Количество строк матрицы.
        /// </summary>
        [XmlElement]
        public int NumRows
        {
            get { return _numRows; }
            set { _numRows = value; }
        }

        ///<summary>
        /// Путь к файлу для сохранения результата.
        /// </summary>
        [XmlElement]
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

    }
}

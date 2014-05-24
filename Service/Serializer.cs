using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using NLog;
using SnakeArray.Model;

namespace SnakeArray.Service
{

    /// <summary>
    /// Сериализация и десериализация 
    /// </summary>
    public class Serializer
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Десериализовать объект из xml файла. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializeFileName"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string serializeFileName)
            where T : class
        {
            try
            {
                var ser = new XmlSerializer(typeof (T));
                var fi = new FileInfo(serializeFileName);
                if (fi.Exists)
                {
                    using (var fileStream = fi.OpenRead())
                    {
                        var res = (T) ser.Deserialize(fileStream);
                        logger.Info("Десереализация настроек из файла произошла успешно");
                        return res;
                    }
                }
                else
                {
                    logger.Info("Файл настроек отсутствует. Файл: " + serializeFileName);
                }
            }
            catch (Exception ex)
            {
                logger.Warn("Ошибка загрузки настроек. " + ex.ToString());
             //   MessageBox.Show("Произошла ошибка \n" + ex.ToString(),
             //        "Инициализация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        /// <summary>
        /// Сериализовать объект в xml файл.
        /// </summary>.
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="serializeFileName"></param>
        public static void SerializeObject<T>(string serializeFileName, T obj)
        {   
            try
            {
                var mySerializer = new XmlSerializer(typeof(T));
                using (var myWriter = new StreamWriter(serializeFileName, false))
                {
                    Console.WriteLine(obj);
                    mySerializer.Serialize(myWriter, obj);
                    logger.Info("Сереализация настроек в файл произведена успешно.");
                }
            }
            catch(Exception ex)
            {
                logger.Warn("Ошибка сохранения настроек. " + ex.ToString());
             //   MessageBox.Show("Произошла ошибка \n" + ex.ToString(), 
			 //		"Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

    }
}
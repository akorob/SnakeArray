using System;

namespace UserInterfaceWinForms
{
    /// <summary>
    /// Интерфейс главной формы приложения, для реализации V в MVP.
    /// </summary>
    public interface ISnakeView
    {
        /// <summary>
        /// Нажатие кнопки "Построить".
        /// </summary>
        event EventHandler<EventArgs> BuildClicked;

        /// <summary>
        /// Нажатие кнопки для выбора файла.
        /// </summary>
        event EventHandler<EventArgs> FileSelectClicked;

        /// <summary>
        /// Закрытие приложения.
        /// </summary>
        event EventHandler<EventArgs> AppFormClosing;

        /// <summary>
        /// Путь к файлу вывода.
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Количество строк матрицы.
        /// </summary>
        int NumRows { get; set; }

        /// <summary>
        /// Количество столбцов матрицы.
        /// </summary>
        int NumColumns { get; set; }

        /// <summary>
        /// Метод возвращает объект для вывода матрицы на экран.
        /// </summary>
        IPrinter GetViewPrinter();

    }
}

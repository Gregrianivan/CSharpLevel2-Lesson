using System.Diagnostics;

namespace Game_SyrovatskijIS
{
    /// <summary>Класс логирования действий программы</summary>
    class Logging
    {
        /// <summary>Метод записи в файл</summary>
        /// <param name="Msg">Текст сообщения</param>
        internal static void Log(string Msg)
        {
            using (var sw = new System.IO.StreamWriter("data.log", true))
            {
                Debug.WriteLine(Msg);
                sw.WriteLine(Msg);
            }
        }

        internal class Log
        {
        }
    }
}

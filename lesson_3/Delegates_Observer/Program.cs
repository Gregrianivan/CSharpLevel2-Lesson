﻿/*
 * 5)* Добавить в пример Lesson3 обобщенный делегат. 
 * 
 * Сыроватский Иван
 */

using System;


namespace Delegates_Observer
{
    class Source
    {
        //добавил обобщённый делегат здесь
        public event Action<object> Run;

        public void Start()
        {
            Console.WriteLine("RUN");
            if (Run != null) Run(this);
        }
    }
    class Observer1 // Наблюдатель 1
    {
        public void Do(object o)
        {
            Console.WriteLine("Первый. Принял, что объект {0} побежал", o);
        }
    }
    class Observer2 // Наблюдатель 2
    {
        public void Do(object o)
        {
            Console.WriteLine("Второй. Принял, что объект {0} побежал", o);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Source s = new Source();
            Observer1 o1 = new Observer1();
            Observer2 o2 = new Observer2();
            //а также добавил обобщённый делегат здесь
            Action<object> d1 = o1.Do;
            s.Run += d1;
            s.Run += o2.Do;
            s.Start();
            s.Run -= d1;
            s.Start();
        }
    }
}

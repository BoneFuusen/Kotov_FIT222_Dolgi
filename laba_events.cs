using System;
using System.Collections.Generic;

namespace AMOGUS
{
    internal class Program
    {
        delegate void Delegate();
        public static double x;
        public static double y;
        class Event1
        {
            Delegate[] event1 = new Delegate[4];
            public event Delegate SomeEvent
            {
                add
                {
                    int i;
                    for (i = 0; i < 4; i++)
                        if (event1[i] == null)
                        {
                            event1[i] = value;
                            break;
                        }
                    if (i == 3) Console.WriteLine("Список событий заполнен.");
                }
                remove
                {
                    int i;
                    for (i = 0; i < 4; i++)
                        if (event1[i] == value)
                        {
                            event1[i] = null;
                            break;
                        }
                    if (i == 3) Console.WriteLine("Обработчик событий не найден.");
                }
            }
            public void OnEvent()
            {
                for (int i = 0; i < 4; i++)
                    event1[i]?.Invoke();
            }

        }
        class Summ
        {
            public void Summer()
            {
                Console.WriteLine(x + y);
            }
        }
        class Diff
        {
            public void Differ()
            {
                Console.WriteLine(x - y);
            }
        }
        class Mult
        {
            public void Multiplyer()
            {
                Console.WriteLine(x * y);
            }
        }
        class Division
        {
            public void Divider()
            {
                if (y != 0)
                {
                    Console.WriteLine(x / y);
                }
                else
                {
                    Console.WriteLine("Ответ может быть только вещественным числом.");
                }
            }
        }

        static void Main()
        {
            Event1 myEvent = new Event1();
            Summ summ = new Summ();
            Diff minus = new Diff();
            Mult multi = new Mult();
            Division division = new Division();

            x = Convert.ToDouble(Console.ReadLine());
            y = Convert.ToDouble(Console.ReadLine());

            myEvent.SomeEvent += summ.Summer;
            myEvent.SomeEvent += minus.Differ;
            myEvent.SomeEvent += multi.Multiplyer;
            myEvent.SomeEvent += division.Divider;

            myEvent.OnEvent();
        }
    }
}

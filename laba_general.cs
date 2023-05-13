using System;
using System.Collections.Generic;

namespace AMOGUS
{
    public class GenericArray<T>
    {
        private List<T> massive;

        public GenericArray()
        {
            massive = new List<T>();
        }

        public void Adding(T el)
        {
            massive.Add(el);
        }

        public void Removing(T el)
        {
            massive.Remove(el);
        }

        public void Get(T el)
        {
            Console.WriteLine(massive.Contains(el));
        }

        public void Exit()
        {
            foreach (T el in massive)
            {
                Console.WriteLine(el);
            }
        }
    }
    internal class Program
    {
        static void Main()
        {
            GenericArray<int> intArray = new GenericArray<int>();
            GenericArray<string> strArray = new GenericArray<string>();
            intArray.Adding(1);
            intArray.Adding(2);
            intArray.Removing(2);
            intArray.Get(1);
            strArray.Adding("yes");
            strArray.Adding("no");
            strArray.Removing("no");
            strArray.Get("yes");
            intArray.Exit();
            strArray.Exit();
        }
    }
}

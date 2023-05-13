using System;
using System.Linq;

namespace AMOGUS
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите числа через пробел:");
            string[] numsS = Console.ReadLine().Split();
            int[] nums = new int[numsS.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(numsS[i]);
            }

            int count = 0;

            var negs = from p in nums
                          where p < 0
                          select p;
            foreach (int i in negs)
            {
                count++;
            }
            Console.WriteLine(count);
            count = 0;

            var positives = from p in nums
                          where p > 0
                          select p;
            foreach (int i in positives)
            {
                count += i;
            }
            Console.WriteLine(count);
            count = 1;

            var answer3 = from p in nums
                          where p % 2 == 0
                          select p;
            foreach (int i in positives)
            {
                count *= i;
            }
            Console.WriteLine(count);
        }
    }
}

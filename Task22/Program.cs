using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task22
{
    class Program
    {
        static void CalcSum(object numbers1)
        {
            int[] numbers=(int[])numbers1;
            int S = 0;
            foreach (int n in numbers)
            {
                
                S += n;
            }
            Console.WriteLine("\nСумма чисел={0}",S);
        }
        static void CalcMax(Task task, object numbers1)
        {
            int[] numbers = (int[])numbers1;
            int Max = 0;

            foreach (int n in numbers)
            {
                
                if (n > Max)
                    Max = n;
            }
            Console.WriteLine("Максимальное число в массиве={0}", Max);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задайте размерность массива");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 56);
                Console.Write("{0} ", array[i]);
            }
            Action action = new Action(()=>CalcSum(array));
            Task task1 = new Task(action);
            Action<Task, object> actionTask = new Action<Task, object>(CalcMax);
            Task task2 = task1.ContinueWith(actionTask, array);
            task1.Start();
            Console.ReadKey();


        }
    }
}

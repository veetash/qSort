using System;
using System.Linq;

namespace qSort
{
    public class Program
    {
        public static void Main()
        {
            ezElement();
            manyElements();
            thousand();
            emptiness();
           // crazy();
        }

        public static void genMassive(int[] array)
        {
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(0, 18);
            return;
        }

        public static void qSort(int[] array, int first, int last)
        {
            if ((last == first) | (array.Length == 0))
                return;
            var core = array[last];
            var i = first + 1;
            for (int j = first; j <= last - 1; j++)
                if (array[j] <= core)
                {
                    var t1 = array[i];
                    array[i] = array[j];
                    array[j] = t1;
                    i++;
                }

            var t2 = array[i];
            array[i] = array[last];
            array[last] = t2;
            if (i > first) qSort(array, first, i - 1);
            if (i < last) qSort(array, i + 1, last);
        }

        public static void qSort(int[] array)
        {
            qSort(array, 0, array.Length - 1);
        }

        public static void ezElement()
        {
            int[] array = new int[3];
            genMassive(array);
            qSort(array);
            var error = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i + 1] < array[i]) error++;
            }
            Console.Write("Сортировка массива из 3 элементов: ");
            if (error > 0)
                Console.WriteLine("Тест не пройден.");
            else
                Console.WriteLine("Тест выполнен успешно.");
        }

        public static void manyElements()
        {
            int[] array1 = new int[100];
            int[] array2 = new int[100];
            for (int i = 0; i < array1.Length; i++)
                array1[i] = 10;
            array2 = array1;
            qSort(array2);
            Console.Write("Сортировка массива из 100 одинаковых чисел: ");
            if (!array2.SequenceEqual(array1))
                Console.WriteLine("Тест не пройден.");
            else
                Console.WriteLine("Тест выполнен успешно.");
        }

        
          // Сортировка массива из 1000 случайных элементов;
          // Проверить что 10 случайных пар элементов массива после сортировки упорядочены.
        
        public static void thousand()
        {
            int[] array = new int[1000];
            genMassive(array);
            qSort(array);
            var rnd = new Random();
            int error = 0;
            for (int i = 0; i < 10; i++)
            {
                int j = rnd.Next(array.Length);
                int k = rnd.Next(array.Length);
                int a = array[j];
                int b = array[k];
                if (j == k)
                    i--;
                else if (j > k)
                {
                    if (a < b) error++;
                }
                else if (j < k)
                {
                    if (a > b) error++;
                }
            }
            Console.Write("Сортировка массива из 1000 случайных элементов: ");
            if (error > 0)
                Console.WriteLine("Тест не пройден.");
            else
                Console.WriteLine("Тест выполнен успешно.");
        }

        public static void emptiness() //Сортировка пустого массива 
        {
            int[] array = new int[0];
            genMassive(array);
            qSort(array);
            Console.Write("Сортировка пустого массива: ");
            if (array.Length == 0)
                Console.WriteLine("Тест пройден успешно.");
            else
                Console.WriteLine("Тест не пройден."); 
        }

     /* public static void crazy()
        {
                int[] array = new int[1500000000];
                genMassive(array);
                qSort(array); 
                int error = 0;
                for (int i = 0; i < array.Length - 1; i++)
                    if (array[i + 1] < array[i]) error++;
                Console.Write("Сортировка массива из 1.500.000.000 элементов: ");
                if (error == 0)
                    Console.WriteLine("Тест не пройден.");
                else
                    Console.WriteLine("Тест пройден успешно.");
        }*/
    }
}

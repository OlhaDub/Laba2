using System;
using System.Linq;
using System.Collections.Generic;

namespace Practic_2._2
{
    class Program
    {
        static void Block1()
        {
            int[] array = Fill_1_vimir();
            int[] result = new int[(array.Length + 1) / 2];
            for (int i = 0; i < array.Length; i+=2)
            {
                result[i/2] = array[i];
            }
            Console.WriteLine("Результат:");
            foreach (int i in result)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");
        }
        static void Block2()
        {
            int[][] mas = Fill_2();
            bool[] nulovi = new bool[mas.Length];
            int zalishok = mas.Length;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    if(mas[i][j]==0)
                    {
                        nulovi[i] = true;
                        zalishok--;
                        break;
                    }
                }
            }
            int[][] resmas = new int[zalishok][];
            for (int i = mas.Length-1; i >= 0; i--)
            {
                if(!nulovi[i])
                {
                    resmas[zalishok-1] = mas[i];
                    zalishok--;
                }
            }
            Console.WriteLine("Результат:");
            Printer(resmas);
            Console.WriteLine();
        }
        static void Block2_Res()
        {
            int[][] mas = Fill_2();
            for (int i = 0; i < mas.Length; i++)
            {
                bool nulovi = false;
                for (int j = 0; j < mas[i].Length; j++)
                {
                    if (mas[i][j] == 0)
                    {
                        nulovi = true;
                        break;
                    }
                }
                if(nulovi)
                {
                    for (int k = i; k < mas.Length-1; k++)
                    {
                        mas[k] = mas[k + 1];
                    }
                    Array.Resize(ref mas, mas.Length - 1);
                    i--;
                }
            }
            Console.WriteLine("Результат:");
            Printer(mas);
            Console.WriteLine();
        }
        static void Block3()
        {
            Console.WriteLine("Введiть рядок R:");
            string[] R = Console.ReadLine().Trim().Split();
            int rows = 0;
            
            int[] keys = new int[R.Length];
            for (int i = 0; i < R.Length; i++) //масив рядків
            {
                int n = int.Parse(R[i]);
                keys[rows] = n;
                rows++;
                i += n;
            }
            Array.Resize(ref keys, rows);
            int[][] resmas = new int[keys.Length][];

            int elems = 0;
            for (int i = 0; i < keys.Length; i++) //заповнення результуючого.
            {
                resmas[i] = new int[keys.Max()];
                elems++;
                for (int j = 0; j < keys[i]; j++)
                {
                    resmas[i][j] = int.Parse(R[elems]);
                    elems++;
                }
            }
            Console.WriteLine("Отримали масив:");
            Printer(resmas);
            Console.WriteLine("Результат:");
            MyReverseComparer k = new MyReverseComparer();
            Array.Sort(keys, resmas,k);
            Printer(resmas);
            Console.WriteLine();
        }
        public class MyReverseComparer : IComparer<int> //Sort(Array, Array, IComparer)
        {
            public int Compare(int x, int y)
            {
                // Compare y and x in reverse order.
                return y.CompareTo(x);
            }
        }
        static int[][] Fill_2()
        {
            int[][] array;
            int n;
            Random r = new Random();
     Agin:  Console.Write("Оберiть спосiб заповнення:\n1-Рандомно\t2-Вручну порядково\nВибiр:");
            int x = int.Parse(Console.ReadLine());
            switch (x)
            {
                case 1:
                    Console.Write("Введiть кiлькiсть рядкiв: ");
                    int p = int.Parse(Console.ReadLine());
                    array = new int [p][];
                    for (int i =0;i<p;i++)
                    {
                        Console.Write("Введiть довжину рядка {0}: ",i+1);
                        n = int.Parse(Console.ReadLine());
                        array[i] = new int [n];
                        for (int j = 0; j < n; j++)
                        {
                            array[i][j] = r.Next(-9, 10); 
                        }
                    }
                    break;
                case 2:
                    Console.Write("Введiть кiлькiсть рядкiв: ");
                    int y = int.Parse(Console.ReadLine());
                    array = new int[y][];
                    for (int i = 0; i < y; i++)
                    {
                        Console.Write("Введiть рядок {0}: ",i+1);
                        string[] rad = Console.ReadLine().Trim().Split();
                        array[i] = new int[rad.Length];
                        for (int j = 0; j < rad.Length; j++)
                        {
                            array[i][j] = int.Parse(rad[j]);
                        }
                    }
                    break;
                default: goto Agin;
            }
            Console.WriteLine("Отримали масив:");
            Printer(array);
            return array;
        }
        static void Printer(int[][]aray)
        {
            foreach (int[] i in aray)
            {
                foreach(int d in i)
                {
                    if (d < 0)
                    {
                        Console.Write(d + " ");
                    }
                    else
                    {
                        Console.Write(" "+d+ " ");
                    }
                }
                Console.WriteLine();
            }
        }
        static int[] Fill_1_vimir()
        {
            int[] array;
            Random r = new Random();
      Agi:  Console.Write("Як заповнити?\n1-Вручну\t2-Рандомно\nВибiр: ");
            int s = int.Parse(Console.ReadLine());
            switch (s)
            {
                case 1:
                    Console.Write("Будь ласка вводьте: ");
                    string[] pre = Console.ReadLine().Trim().Split();
                    array = new int[pre.Length];
                    for (int i = 0; i < pre.Length; i++)
                    {
                        array[i] = int.Parse(pre[i]);
                    }
                    break;
                case 2:
                    Console.Write("Оберiть розмiр: ");
                    int k = int.Parse(Console.ReadLine());
                    array = new int[k];
                    for (int i = 0; i < k; i++)
                    {
                        array[i] = r.Next(-9, 10);
                    }
                    break;
                default:Console.WriteLine("Неправильний вибiр, спробуйте ще.\n");goto Agi;
            }
            Console.WriteLine("Заповнили масив:");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            return array;
        }
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Write("Виберiть блок завдань: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: Block1(); break;
                    case 2: Block2(); break;
                    case 3: Block3(); break;
                    case 0: Console.WriteLine("Завершуємо...");break;
                    default: Console.WriteLine("Неправильний номер.\n"); break;
                }
            } while (choice != 0);
        }
    }
}

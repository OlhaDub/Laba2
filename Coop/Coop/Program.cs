using System;

namespace Coop
{
    class Program
    {
        static int[] Fill_1_vimir()
        {
            int[] array;
            Random r = new Random();
        Agi: Console.Write("Оберiть спосiб заповнення:\n1-Рандомно\t2-Вручну в рядoк\nВибiр: ");
            int s = int.Parse(Console.ReadLine());
            switch (s)
            {
                case 2:
                    Console.Write("Будь ласка вводьте: ");
                    string[] pre = Console.ReadLine().Trim().Split();
                    array = new int[pre.Length];
                    for (int i = 0; i < pre.Length; i++)
                    {
                        array[i] = int.Parse(pre[i]);
                    }
                    break;
                case 1:
                    Console.Write("Оберiть розмiр: ");
                    int k = int.Parse(Console.ReadLine());
                    array = new int[k];
                    for (int i = 0; i < k; i++)
                    {
                        array[i] = r.Next(-9, 10);
                    }
                    break;
                default: Console.WriteLine("Неправильний вибiр, спробуйте ще.\n"); goto Agi;
            }
            Console.WriteLine("Заповнили масив:");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            return array;
        }
        static int[][] Fill_2()
        {
            int[][] array;
            int n;
            Random r = new Random();
        Agin: Console.Write("Оберiть спосiб заповнення:\n1-Рандомно\t2-Вручну порядково\nВибiр:");
            int x = int.Parse(Console.ReadLine());
            switch (x)
            {
                case 1:
                    Console.Write("Введiть кiлькiсть рядкiв: ");
                    int p = int.Parse(Console.ReadLine());
                    array = new int[p][];
                    for (int i = 0; i < p; i++)
                    {
                        Console.Write("Введiть довжину рядка {0}: ", i + 1);
                        n = int.Parse(Console.ReadLine());
                        array[i] = new int[n];
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
                        Console.Write("Введiть рядок {0}: ", i + 1);
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
        static void Block1Olya(int[] array)
        {
            int[] result = new int[(array.Length + 1) / 2];
            for (int i = 0; i < array.Length; i += 2)
            {
                result[i / 2] = array[i];
            }
            Console.WriteLine("Результат:");
            foreach (int i in result)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void Blok1Illya(int[] array)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    counter++;
                }
            }
            int[] NewArray = new int[array.Length + counter];
            int CounterForArray = 0;
            for (int i = 0; i < NewArray.Length; i++)
            {
                if (array[CounterForArray] % 2 != 0)
                {
                    NewArray[i] = array[CounterForArray];
                    CounterForArray++;
                }
                else
                {
                    NewArray[i] = array[CounterForArray];
                    NewArray[i + 1] = 0;
                    CounterForArray++;
                    i++;
                }
            }
            Console.WriteLine("Вiдповiдь:");
            foreach (int i in NewArray)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void Block2Olya(int[][] mas)
        {
            bool[] nulovi = new bool[mas.Length];
            int zalishok = mas.Length;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    if (mas[i][j] == 0)
                    {
                        nulovi[i] = true;
                        zalishok--;
                        break;
                    }
                }
            }
            int[][] resmas = new int[zalishok][];
            for (int i = mas.Length - 1; i >= 0; i--)
            {
                if (!nulovi[i])
                {
                    resmas[zalishok - 1] = mas[i];
                    zalishok--;
                }
            }
            Console.WriteLine("Результат:");
            Printer(resmas);
            Console.WriteLine();
        }
        static void Blok2Illya(int[][] Array2d)
        {
            //Завдання
            Console.WriteLine("Додати рядок перед рядком, що містить найменший елемент (якщо у різних місцях є кілька елементів з " +
                              "\n однаковим мінімальним значенням, то брати перший з них)");

            //Пошук мінімуму
            int[] Min = new int[3];
            Min[0] = Array2d[0][0];
            Min[1] = 0;
            Min[2] = 0;
            for (int i = 0; i < Array2d.Length; i++)
            {
                for (int j = 0; j < Array2d[i].Length; j++)
                {
                    if (Array2d[i][j] < Min[0])
                    {
                        Min[0] = Array2d[i][j];
                        Min[1] = i;
                        Min[2] = j;
                    }
                }
            }

            //Виконання завдання
            int[][] ArrayV2 = new int[Array2d.Length + 1][];

            int counter = 0;
            for (int i = 0; i < Min[1]; i++)
            {
                ArrayV2[i] = new int[Array2d[i].Length];
                for (int j = 0; j < Array2d[i].Length; j++)
                {
                    ArrayV2[i][j] = Array2d[i][j];
                }
                counter++;
            }

            ArrayV2[counter] = new int[] { 0, 0, 0 };
            for (int i = counter + 1; i < Array2d.Length + 1; i++)
            {
                ArrayV2[i] = new int[Array2d[i - 1].Length];
                for (int j = 0; j < Array2d[i - 1].Length; j++)
                {
                    ArrayV2[i][j] = Array2d[i - 1][j];
                }
            }

            //Вивід масиву
            for (int i = 0; i < Array2d.Length + 1; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < ArrayV2[i].Length; j++)
                {
                    Console.Write(ArrayV2[i][j] + " ");
                }
            }
            Console.WriteLine();
        }
        static void Printer(int[][] aray)
        {
            foreach (int[] i in aray)
            {
                foreach (int d in i)
                {
                    if (d < 0)
                    {
                        Console.Write(d + " ");
                    }
                    else
                    {
                        Console.Write(" " + d + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void VictimOne(int[] arrayOne)
        {
            int who;
            int[] array = new int[arrayOne.Length];
            do
            {
                Console.Write("\nВиберiть студента:\n1-Оля\t2-Iлля\nВибiр:");
                who = int.Parse(Console.ReadLine());
                switch (who)
                {
                    case 1:
                        {
                            arrayOne.CopyTo(array, 0);
                            Block1Olya(array);
                            break;
                        }
                    case 2:
                        {
                            arrayOne.CopyTo(array, 0);
                            Blok1Illya(array);
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Повертаємось до вибору блоку\n");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введено неправильне число");
                            break;
                        }
                }
            } while (who != 0);
        }
        static void VictimTwo(int[][] arrayTwo)
        {
            int pers;
            int[][] array = new int[arrayTwo.Length][];
            do
            {
                Console.Write("\nВиберiть студента:\n1-Оля\t2-Iлля\nВибiр:");
                pers = int.Parse(Console.ReadLine());
                switch (pers)
                {
                    case 1:
                        {
                            for (int i = 0; i < array.Length; i++)
                            {
                                array[i] = new int[arrayTwo[i].Length];
                                arrayTwo[i].CopyTo(array[i], 0);
                            }
                            Block2Olya(array);
                            break;
                        }
                    case 2:
                        {
                            for (int i = 0; i < array.Length; i++)
                            {
                                array[i] = new int[arrayTwo[i].Length];
                                arrayTwo[i].CopyTo(array[i], 0);
                            }
                            Blok2Illya(array);
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Повертаємось до вибору блоку\n");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введено неправильне число");
                            break;
                        }
                }
            } while (pers != 0);
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
                    case 1:
                          VictimOne(Fill_1_vimir());
                        break;
                    case 2:
                        VictimTwo(Fill_2());
                        break;
                    case 0: Console.WriteLine("Завершуємо..."); break;
                    default: Console.WriteLine("Неправильний номер.\n"); break;
                }
            } while (choice != 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP6
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1, a2, a3, n, e;
            a1 = CheckInt("Введите первый элемент последовательности");
            a2 = CheckInt("Введите второй элемент последовательности");
            a3 = CheckInt("Введите третий элемент последовательности");
            n = CheckInt("Введите количество искомых элементов");
            e = CheckInt("Введите число, которое должно быть меньше разности искомых элементов с предыдущими");
            CheckE(e, a1, a2, a3, n);
        }

        public static int CheckInt(string s)
        {
            Console.WriteLine(s);
            bool ok;
            int n;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Ошибка ввода. Попробуйте снова");
            } while (!ok);
            return n;
        }
        public static int GetNext(int a1, int a2, int a3)
        {
            int res = a3 + 2 * a2 * a1;
            return res;
        }
        public static void CheckE(int e, int a1, int a2, int a3, int n)
        {
            int[] array = new int[4];
            array[0] = a1;
            array[1] = a2;
            array[2] = a3;
            array[3] = GetNext(a1, a2, a3);
            if ((Math.Abs(array[3] - array[2]) > e) && (n == 1))
            {
                Print(array, e);
            }
            else
            {
                if (Math.Abs(array[array.Length - 1] - array[array.Length - 2]) > e)
                {
                    n--;
                }
                do
                {
                    int[] newArray = new int[array.Length + 1];
                    array.CopyTo(newArray, 0);
                    array = new int[newArray.Length];
                    newArray.CopyTo(array, 0);
                    array[array.Length - 1] = GetNext(array[array.Length - 4], array[array.Length - 3], array[array.Length - 2]);
                    if (Math.Abs(array[array.Length-1] - array[array.Length -2]) > e)
                    {
                        n--;
                    }
                } while (n != 0);
                Print(array, e);
            }
        }
        public static void Print(int[] array, int e)
        {
            Console.WriteLine("Последовательность: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Искомые элементы: ");
            for (int i = 1; i < array.Length; i++)
            {
                if (Math.Abs(array[i] - array[i-1]) > e)
                {
                    Console.Write(array[i] + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Номера искомых элементов: ");
            for (int i = 1; i < array.Length; i++)
            {
                if (Math.Abs(array[i] - array[i - 1]) > e)
                {
                    Console.Write((i+1) + " ");
                }
            }
            Console.WriteLine();
        }
    }
}

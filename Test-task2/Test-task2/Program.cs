using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test_task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m, n, count = 1, count2;
            bool is_first;

            // Считываем n
            Console.Write("Введите число n: ");
            m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            // Рассчитываем количество столбцов в матрице
            n = (m - 1) * ((m - 1) + 1) / 2;

            // Создаём матрицу
            int[,] matrix = new int[m+1, n+1];

            // Заполняем матрицу нулями
            for (int i = 1; i <= m; i++)
                for (int j = 1; j <= n; j++)
                    matrix[i, j] = 0;

            // Подставляем в матрицу единички
            for (int i = 1; i <= m; i++)
            {
                is_first = true;
                for (int j = 1; j <= n; j++)
                {
                    if (j <= m - i)
                    {
                        matrix[i, count] = 1;
                        if(is_first)
                        {
                            matrix[i + 1, count] = 1;
                            count2 = count;
                            for (int k = i + 1; k < m; k++)
                            {
                                matrix[k + 1, count2 + 1] = 1;
                                count2++;
                            }
                            is_first = false;
                        }      
                        count++;
                    }
                    Console.Write(matrix[i, j] + "\t");
                } 
                Console.WriteLine();
            }
            Console.ReadLine() ;
        }
    }
}

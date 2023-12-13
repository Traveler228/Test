using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Test_task1
{
    class Program
    {
        class Point
        {
            //Три точки на одной прямой
            public void PointsOnLine(double x1, double y1, double x2, double y2, double x3, double y3)
            {
                if((x3 - x1) * (y2 - y1) == (y3 - y1) * (x2 - x1))
                {
                    Console.WriteLine("Точки лежат на одной прямой");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Точки не лежат на одной прямой");
                    Console.ReadLine();
                }
            }

            // Повернуть точку вокруг другой точки
            public void RotationByAngle(double x1, double y1, double x2, double y2, int angle)
            {
                double cos = Math.Cos((Math.PI / 180) * angle);
                double sin = Math.Sin((Math.PI / 180) * angle);
                double xn = (x2 - x1) * cos + (y2 - y1) * sin + x1;
                double yn = (y2 - y1) * cos - (x2 - x1) * sin + y1;

                Console.WriteLine($"Новые координаты точки после поворота ({Math.Round(xn, 4)},{Math.Round(yn, 4)})");
                Console.ReadLine();

            }
        }

        class Vector
        {
            // Сдвиг точки по вектору
            public void MovePointAlongVector(double xp, double yp, double xs, double ys, double xe, double ye)
            {
                double x = xe - xs;
                double y = ye - ys;
                double length = Math.Abs(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
                double angle = Math.Acos((x * 0 + y * 1) / (length * 1));
                double xn = xp + length * Math.Cos(angle);
                double yn = yp + length * Math.Sin(angle);
                Console.WriteLine($"Координаты точки после перемещения ({xn}, {yn})");
                Console.ReadLine();
            }

            // Определение перпендикулярности
            public void PerpendicularVectors(double x1s, double y1s, double x1e, double y1e, double x2s, double y2s, double x2e, double y2e)
            {
                double x1 = x1e - x1s;
                double y1 = y1e - y1s;
                double x2 = x2e - x2s;
                double y2 = y2e - y2s;
                if(x1 * x2 + y1 * y2 == 0)
                {
                    Console.WriteLine("Векторы перпендикулярны");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Векторы не перпендикулярны");
                    Console.ReadLine();
                }
            }

            // Определение угла между векторами
            public void AngleBetweenVector(double x1s, double y1s, double x1e, double y1e, double x2s, double y2s, double x2e, double y2e)
            {
                double x1 = x1e - x1s;
                double y1 = y1e - y1s;
                double x2 = x2e - x2s;
                double y2 = y2e - y2s;

                double length1 = Math.Abs(Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2)));
                double length2 = Math.Abs(Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2)));

                double angle = Math.Acos((x1 * x2 + y1 * y2) / (length1 * length2)) * 180 / Math.PI;

                Console.WriteLine($"Угол между векторами равен {Math.Round(angle, 4)}°");
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            int action;
            int angle;
            double[] x = new double[4];
            double[] y = new double[4];

            Console.WriteLine("1. Определить находятся ли три точки на одной прямой");
            Console.WriteLine("2. Сдвинуть точку по вектору");
            Console.WriteLine("3. Повернуть точку вокруг другой точки на указанный угол в градусах");
            Console.WriteLine("4. Определение перпендикулярности двух векторов");
            Console.WriteLine("5. Определить угол между векторами");
            Console.WriteLine("6. Выход \n");
            Console.Write("Выберите действие: ");
            action = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                // Три точки на одной прямой
                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write($"Введите координату x точки {i + 1}: ");
                        x[i] = Convert.ToDouble(Console.ReadLine());

                        Console.Write($"Введите координату y точки {i + 1}: ");
                        y[i] = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();
                    }

                    Point OnLine = new Point();
                    OnLine.PointsOnLine(x[0], y[0], x[1], y[1], x[2], y[2]);
                    break;

                // Сдвиг точки по вектору
                case 2:
                    for (int i = 0; i < 2; i++)
                    {
                        Console.Write($"Введите координату x{i + 1} для вектора: ");
                        x[i] = Convert.ToDouble(Console.ReadLine());

                        Console.Write($"Введите координату y{i + 1} для вектора: ");
                        y[i] = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();
                    }

                    Console.WriteLine($"Введите координаты точки которую необходимо сдвинуть ");
                    Console.Write("Введите точку x: ");
                    x[2] = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите точку y: ");
                    y[2] = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();

                    Vector Move = new Vector();
                    Move.MovePointAlongVector(x[2], y[2], x[0], y[0], x[1], y[1]);

                    break;

                // Повернуть точку вокруг другой точки
                case 3:
                    for (int i = 0; i < 2; i++)
                    {
                        Console.Write($"Введите координату x точки {i + 1}: ");
                        x[i] = Convert.ToDouble(Console.ReadLine());

                        Console.Write($"Введите координату y точки {i + 1}: ");
                        y[i] = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();
                    }
                    Console.Write("Введите угол поворота в градусах: ");
                    angle = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    Point Rotation = new Point();
                    Rotation.RotationByAngle(x[0], y[0], x[1], y[1], angle);
                    break;

                // Определение перпендикулярности
                case 4:
                    for (int i = 0; i < 2; i++)
                    {
                        Console.Write($"Введите координату x{i + 1} для вектора 1: ");
                        x[i] = Convert.ToDouble(Console.ReadLine());

                        Console.Write($"Введите координату y{i + 1} для вектора 1: ");
                        y[i] = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();
                    }

                    for (int i = 2; i < 4; i++)
                    {
                        Console.Write($"Введите координату x{i - 2} для вектора 2: ");
                        x[i] = Convert.ToDouble(Console.ReadLine());

                        Console.Write($"Введите координату y{i - 2} для вектора 2: ");
                        y[i] = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();
                    }
                    Vector Perpendicular = new Vector();
                    Perpendicular.PerpendicularVectors(x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3]);
                    break;

                // Определение угла между векторами
                case 5:
                    for (int i = 0; i < 2; i++)
                    {
                        Console.Write($"Введите координату x{i + 1} для вектора 1: ");
                        x[i] = Convert.ToDouble(Console.ReadLine());

                        Console.Write($"Введите координату y{i + 1} для вектора 1: ");
                        y[i] = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();
                    }

                    for (int i = 2; i < 4; i++)
                    {
                        Console.Write($"Введите координату x{i - 2} для вектора 2: ");
                        x[i] = Convert.ToDouble(Console.ReadLine());

                        Console.Write($"Введите координату y{i - 2} для вектора 2: ");
                        y[i] = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();
                    }

                    Vector Angle = new Vector();
                    Angle.AngleBetweenVector(x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3]);
                    break;

                // Выход
                case 6:
                    Environment.Exit(0);
                    break;

                // Перезапуск при неизвестном действии
                default:
                    Console.WriteLine("Неизвестное действие, повторите попытку");
                    Console.WriteLine("Нажмите любую клавишу что бы продолжить...");
                    Console.ReadLine();
                    Process.Start(Assembly.GetExecutingAssembly().Location);
                    break;

            }
            
        }
    }
}

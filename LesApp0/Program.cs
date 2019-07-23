using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main(string[] args)
        {
            // Підключення української мови
            Console.OutputEncoding = Encoding.Unicode;

            // ідентифікатори для чисел
            double a, b;

            // введеня чисел
            Console.WriteLine("Задайте два числа:\n");

            Console.Write("Введіть 1-е чсило: a = ");
            a = ConvNumb();

            Console.Write("Введіть 2-е чсило: b = ");
            b = ConvNumb();

            {
                // тимчасовий індентифікатор 
                double temp = default;

                // розрахунок і виведення результатів

                // 1-ше число в степені 2-го числа
                temp = Math.Pow(a, b);
                Console.WriteLine($"\n\ta^b = {temp:N}");

                // 2-ге число в степені 1-го числа
                temp = Math.Pow(b, a);
                Console.WriteLine($"\tb^a = {temp:N}");

                // корінь степені 2-го числа від 1-го числа
                temp = Math.Pow(a, 1 / b);
                Console.WriteLine($"\tb√a = {temp:N}");

                // корінь степені 1-го числа від 2-го числа
                temp = Math.Pow(b, 1 / a);
                Console.WriteLine($"\ta√b = {temp:N}\n");
            }

            // Delay
            Console.ReadKey();
        }

        /// <summary>
        /// Прийом на вхід введених даних і виведення числа з подвійною точністю
        /// </summary>
        /// <returns></returns>
        static double ConvNumb()
        {
            // строковий індентифікатор
            string temp = Console.ReadLine().Replace(".", ",");

            // конвертація в double, (адекватне використання тернарного оператора :) )
            double res = Convert.ToDouble((temp == "") ? "0" : temp);

            // повернення значення
            return res;
        }
    }
}

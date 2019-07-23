using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Program
    {
        /// <summary>
        /// Перерахунок позначень уявної комплексної одиниці
        /// </summary>
        enum ComplexIndef
        {
            /// <summary>
            /// запис в математиці
            /// </summary>
            i,
            /// <summary>
            /// запис в фізиці
            /// </summary>
            j
        }

        static void Main(string[] args)
        {
            // Підключення української мови
            Console.OutputEncoding = Encoding.Unicode;

            // ідентифікатори для чисел, коефіцієнти квадратного рівняння
            double a, b, c;

            // комплексні корені рівняння, https://docs.microsoft.com/ru-ru/dotnet/api/system.numerics.complex?view=netframework-4.8
            Complex x1 = new Complex(),
                x2 = new Complex();

            #region Введеня чисел
            Console.WriteLine("Задайте параметри квадратного рівняння виду:\n" +
                "(допускаються дійсні числа)\n\n" +
                "\ta * x^2 + b * x + c = 0\n");

            Console.Write("Введіть 1-е число: ");
            a = ConvNumb();

            Console.Write("Введіть 2-е число: ");
            b = ConvNumb();

            Console.Write("Введіть 3-е число: ");
            c = ConvNumb();
            #endregion

            #region Обережно!!! Може піти кров з очей, а автора ймовірніше всього проклянуть :)
            // Оскільки проходили тему по тернарному оператору, то знизу представлений варіант його використання
            // рекомендується просто перевірити вивід на консоль і не мучатись з кодом)))
            // даний приклад є "експерементальним", а автор обіцяє більше таких конструкій не використовувати :)

            // Вивід рівняння, дужки для кращого сприйняття 
            string s1, s2, s3, s4;

            s1 = $"{((a == 0) ? ("") : ($"{((Math.Abs(a) == 1) ? ($"{((a == 1) ? ("") : ("-"))}") : ($"{a}"))}x^2 "))}";
            s2 = $"{((b == 0) ? ("") : ($"{((s1 == "") ? ($"{((Math.Abs(b) == 1) ? ($"{((b == 1) ? ("") : ("-"))}") : ($"{b}"))}") : ($"{((b < 0) ? ("-") : ("+"))}{((s1 == "") ? ("") : (" "))}{((Math.Abs(b) == 1) ? ("") : ($"{Math.Abs(b)}"))}"))}x "))}";
            s3 = $"{((c == 0) ? ("") : ($"{(((s1 + s2) == "") ? ($"{c}") : ($"{((c < 0) ? ("-") : ("+"))} {Math.Abs(c)}"))} "))}";
            s4 = $"{(((s1 + s2 + s3) == "") ? ("0 = ") : ($"{(((s1 + s2) == "") ? ($"≠ ") : ($"= "))}"))}0";

            // вивід результату
            Console.WriteLine("\nЗадане рівняння: \n\n\t" + s1 + s2 + s3 + s4);
            #endregion

            #region Рохрахунок корнів квадратного рівняння
            // Дискримінант
            double D = b * b - 4 * a * c;

            if ((s1 == "") || (D == 0))     // один або два однакових корені, паработа вершиною дотикається до осі абсцис Ox, або це лінійне рівняння
            {
                if (s1 != "")
                {
                    x1 = x2 = -b / (2 * a);
                }
                else // b*x + c = 0
                {
                    x1 = x2 = -c / b;
                }
            }
            else if (D > 0) // два дійсні корені, вітки параболи направлені вгору
            {
                x1 = (-b - Math.Sqrt(D)) / (2 * a);
                x2 = (-b + Math.Sqrt(D)) / (2 * a);
            }
            else // D < 0   // два комплексні корені, вітки параболи направлені вниз
            {
                x1 = (-b - Complex.Sqrt(D)) / (2 * a);
                x2 = (-b + Complex.Sqrt(D)) / (2 * a);
            }
            #endregion

            #region Вивід результатів
            Console.WriteLine("\nКорені квадратного рівняння:\n");

            if ((s1 + s2 + s3) == "")   // 0 = 0
            {
                Console.WriteLine("\tКоренів безліч, тобто вся область значення!");  //область визначення вісь Oy
            }
            else if ((s1 + s2) == "" && s3 != "")
            {
                Console.WriteLine("\tКоренів не існує, маємо нерівність!");
            }
            else if ((s1 == "") || (D == 0))
            {
                if (s1 != "")
                {
                    Console.WriteLine("Корні одинакові:");
                    Console.WriteLine($"\tx1 = x2 = {ComplexToString(x1)}\n");
                }
                else // b*x + c = 0
                {
                    Console.WriteLine("Корінь один:");
                    Console.WriteLine($"\tx = {ComplexToString(x1)}\n");
                }
            }
            else if (D > 0)
            {
                Console.WriteLine($"Два дійсні корені:\n");
                Console.WriteLine($"\tx1 = {ComplexToString(x1)}");
                Console.WriteLine($"\tx2 = {ComplexToString(x2)}\n");
            }
            else // (D < 0)
            {
                Console.WriteLine($"Два комплексні корені:\n");
                Console.WriteLine($"\tx1 = {ComplexToString(x1)}");;
                Console.WriteLine($"\tx2 = {ComplexToString(x2)}\n");
            }
            #endregion

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

        /// <summary>
        /// Функція яка дозволяє вивести комплексне число з певним форматуванням
        /// </summary>
        /// <param name="comp">Комплексний індентифікатор</param>
        /// <param name="form">Формат виведення значень</param>
        /// <param name="ind">вигляд уявної одиниці, де зазвичай "i" - запис в математиці, а "j" - запис в фізиці</param>
        /// <returns></returns>
        static string ComplexToString(Complex comp, string form, ComplexIndef ind)
        {
            // строкові індентифікатори
            string real, image, sign, res, one;

            // запис уявної одиниці
            switch (ind)
            {
                case ComplexIndef.i:
                    goto default;
                case ComplexIndef.j:
                    one = "j";
                    break;
                default:
                    one = "i";
                    break;
            }


            // дійсна частина
            real = $"{((comp.Real == 0) ? ("") : (comp.Real.ToString(form)))}";
            // уявна частина
            image = $"{((comp.Imaginary == 0) ? ("") : (Math.Abs(comp.Imaginary).ToString(form) + one))}";

            // вимушений використати таку форму запису через тернарний оператор, але далі точно так більше не буду :)
            // знак між дійсною і уявною частинами
            sign = $"{((image == "") ? ("") : ($"{((real == "") ? ($"{((comp.Imaginary > 0) ? ("") : ("-"))}") : ($" {((comp.Imaginary > 0) ? ("+") : ("-"))} "))}"))}";

            // Результат форматування
            res = $"{(((real + image) == "") ? (comp.Real.ToString(form)) : (real + sign + image))}";

            // повернення значення
            return res;
        }

        /// <summary>
        /// Перегрузка метода ComplexToString, де уявна одиниця позначається "i"
        /// </summary>
        /// <param name="comp">Комплексний індентифікатор</param>
        /// <param name="form">Формат виведення значень</param>
        /// <returns></returns>
        static string ComplexToString(Complex comp, string form)
        {
            return ComplexToString(comp, form, ComplexIndef.i);
        }

        /// <summary>
        /// Перегрузка метода ComplexToString, де формат выдображення "N"
        /// </summary>
        /// <param name="comp">Комплексний індентифікатор</param>
        /// <returns></returns>
        static string ComplexToString(Complex comp)
        {
            return ComplexToString(comp, "N");
        }
    }
}

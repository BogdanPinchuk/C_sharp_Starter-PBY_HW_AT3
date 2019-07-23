using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Підключення української мови
            Console.OutputEncoding = Encoding.Unicode;

            // Примітка. Так як відсутні пояснення до 3-го завдання із фото формул на дошці
            // то ми можеом самі задавати значення змінних у формулах

            // створення випадкових змінних в відповідному діапазоні
            Random rnd = new Random();

            // локальна функція визначення рандомного числа
            double RD()
            {
                return rnd.NextDouble();
            }

            // Індентифікатори для формул 
            double N = RD(),
                a = RD(),
                c = RD(),
                Pi = RD(),
                R = RD(),
                x = RD();

            // Виведення змінних
            Console.WriteLine("Випадкові змінні:");
            Console.WriteLine($"N = {N:N}");
            Console.WriteLine($"a = {a:N}");
            Console.WriteLine($"c = {c:N}");
            Console.WriteLine($"Pi = {Pi:N}");  // модиво це заданий ряд, але на виходы показано, що маэмо лише одне число
            Console.WriteLine($"R = {R:N}");
            Console.WriteLine($"x = {x:N}\n");

            // результат, що виводитиметься
            double m = default, // база
                m1 = default;   // оптимізована формула

            // локальна функція для відображення результату
            void Result(double M, double M1)
            {
                Console.WriteLine($"\tНеоптимізована формула: m = {M:N6}");
                Console.WriteLine($"\tОптимізована формула: m1 = {M1:N6}\n");
            }
            
            #region 1-ша формула
            // формула задана, але не оптимізована, можна провести математичні
            // спрощення і тоді формула олзраховуватиметсья швидше
            m = ((Math.Pow(Math.Sqrt(N + 1), 2) / 5) /
                (Math.Abs(a) % c)) - Math.Sqrt(a + c);

            m1 = (Math.Abs(N + 1) / (5 * (Math.Abs(a) % c)))
                - Math.Sqrt(a + c);

            // Виведення
            Console.WriteLine("1-ша формула:");
            Result(m, m1);
            #endregion

            #region 2-ша формула
            m = Math.Sin((Pi * R * R) / (1 / 4.0)) * 
                Math.Pow(Math.Cos(Math.Tan(2 / Math.Sqrt(3))), 2) / 3;

            m1 = Math.Sin(4 * Pi * R * R) *
                Math.Pow(Math.Cos(Math.Tan(2 / Math.Sqrt(3))), 2) / 3;

            // Виведення
            Console.WriteLine("2-га формула:");
            Result(m, m1);
            #endregion

            #region 3-тя формула
            m = x * x - 3 * x * x * x * 
                Math.Sqrt((1 / 2.0) * Math.Pow(x, 4));

            m1 = x * x - 3 * Math.Pow(x, 5) / Math.Sqrt(2);

            // Виведення
            Console.WriteLine("3-тя формула:");
            Result(m, m1);
            #endregion

            // Delay
            Console.ReadKey();
        }
    }
}

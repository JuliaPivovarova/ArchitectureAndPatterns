using System;

namespace Patt
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MathTasks mathTasks;

            int maxEven;
            int sum;
            int factorial;

            String s = "";

            while (s != "q" || s != "Q")
            {
                Console.Clear();
                Console.WriteLine("Здравствуйте, вас приветствует математическая программа.\nПожалуйста введите положительное число.\nДля выхода наберите q");
                s = Console.ReadLine();
                
                if (s == "q" || s == "Q"){
                    return;
                }   
                
                bool sToInt = Int32.TryParse(s, out int m);

                if (sToInt)
                {
                    if (m >= 0)
                    {
                        maxEven = mathTasks.MaxEven(m);
                        factorial = mathTasks.FactorialToN(m);
                        sum = mathTasks.Sum(m);
                    
                        Console.WriteLine($"Факториал равен - {factorial}\nСумма от 0 до {m} равна - {sum}\nМаксимальное чётное число меньше {m} равно - {maxEven}");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Факториал определён только для положительных чисел. Введите число ещё раз.");
                        Console.ReadLine();
                    }
                    
                }
                else
                {
                    Console.WriteLine("Нужно ввести число цифрами");
                    Console.ReadLine();
                }
            }

            
            
                 

            

            

        }
    }
}
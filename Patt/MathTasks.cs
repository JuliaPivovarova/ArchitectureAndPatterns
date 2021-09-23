using System;

namespace Patt
{
    public struct MathTasks
    {
        public int FactorialToN(int number)
        {
            if (number < 0)
            {
                throw new Exception("Факториал определён только для положительных чисел");
            }
            int factorial = 1;
            for (int i = 1; i < number + 1; i++)
            {
                factorial = factorial * i;
            }

            return factorial;
        }
        
        public int Sum(int number)
        {
            int sum = 0;
            bool nAboveZero;
            int numb;
            if (number < 0)
            {
                nAboveZero = false;
                numb = -number;
            }
            else
            {
                nAboveZero = true;
                numb = number;
            }
            
            for (int i = 0; i < numb + 1; i++)
            {
                sum += i;
            }

            if (!nAboveZero)
            {
                sum = -sum;
            }
            return sum;
        }
        
        public int MaxEven(int number)
        {
            int maxEvenNumber;
            if ((number - 1) % 2 == 0)
            {
                maxEvenNumber = number - 1;
            }
            else
            {
                maxEvenNumber = number - 2;
            }

            return maxEvenNumber;
        }
    }
}
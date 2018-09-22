using KnockKnockTest.Common;
using System;
using System.Linq;

namespace KnockKnockTest.Services
{
    public class CalculationsService : ICalculationsService
    {
        public long GetFibonacciNumber(long number)
        {
            try
            {
                if (number == 0)
                    return 0;

                long[] fibonacci = new long[number + 1];
                fibonacci[0] = 0;
                fibonacci[1] = 1;
                for (var i = 2; i <= number; i++)
                {
                    fibonacci[i] = fibonacci[i - 2] + fibonacci[i - 1];
                }
                return fibonacci[number];
            }
            catch (OverflowException)
            {
                throw;
            }
        }

        public string ReverseWords(string sentense)
        {
            var reversedWords = string.Empty;
            if (string.IsNullOrEmpty(sentense))
                return reversedWords;

            reversedWords = string.Join(" ", sentense.Split(' ')
                                .Select(x => new String(x.Reverse().ToArray())));
            return reversedWords;
        }

        public string TriangleType(int a, int b, int c)
        {
            var result = string.Empty;

            if (a <= 0 || b <= 0 || c <= 0)
            {
                return Constants.ERRORMESSAGE;
            }

            if (a == b && b == c)
            {
                result = Constants.EQUILATERALTRIANGLE;
            }
            else if (a == b || b == c || a == c)
            {
                result = Constants.ISOSCELESTRIANGLE;
            }
            else if (a != b && b != c)
            {
                result = Constants.SCALENETRIANGLE;
            }

            return result;
        }
    }
}
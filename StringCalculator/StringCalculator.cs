using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorNamespace
{
    public static class StringCalculator
    {

        public static int Add(string numbers)
        {
            if (numbers == "")
                return 0;
            List<string> delimeters = new List<string>();
            if (numbers[0] == '/' && numbers[1] == '/')
            {
                int firstNumberIndex = -1;
                if (numbers[2] == '[')
                {
                    var arr = numbers.Split(new char[] { ']', '/', '[' },StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        delimeters.Add(arr[i]);
                    }
                    firstNumberIndex = numbers.LastIndexOf(']') + 1;
                }
                else
                {
                    firstNumberIndex = 3;
                    delimeters.Add(numbers[2].ToString());
                }
                
                numbers = numbers.Substring(firstNumberIndex);    
            }
            else delimeters = new List<string>() { ",", "\n" };
            if (numbers.Contains('-'))
            {
                if (!delimeters.Contains("-") || numbers.Contains("--"))
                    throw new NegativeNumberException();
            }

            return numbers.Split(delimeters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Sum(c => int.Parse(c) > 1000 ? 0 : int.Parse(c));
        }
    }
    public class NegativeNumberException : Exception
    {

    }

}


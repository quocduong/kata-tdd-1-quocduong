using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKata
{
    public class Calculator
    {
        private const string DelimeterLineIndicator = "//";
        private static string _delimeter = ",";

        public static int Add(string numbers)
        {
            if (HasdelimeterLine(numbers))
            {
                ParseDelimeter(numbers);
                numbers = GetNumbers(numbers);
            }
            if (IsEmptyString(numbers))
                return HandleEmptyString();

            if (HasMultipleNumbers(numbers))
            {
                return HandleMultipleNumber(numbers);
            }

            return HandleOneNumber(numbers);
        }

        private static void ParseDelimeter(string numbers)
        {
            _delimeter = numbers.Substring(2, 1);
        }

        private static string GetNumbers(string numbers)
        {
            var numParts = numbers.Split(char.Parse("\n"));
            numbers = numParts[1];
            return numbers;
        }

        private static bool HasdelimeterLine(string numbers)
        {
            return numbers.StartsWith(DelimeterLineIndicator);
        }

        private static int HandleMultipleNumber(string numbers)
        {
            var nums = numbers.Split(_delimeter.ToCharArray());

            return nums.Sum(num => HandleOneNumber(num));
        }

        private static bool HasMultipleNumbers(string numbers)
        {
            return numbers.Contains(_delimeter);
        }

        private static int HandleOneNumber(string numbers)
        {
            return int.Parse(numbers);
        }

        public static int HandleEmptyString()
        {
            return 0;
        }

        public static bool IsEmptyString(string numbers)
        {
            return string.IsNullOrEmpty(numbers);
        }
    }
}

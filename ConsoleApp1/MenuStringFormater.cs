using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MenuStringFormater
    {
        public static List<string> InsertNormal(string text)
        {
            List<string> result = new List<string> { };
            string manipulatedText = text;
            while (manipulatedText.Length > 108)
            {
                result.Add(NormalLine(manipulatedText.Substring(0, 108)));
                manipulatedText = manipulatedText.Substring(107);
            }
            result.Add(NormalLine(manipulatedText));
            return result;
        }
        private static string NormalLine(string text)
        {
            string result = "* " + text + "*";
            while (result.Length < 110)
            {
                result = result.Insert(result.Length - 1, " ");
            }
            return result;

        }
        public static string Insert(string text, int startPosition)
        {
            string result = "*" + text + "*";
            for (int i = startPosition; i > 0; i--)
            {
                result = result.Insert(1, " ");
            }
            while (result.Length < 110)
            {
                result = result.Insert(result.Length - 1, " ");
            }
            return result;

        }
        public static string InsertCentered(string heading)
        {
            string result = "*" + heading + "*";
            while (result.Length < 110)
            {
                if (result.Length % 2 == 0)
                {
                    result = result.Insert(1, " ");
                }
                else
                {
                    result = result.Insert(result.Length - 1, " ");
                }
            }
            return result;
        }

        public static string InsertSelector(string option)
        {
            string result = ExtractText(option);
            result = result = Insert("--> " + result,15);
            return result;
        }

        public static string RemoveSelector(string option)
        {
            string result = ExtractText(option);
            if (result.Substring(0, 4) == "--> ")
            {
                result = result.Substring(4);
            }
            result = Insert("    " + result,15);
            return result;
        }

        private static string ExtractText(string line)
        {
            string result = line;
            result = result.Substring(1, result.Length - 2);
            result = result.TrimStart(' ');
            result = result.TrimEnd(' ');
            return result;
        }
    }
}

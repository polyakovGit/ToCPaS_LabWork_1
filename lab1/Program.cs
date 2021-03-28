using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static string EscapeCsvValue(string s) => "\"" + s.Replace("\"", "\"\"") + "\"";

        static void Main(string[] args)
        {
            var inputText = File.ReadAllText("../../InputTextFile.txt");
            var rx = new Regex(File.ReadAllText("../../RegExpression.txt"));
            var sb = new StringBuilder();
            sb.AppendLine("\"Номер\";\"Группа1\";\"Группа2\";\"Группа3\";\"Группа4\"");
            int i = 0;
            foreach (Match match in rx.Matches(inputText))
            {
                sb.AppendLine($"\"строка {++i}\";" +
                    $"{EscapeCsvValue(match.Groups[1].ToString())};" +
                    $"{EscapeCsvValue(match.Groups[2].ToString())};" +
                    $"{EscapeCsvValue(match.Groups[3].ToString())};" +
                    $"{EscapeCsvValue(match.Groups[4].ToString())}");
            }
            Console.WriteLine(sb.ToString());
            File.WriteAllText("../../OutputTextFile.csv", sb.ToString(), Encoding.UTF8);
        }
    }
}

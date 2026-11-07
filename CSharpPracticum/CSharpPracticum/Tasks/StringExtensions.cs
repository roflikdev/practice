using System;

namespace CSharpPracticum.Tasks
{
    /// <summary>Методы для строк.</summary>
    public static class StringExtensions
    {
        /// <summary>Проверяет, является ли строка палиндромом.</summary>
        public static bool IsPalindrome(this string text)
        {
            string clean = "";
            foreach (char c in text.ToLowerInvariant())
                if (char.IsLetterOrDigit(c)) clean += c;
            for (int i = 0; i < clean.Length / 2; i++)
                if (clean[i] != clean[clean.Length - 1 - i]) return false;
            return true;
        }

        /// <summary>Считает слова в строке.</summary>
        public static int WordCount(this string text)
        {
            int count = 0;
            bool inWord = false;
            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    if (!inWord) count++;
                    inWord = true;
                }
                else inWord = false;
            }
            return count;
        }

        /// <summary>Переворачивает строку.</summary>
        public static string ReverseString(this string text)
        {
            string result = "";
            for (int i = text.Length - 1; i >= 0; i--)
                result += text[i];
            return result;
        }
    }
}

using System;
using System.Linq;

namespace AutomationPracticeProject.Helpers
{
    public static class RandomHelper
    {
        private static readonly Random Random = new Random();
        private const string LettersWithNumbersPattern = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string LettersPattern = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NumbersPattern = "0123456789";

        public static string GetRandomString(int length) =>
            new string(Enumerable.Repeat(LettersPattern, length).Select(s => s[Random.Next(s.Length)]).ToArray());

        public static string GetRandomNumbers(int length) =>
            new string(Enumerable.Repeat(NumbersPattern, length).Select(s => s[Random.Next(s.Length)]).ToArray());

        public static string GetRandomStringWithNumbers(int length) =>
            new string(Enumerable.Repeat(LettersWithNumbersPattern, length).Select(s => s[Random.Next(s.Length)]).ToArray());

        public static int GetRandomNumbers(int minValue, int maxValue) =>
            Random.Next(minValue, maxValue);
    }
}
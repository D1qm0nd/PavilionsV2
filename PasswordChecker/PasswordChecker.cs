using System;
using System.Linq;

namespace Lib.PasswordChecker
{
    public static class PasswordChecker
    {

        public static string Check(string password)
        {
            return DifficultyStatus(GetDifficulty(password));
        }

        private static string DifficultyStatus(uint difficulty)
        {
            if (difficulty <= 2) return "Негодный";
            else if (difficulty <= 3) return "Лёгкий";
            else if (difficulty <= 4) return "Средний";
            else return "Сложный";
        }

        private static uint GetDifficulty(string password)
        {
            uint difficulty = 0;

            if (password.Length >= 8)
            {
                difficulty += 1;
                if (password.Any(c => Char.IsSymbol(c)))
                    difficulty += 1;
                if (password.Any(c => Char.IsLetter(c)))
                    difficulty += 1;

                if (password.Any(c => Char.IsPunctuation(c)))
                    difficulty += 1;
                if (password.Any(c => Char.IsDigit(c)))
                    difficulty += 1;
                if (password.Any(c => Char.IsUpper(c)) && password.Any(c => Char.IsLower(c)))
                    difficulty += 1;
            }
            return difficulty;
        }
    }
}

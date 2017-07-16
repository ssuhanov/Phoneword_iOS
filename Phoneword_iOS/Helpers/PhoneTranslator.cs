using System;
using System.Text;

namespace Phoneword_iOS
{
    public static class PhoneTranslator
    {
        public static string ToPhoneNumber(this string keyString)
        {
            if (string.IsNullOrWhiteSpace(keyString))
            {
                return "";
            }

            keyString = keyString.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach (var currentSymbol in keyString)
            {
                if (" -0123456789".Contains(currentSymbol))
                {
                    newNumber.Append(currentSymbol);
                }
                else
                {
                    var convertedLetter = TranslateToNumber(currentSymbol);
                    if (convertedLetter != null)
                    {
                        newNumber.Append(convertedLetter);
                    }
                }
                // otherwise we've skipped a non-numeric char
            }

            return newNumber.ToString();
        }

        static bool Contains(this string keyString, char letter)
        {
            return keyString.IndexOf(letter) >= 0;
        }

        static int? TranslateToNumber(char letter)
        {
            switch (letter)
            {
                case char c when "ABC".Contains(c):
                    return 2;
                case char c when "DEF".Contains(c):
                    return 3;
                case char c when "GHI".Contains(c):
                    return 4;
                case char c when "JKL".Contains(c):
                    return 5;
                case char c when "MNO".Contains(c):
                    return 6;
                case char c when "PQRS".Contains(c):
                    return 7;
                case char c when "TUV".Contains(c):
                    return 8;
                case char c when "WXYZ".Contains(c):
                    return 9;
                default:
                    return null;
            }
        }
    }
}

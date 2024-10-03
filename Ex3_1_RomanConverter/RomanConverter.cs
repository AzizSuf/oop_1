using System.Text;

namespace Ex3_1_RomanConverter
{
    public class RomanConverter
    {
        private static (int, string)[] table = {
        (1000, "M"), (900, "CM"), (500, "D"),
        (400, "CD"), (100, "C"), (90, "XC"),
        (50, "L"), (40, "XL"), (10, "X"),
        (9, "IX"), (5, "V"), (4, "IV"),
        (1, "I") };

        static public int ToArabic(string romanNumber)
        {
            int result = 0;
            int index = 0;

            while (index < romanNumber.Length)
            {
                bool found = false;

                foreach (var (arabicValue, romanValue) in table)
                {
                    if (romanNumber.Substring(index).StartsWith(romanValue))
                    {
                        result += arabicValue;
                        index += romanValue.Length;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    throw new ArgumentException("Invalid Roman numeral");
                }
            }

            return result;
        }

        static public string ToRoman(int arabicNumber)
        {
            var result = new StringBuilder();

            foreach (var (arabicValue, romanValue) in table)
            {
                while (arabicNumber >= arabicValue)
                {
                    result.Append(romanValue);
                    arabicNumber -= arabicValue;
                }
            }

            return result.ToString();
        }
    }
}
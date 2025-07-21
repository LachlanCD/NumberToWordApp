namespace NumberToWordApp.Services
{
    using System.Text;

    public interface INumberToWordsConverter
    {
        string Convert(decimal amount);
    }

    public class NumberToWordsConverter : INumberToWordsConverter
    {
        public string Convert(decimal amount)
        {
            var dollars = (int)amount;
            var cents = (int)((amount - dollars) * 100);

            if (dollars == 0 && cents == 0)
                return "Zero dollars.";

            var sb = new StringBuilder();
            sb.Append(NumberToWords(dollars) + (dollars != 0 ? " dollar" : "") + (dollars != 1 && dollars != 0 ? "s" : ""));
            if (cents != 0)
            {
                if (dollars != 0){
                  sb.Append(" and ");
                cents = Math.Abs(cents);
                }
                sb.Append(NumberToWords(cents) + " cent" + (cents != 1 ? "s" : ""));
            }
            var result = sb.ToString();
            return string.Concat(result[0].ToString().ToUpper(), result.AsSpan(1), ".");
        }

        private string NumberToWords(int number)
        {
            if (number < 0)
                return "negative " + NumberToWords(Math.Abs(number));

            var words = new StringBuilder();

            if ((number / 1000000000) > 0)
            {
                words.Append(NumberToWords(number / 1000000000) + " billion ");
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words.Append(NumberToWords(number / 1000000) + " million ");
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words.Append(NumberToWords(number / 1000) + " thousand ");
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words.Append(NumberToWords(number / 100) + " hundred ");
                number %= 100;
            }

            if (number > 0)
            {
                UnitsToWords(number, words);
            }

            return words.ToString().Trim();
        }

        private void UnitsToWords(int number, StringBuilder words)
        {
            string[] unitsMap = {
                "zero", "one", "two", "three", "four", "five", "six", "seven",
                "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen",
                "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            };

            string[] tensMap = {
                "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty",
                "seventy", "eighty", "ninety"
            };

            if (words.Length != 0)
                words.Append(" and ");

            if (number < 20)
                words.Append(unitsMap[number]);
            else
            {
                words.Append(tensMap[number / 10]);
                if ((number % 10) > 0)
                    words.Append("-" + unitsMap[number % 10]);
            }
        }
    }
}

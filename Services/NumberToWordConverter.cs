namespace NumberToWordApp.Services
{
  using System.Text;

    public class NumberToWordsConverter
    {
        public string Convert(decimal amount)
        {
            var dollars = (int)amount;
            var cents = (int)((amount - dollars) * 100);

            var sb = new StringBuilder();
            if (dollars > 0)
                sb.Append(NumberToWords(dollars) + " dollar" + (dollars != 1 ? "s" : ""));
            if (cents > 0)
            {
                if (dollars > 0) sb.Append(" and ");
                sb.Append(NumberToWords(cents) + " cent" + (cents != 1 ? "s" : ""));
            }
            return sb.ToString();
        }

        private string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string[] unitsMap = {
                "zero", "one", "two", "three", "four", "five", "six", "seven",
                "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen",
                "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            };

            string[] tensMap = {
                "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty",
                "seventy", "eighty", "ninety"
            };

            var words = new StringBuilder();

            if ((number / 1_000_000) > 0)
            {
                words.Append(NumberToWords(number / 1_000_000) + " million ");
                number %= 1_000_000;
            }

            if ((number / 1_000) > 0)
            {
                words.Append(NumberToWords(number / 1_000) + " thousand ");
                number %= 1_000;
            }

            if ((number / 100) > 0)
            {
                words.Append(NumberToWords(number / 100) + " hundred ");
                number %= 100;
            }

            if (number > 0)
            {
                if (words.Length != 0)
                    words.Append(" ");

                if (number < 20)
                    words.Append(unitsMap[number]);
                else
                {
                    words.Append(tensMap[number / 10]);
                    if ((number % 10) > 0)
                        words.Append("-" + unitsMap[number % 10]);
                }
            }

            return words.ToString().Trim();
        }
    }
}

using System.Numerics;

namespace Exercise01
{
    public static class ConvertNumbersToWords
    {
        private static int numberGroups = 7;

        // Single-digit and small number names
        private static string[] ones = new string[]
          {
        "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
        "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen",
        "sixteen", "seventeen", "eighteen", "nineteen"
          };

        // from twenty to ninety
        private static string[] tens = new string[]
          {
        "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy",
        "eighty", "ninety"
          };

        // Names from thousand on words as indicated by wikipedia
        private static string[] bigNumbers = new string[]
          {
        "", "thousand", "million", "billion", "trillion",
        "quadrillion", "quintillion"
          };

       
        public static string ToWords(this int number)
        {
            return ToWords((BigInteger)number);
        }

        public static string ToWords(this long number)
        {
            return ToWords((BigInteger)number);
        }

        public static string ToWords(this BigInteger number)
        {
          
            if (number == 0)
            {
                return "zero";
            }
            int[] digitGroups = new int[numberGroups];

            var positive = BigInteger.Abs(number);

            for (int i = 0; i < numberGroups; i++)
            {
                digitGroups[i] = (int)(positive % 1000);
                positive /= 1000;
            }

            string[] groupTexts = new string[numberGroups];

            for (int i = 0; i < numberGroups; i++)
            {
                groupTexts[i] = ThreeDigitGroupToWords(digitGroups[i]);
            }

            // Recombine the three-digit groups
            string combined = groupTexts[0];
            bool appendAnd;

            // Determine whether an 'and' is needed
            appendAnd = (digitGroups[0] > 0) && (digitGroups[0] < 100);

            // Process the remaining groups in turn, smallest to largest
            for (int i = 1; i < numberGroups; i++)
            {
                // Only add non-zero items
                if (digitGroups[i] != 0)
                {
                    // Build the string to add as a prefix
                    string prefix = groupTexts[i] + " " + bigNumbers[i];

                    if (combined.Length != 0)
                    {
                        prefix += appendAnd ? " and " : ", ";
                    }

                    // Opportunity to add 'and' is ended
                    appendAnd = false;

                    // Add the three-digit group to the combined string
                    combined = prefix + combined;
                }
            }

            // Converts a three-digit group into English words
            string ThreeDigitGroupToWords(int threeDigits)
            {
                // Initialise the return text
                string groupText = "";

                // Determine the hundreds and the remainder
                int hundreds = threeDigits / 100;
                int tensUnits = threeDigits % 100;

                  // Hundreds Rules.
                if (hundreds != 0)
                {
                    groupText += ones[hundreds] + " hundred";

                    if (tensUnits != 0)
                    {
                        groupText += " and ";
                    }
                }

                // Determine the tens and units
                int tens = tensUnits / 10;
                int units = tensUnits % 10;

                //Tens
  
                if (tens >= 2)
                {
                    groupText += ConvertNumbersToWords.tens[tens];
                    if (units != 0)
                    {
                        groupText += " " + ones[units];
                    }
                }
                else if (tensUnits != 0)
                    groupText += ones[tensUnits];

                return groupText;
            }

            // Negative.

            if (number < 0)
            {
                combined = "negative " + combined;
            }

            return combined;
        }
    }
}
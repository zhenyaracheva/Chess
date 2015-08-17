namespace Chess.Helpers
{
    using System;

    public static class Validator
    {
        public static void ValidRange(int value, int minRange, int maxRange, string message)
        {
            if (value < minRange || value > maxRange)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        public static void ValidateNullOrEmptyString(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}

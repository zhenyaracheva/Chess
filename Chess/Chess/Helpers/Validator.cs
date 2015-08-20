namespace Chess.Helpers
{
    using System;

    public  class Validator
    {
        public  void ValidRange(int value, int minRange, int maxRange, string message)
        {
            if (value < minRange || value > maxRange)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        public  void ValidateNullOrEmptyString(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}

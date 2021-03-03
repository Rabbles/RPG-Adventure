using System;
using System.Security.Cryptography;

namespace Engine
{   /// <summary>
    /// Static class to generate a random number. 
    /// </summary>
    public static class RandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        /// <summary>
        /// Generates a random number between a minimum and maximum value.
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int NumberBetween(int minValue, int maxValue)
        {
            var randomNumber = new byte[1];
            _generator.GetBytes(randomNumber);
            var asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);
            var multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
            var range = maxValue - minValue + 1;
            var randomValueInRange = Math.Floor(multiplier * range);
            return (int) (minValue + randomValueInRange);
        }
    }
}

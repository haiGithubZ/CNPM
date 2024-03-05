using System;
using System.Linq;

namespace Jhipster.Service.Utilities
{
    public class RandomUtil
    {
        private const int DefCount = 20;
        private const int OTPCount = 6;
        private static readonly Random random = new Random();

        public static string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, DefCount)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string RandomNumeric(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateActivationKey()
        {
            return RandomNumeric(DefCount);
        }

        public static string GenerateResetKey()
        {
            return RandomNumeric(DefCount);
        }

        public static string GenarateOTP()
        {
            return RandomNumeric(OTPCount);
        }

        public static string GenerateKeyPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, 20)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticatedSchoolSystem.Back_End.Lib
{
    public static class Security
    {
        public static string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        public static byte[] Hash(string value, string salt)
        {
            byte[] _value = Encoding.UTF8.GetBytes(value);
            byte[] _salt = Encoding.UTF8.GetBytes(salt);
            byte[] _saltedValue = _value.Concat(_salt).ToArray();

            return new SHA256Managed().ComputeHash(_saltedValue);
        }

        public static bool ConfirmPassword(string password, byte[] userPasswordHash, string UserSalt)
        {
            byte[] passwordHash = Hash(password, UserSalt);

            return userPasswordHash.SequenceEqual(passwordHash);
        }
    }
}
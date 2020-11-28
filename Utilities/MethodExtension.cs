using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class MethodExtension
    {
        public static long ToLong(this object o)
        {
            try
            {
                return Convert.ToInt64(o);
            }
            catch
            {
                return 0;
            }
        }
        public static long? ToNullableLong(this object o)
        {
            try
            {
                return Convert.ToInt64(o);
            }
            catch
            {
                return null;
            }
        }
        public static int ToInt(this object o)
        {
            try
            {
                return Convert.ToInt32(o);
            }
            catch
            {
                return 0;
            }
        }
        public static int? ToNullableInt(this object o)
        {
            try
            {
                return Convert.ToInt32(o);
            }
            catch
            {
                return null;
            }
        }
        public static string ToSHA256(this string s)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(s));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}

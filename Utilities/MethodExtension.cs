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
        public static string GenerateRandomNumberString(int length = Constants.GenerateRandomNumber.DefaulLength)
        {
            try
            {
                Random rdm = new Random(Guid.NewGuid().GetHashCode());
                string res = "";
                for (int i = 0; i < length; i++)
                {
                    res += (rdm.Next() % 10).ToString();
                }
                return res;
            }
            catch
            {
                return Constants.GenerateRandomNumber.DefaultStringPass;
            }
        }
        public static short GenerateRandomNumberShort(int length = Constants.GenerateRandomNumber.DefaulLength)
        {
            try
            {
                Random rdm = new Random(Guid.NewGuid().GetHashCode());
                string res = "";
                for (int i = 0; i < length; i++)
                {
                    int temp = 0;
                    while (temp == 0)
                    {
                        temp = (rdm.Next() % 10);
                        if (temp != 0)
                            res += temp.ToString();
                    }
                }
                return res.ToShort();
            }
            catch
            {
                return Constants.GenerateRandomNumber.DefaultShortPass;
            }
        }
        public static long ToLong(this object s)
        {
            try
            {
                return Convert.ToInt64(s);
            }
            catch
            {
                return 0;
            }
        }
        public static long? ToNullableLong(this object s)
        {
            try
            {
                return Convert.ToInt64(s);
            }
            catch
            {
                return null;
            }
        }
        public static byte ToByte(this object s)
        {
            try
            {
                return Convert.ToByte(s);
            }
            catch
            {
                return 0;
            }
        }
        public static byte? ToNullableByte(this object s)
        {
            try
            {
                return Convert.ToByte(s);
            }
            catch
            {
                return null;
            }
        }
        public static int ToInt(this object s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch
            {
                return 0;
            }
        }
        public static int? ToNullaleInt(this object s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch
            {
                return null;
            }
        }
        public static short ToShort(this object s)
        {
            try
            {
                return Convert.ToInt16(s);
            }
            catch
            {
                return 0;
            }
        }
        public static short? ToNullableShort(this object s)
        {
            try
            {
                return Convert.ToInt16(s);
            }
            catch
            {
                return null;
            }
        }
        public static bool ToBoolean(this object s)
        {
            try
            {
                return Convert.ToBoolean(s);
            }
            catch
            {
                return false;
            }
        }
        public static bool? ToNullableBoolean(this object s)
        {
            try
            {
                return Convert.ToBoolean(s);
            }
            catch
            {
                return null;
            }
        }
        public static string ToNullableString(this object s)
        {
            try
            {
                var a = s.ToString();
                if (String.IsNullOrEmpty(a))
                    return null;
                if (String.IsNullOrWhiteSpace(a))
                    return null;
                return a;
            }
            catch
            {
                return null;
            }
        }
        public static bool IsNotNull(this object o)
        {
            try
            {
                if (o == null)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsNotNull(this string s)
        {
            try
            {
                return !string.IsNullOrEmpty(s);
            }
            catch
            {
                return false;
            }
        }
        public static bool IsNull(this object o)
        {
            try
            {
                return o == null;
            }
            catch
            {
                return true;
            }
        }
        public static void DeleteDirectoryFiles(string Path)
        {
            try
            {
                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(Path);
                foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
                foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
            }
            catch
            {

            }
        }
        public static string ToSHA256(this string s)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(s));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

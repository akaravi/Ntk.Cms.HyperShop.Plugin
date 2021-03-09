using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Ntk.Cms.HyperShop.PluginInterface.Helper
{
    public static class StringHelper
    {
        public static string mKey = "tXq~Fgl!*(_7041B";
        private const int keysize = 128;
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tj84ge£a340d@9ur");

        public static string EncryptString(this string plainText)
        {
            var passPhrase = mKey;
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new PasswordDeriveBytes(passPhrase, null))
            {
                var keyBytes = password.GetBytes(keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = memoryStream.ToArray();


                                //return Convert.ToBase64String(cipherTextBytes);
                                return Base64UrlEncode(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string DecryptString(this string cipherText)
        {
            try
            {
                var passPhrase = mKey;
                var cipherTextBytes = Base64UrlDecode(cipherText);
                //var cipherTextBytes = Convert.FromBase64String(cipherText);
                using (var password = new PasswordDeriveBytes(passPhrase, null))
                {
                    var keyBytes = password.GetBytes(keysize / 8);
                    using (var symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                        {
                            using (var memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (
                                    var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    var plainTextBytes = new byte[cipherTextBytes.Length];
                                    var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }

            catch
            {
                return "";
            }
        }
        private static string Base64UrlEncode(byte[] bytes)
        {
            var retOut = Convert.ToBase64String(bytes);
            retOut = retOut.TrimEnd('=').Replace('+', '-').Replace('/', '_');
            return retOut;//.Replace("=", "").Replace('+', '-').Replace('/', '_');

        }
        private static string Base64UrlEncode(string str)
        {
            if (str == null || str == "")
            {
                return "";
            }

            byte[] bytesToEncode = System.Text.UTF8Encoding.UTF8.GetBytes(str);
            //String returnVal = System.Convert.ToBase64String(bytesToEncode);

            return Base64UrlEncode(bytesToEncode);
        }
        private static byte[] Base64UrlDecode(string str)
        {
            str = str.Replace('-', '+').Replace('_', '/');
            string padding = new String('=', 3 - (str.Length + 3) % 4);
            str += padding;
            return Convert.FromBase64String(str);
        }

        public static String ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

    }
}
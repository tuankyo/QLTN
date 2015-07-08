/*
  Author: Nguyen Lam Thao
  Modified: 2007-01-17
 */

using System;
using System.Globalization;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Man
{
    /// <summary>
    /// Summary description for EnDeCryptionString.
    /// </summary>
    public class Encryption64
    {
        //private byte[] key = {};
        //private byte[] IV = {10, 20, 30, 40, 50, 60, 70, 80}; // it can be any byte value

        public static string Decrypt(string stringToDecrypt,
            string sEncryptionKey)
        {
            if (String.IsNullOrEmpty(stringToDecrypt))
            {
                return string.Empty;
            }
            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray = new byte[stringToDecrypt.Length];

            try
            {
                key = Encoding.GetEncoding("Shift-JIS").GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                //inputByteArray = Convert.FromBase64String(stringToDecrypt);
                inputByteArray = ConvertHexStringToBytes(stringToDecrypt);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                Encoding encoding = Encoding.GetEncoding("Shift-JIS");
                return encoding.GetString(ms.ToArray());
            }
            catch /*Never use code		(System.Exception ex)	*/
            {
                return "";
                //throw ex;
            }
        }

        public void test()
        {
            string s = Encryption64.Encrypt("thao", "!#$a54?3");
            s = Encryption64.Encrypt("thao", "45345");
            Console.Write(s);

        }

        public static string Encrypt(string stringToEncrypt,
            string sEncryptionKey)
        {

            if (String.IsNullOrEmpty(stringToEncrypt))
            {
                return string.Empty;
            }
            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray; //Convert.ToByte(stringToEncrypt.Length)

            try
            {
                key = Encoding.GetEncoding("Shift-JIS").GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Encoding.GetEncoding("Shift-JIS").GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                //return Convert.ToBase64String(ms.ToArray());
                return ConvertBytesToHexString(ms.ToArray());
            }
            catch /*Never use code	(System.Exception ex  )*/
            {
                return "";
                //throw ex;
            }
        }
        private static string ConvertBytesToHexString(byte[] data)
        {
            string hexString = "";
            foreach (byte b in data)
                hexString += String.Format("{0:X2}", b);
            return hexString;
        }
        private static byte[] ConvertHexStringToBytes(string hexString)
        {
            int numBytes = hexString.Length / 2;
            byte[] arrByte = new byte[numBytes];
            for (int i = 0; i < numBytes; ++i)
                arrByte[i] = byte.Parse(hexString.Substring(i * 2, 2),
                    System.Globalization.NumberStyles.HexNumber);
            return arrByte;
        }

        public static string Encrypt64(string stringToEncrypt,
        string sEncryptionKey)
        {
            if (String.IsNullOrEmpty(stringToEncrypt))
            {
                return string.Empty;
            }
            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray; //Convert.ToByte(stringToEncrypt.Length)

            try
            {
                key = Encoding.GetEncoding("Shift-JIS").GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Encoding.GetEncoding("Shift-JIS").GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return "";
                //throw ex;
            }
        }


        /// <summary>
        /// If data is not valid base64 then pad right with "="
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetStringBase64(string data)
        {
            int remainChar = 0;
            if (data.Length % 4 != 0)
            {
                remainChar = 4 - data.Length % 4;
            }
            data = data.PadRight(data.Length + remainChar, '=');
            return data;
        }

        public static string Decrypt64(string stringToDecrypt,
           string sEncryptionKey)
        {
            if (String.IsNullOrEmpty(stringToDecrypt))
            {
                return string.Empty;
            }
            stringToDecrypt = GetStringBase64(stringToDecrypt);
            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray = new byte[stringToDecrypt.Length];

            try
            {
                key = Encoding.GetEncoding("Shift-JIS").GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                Encoding encoding = Encoding.GetEncoding("Shift-JIS");
                return encoding.GetString(ms.ToArray());
            }
            catch
            {
                return "";
                //throw ex;
            }
        }
    }

}


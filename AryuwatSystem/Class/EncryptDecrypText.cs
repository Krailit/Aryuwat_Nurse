using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AryuwatSystem.DerClass
{
    public class EncryptDecrypText
    {
        private static readonly string strEncrypt = Statics.EncryptDecrypt_key;
        public static string encryptPassword(string strText)
        {
            return EncryptText(strText);
        }
        public static string decryptPassword(string str)
        {
            return DecryptText(str);
            //return DecryptText(EncryptText(str));
        }
        private static string EncryptText(string strText)
        {
            byte[] byKey = new byte[20];
            byte[] dv = {0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF};
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(strEncrypt.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputArray = System.Text.Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, dv), CryptoStreamMode.Write);
                cs.Write(inputArray, 0, inputArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());///testhhji
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string DecryptText(string strText)
        {
            byte[] bKey = new byte[20];
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                bKey = System.Text.Encoding.UTF8.GetBytes(strEncrypt.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(bKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static string EncryptText(string openText)
        //{

        //    RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();
        //    ICryptoTransform encryptor = rc2CSP.CreateEncryptor(Convert.FromBase64String(c_key), Convert.FromBase64String(c_iv));
        //    using (MemoryStream msEncrypt = new MemoryStream())
        //    {
        //        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //        {
        //            byte[] toEncrypt = Encoding.Unicode.GetBytes(openText);

        //            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
        //            csEncrypt.FlushFinalBlock();

        //            byte[] encrypted = msEncrypt.ToArray();

        //            return Convert.ToBase64String(encrypted);
        //        }
        //    }
        //}

        //public static string DecryptText(string encryptedText)
        //{
        //    RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();
        //    ICryptoTransform decryptor = rc2CSP.CreateDecryptor(Convert.FromBase64String(c_key), Convert.FromBase64String(c_iv));
        //    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText)))
        //    {
        //        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
        //        {
        //            List<Byte> bytes = new List<byte>();
        //            int b;
        //            do
        //            {
        //                b = csDecrypt.ReadByte();
        //                if (b != -1)
        //                {
        //                    bytes.Add(Convert.ToByte(b));
        //                }

        //            }
        //            while (b != -1);

        //            return Encoding.Unicode.GetString(bytes.ToArray());
        //        }
        //    }
        //}
    }
}

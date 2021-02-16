using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MyMCE.Models.Helper
{
    public class Util
    {
        public static string GetHashByte(string strPassword)
        {
            string pwdString = string.Empty;
            UTF8Encoding Ue = new UTF8Encoding();
            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
            byte[] ByteHash = Md5.ComputeHash(Ue.GetBytes(strPassword));
            pwdString = BitConverter.ToString(ByteHash);
            pwdString = pwdString.Replace("-", null);
            return pwdString;
        }
    }
}
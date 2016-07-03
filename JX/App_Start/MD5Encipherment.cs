using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace JX.App_Start
{
    public class MD5Encipherment
    {
        public static string MD5E(string str)
        {
            byte[] result = Encoding.Default.GetBytes(str.Trim());    //tbPass为输入密码的文本框  
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
    }
}

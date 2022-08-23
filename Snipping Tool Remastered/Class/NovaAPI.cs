/*Original repository credits: https://github.com/michaelmob/Hyperdesktop2 by michaelmob
Based on HyperDesktop 2 as a continuation of the project, with a number of modifications. 
Fixed bugs and features from the original version.
The project was continued by (qzxtu) Nova#1735
*/
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Snipping_Tool_Remastered.Class
{
    internal class NovaAPI
    {
        #region secure webclient
        public static WebClient SecureWebClient()
        {
            AntiFiddler();
            WebClient w = new WebClient
            { Proxy = null }; ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; return w;
        }
        #endregion

        #region AntiFiddler
        public static void AntiFiddler() => HttpWebRequest.DefaultWebProxy = new WebProxy();
        #endregion

        #region force memory clean
        public static void gc()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        #endregion

        #region Decrypt Engine
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);
            string x = "helloworld1456334";
            string key = x;

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion
    }
}

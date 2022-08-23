/*Original repository credits: https://github.com/michaelmob/Hyperdesktop2 by michaelmob
Based on HyperDesktop 2 as a continuation of the project, with a number of modifications. 
Fixed bugs and features from the original version.
The project was continued by (qzxtu) Nova#1735
*/
using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Net;
using System.Text;

namespace Snipping_Tool_Remastered
{
    internal class Imgur
    {
        public static WebClient web_client = new WebClient();

        private const string baseUrl = "https://api.imgur.com/3/";

        public static Boolean upload(Bitmap bmp)
        {
            try
            {
                var data = new NameValueCollection();
                var image = Global_Func.bmp_to_base64(bmp, Global_Func.ext_to_imageformat(cls_Settings.upload_format));
                data.Add("image", image);

                web_client.Headers.Add("Authorization", "Client-ID " + cls_Settings.imgur_client_id);   
                web_client.UploadValuesAsync(
                    new Uri(baseUrl + "image/"),
                    "POST",
                    data
                );
                web_client.Headers.Remove("Authorization");
                web_client.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean delete(String delete_hash)
        {
            try
            {
                var web_client = new WebClient
                {
                    Encoding = Encoding.UTF8
                };
                web_client.Headers.Add("Authorization", "Client-ID " + cls_Settings.imgur_client_id);
                web_client.UploadData(
                    new Uri (baseUrl + "image/" + delete_hash),
                    "DELETE",
                    new byte[] { 0x0 }
                );

                web_client.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

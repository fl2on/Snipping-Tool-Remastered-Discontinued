using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Snipping_Tool_Remastered
{
    internal static class Imgur
    {
        private static readonly HttpClient Client = new HttpClient { Timeout = TimeSpan.FromSeconds(90) };
        private const string BaseUrl = "https://api.imgur.com/3/image/";
        private static readonly SemaphoreSlim UploadGate = new SemaphoreSlim(1, 1);

        public static async Task<UploadResult> UploadAsync(Bitmap bitmap)
        {
            if (!await UploadGate.WaitAsync(0))
                throw new InvalidOperationException("An upload is already in progress.");
            try
            {
                string image = Global_Func.bmp_to_base64(bitmap, Global_Func.ext_to_imageformat(cls_Settings.upload_format));
                using (var content = new FormUrlEncodedContent(new[] { new System.Collections.Generic.KeyValuePair<string, string>("image", image) }))
                using (var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Client-ID", cls_Settings.imgur_client_id);
                    request.Content = content;
                    using (HttpResponseMessage response = await Client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        string json = await response.Content.ReadAsStringAsync();
                        JObject parsed = JObject.Parse(json);
                        if (parsed.Value<bool?>("success") != true)
                            throw new InvalidOperationException("Imgur returned an unsuccessful response.");
                        string link = (string)parsed["data"]?["link"];
                        string hash = (string)parsed["data"]?["deletehash"];
                        Uri url;
                        if (!Uri.TryCreate(link, UriKind.Absolute, out url) ||
                            url.Scheme != Uri.UriSchemeHttps ||
                            !(url.Host.Equals("imgur.com", StringComparison.OrdinalIgnoreCase) ||
                              url.Host.EndsWith(".imgur.com", StringComparison.OrdinalIgnoreCase)))
                            throw new InvalidOperationException("Imgur returned an invalid image URL.");
                        return new UploadResult { Link = link, DeleteHash = hash };
                    }
                }
            }
            finally { UploadGate.Release(); }
        }

        public static async Task<bool> DeleteAsync(string hash)
        {
            if (String.IsNullOrWhiteSpace(hash) ||
                !System.Text.RegularExpressions.Regex.IsMatch(hash, "^[A-Za-z0-9]+$"))
                return false;
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Delete, BaseUrl + hash))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Client-ID", cls_Settings.imgur_client_id);
                    using (var response = await Client.SendAsync(request))
                        return response.IsSuccessStatusCode;
                }
            }
            catch (HttpRequestException) { return false; }
            catch (TaskCanceledException) { return false; }
        }

        internal sealed class UploadResult
        {
            public string Link { get; set; }
            public string DeleteHash { get; set; }
        }
    }
}

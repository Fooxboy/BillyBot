using System;
using System.IO;
using VkNet;


namespace Billy.API
{
    public class Data
    {
        public static string GetToken()
        {
            string text;
            using (var writer = new StreamReader("AccessToken.txt"))
            {
                text = writer.ReadToEnd();
            }
            return text;
        }

        public static VkApi GetVk()
        {
            var token = Data.GetToken();
            var Vk = new VkApi();
            Vk.Authorize(new ApiAuthParams
            {
                AccessToken = token
            });
            return Vk;
        }
    }
}

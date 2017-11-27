using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;


namespace Billy.API
{
    public class Audio
    {
        public class Methods
        {
            public static Models.Audio Get(string audio)
            {
                Models.Audio audioModel = new Models.Audio();
                using (var client = new WebClient())
                {
                    string key = "1f13342a89bad6aa9b064f8bc67fa546";
                    string url = $"http://api.xn--41a.ws/api.php?method=get.audio&ids={audio}&key={key}";
                    client.Encoding = Encoding.UTF8;
                    var json = client.DownloadString(url);
                    var model = JsonConvert.DeserializeObject<List<List<object>>>(json);
                    List<object> modelobject = model[0];          
                    audioModel.AudioId = (long)modelobject[0];
                    audioModel.UserId = (long)modelobject[1];
                    audioModel.Url = (string)modelobject[2];      
                }
                return audioModel;
            }
        }

    }
}

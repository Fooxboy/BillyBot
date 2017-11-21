using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models.Params;
using System.Net;
using Newtonsoft.Json;
using Billy.Models;
using Billy.Exceptions;

namespace Billy.LongPoll
{
    public class LongPollModel
    {
        public static LongPollRoot Get(GetLongPollModelParams @params)
        {
            string json;
            using (var client = new WebClient())
            {
                string url = $"https://{@params.Server}?act=a_check&key={@params.Key}&ts={@params.Ts}&wait=25&mode=2&version=2";
                var response = client.DownloadString(url);
                json = response.ToString();
            }
            var model = JsonConvert.DeserializeObject<LongPollRoot>(json);
            if (model.Ts == null)
            {
                throw new ErrorLongPollException();
            } else
            {
                return model;
            }
        }
    }
}

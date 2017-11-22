using System;
using System.Collections.Generic;
using System.Text;
using Billy.API;
using VkNet;
using Billy.Models;
using VkNet.Model;

namespace Billy.LongPoll
{
    public class KeyAndServer
    {
        public static GetLongPoll Get()
        {
            var vk = API.Data.GetVk();
            var result = vk.Messages.GetLongPollServer();
            GetLongPoll response = new GetLongPoll();
            response.Key = result.Key;
            response.Pts = result.Pts;
            response.Server = result.Server;
            response.Ts = result.Ts;
            return response;
        }
    }
}

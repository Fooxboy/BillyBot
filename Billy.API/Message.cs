using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models.Params;

namespace Billy.API
{
    public class Message
    {
        public static void Send(MessageSendParams @params)
        {
            var vk = Data.GetVk();
            vk.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                PeerId = @params.PeerId,
                Message = @params.Message,
                CaptchaKey = @params.CaptchaKey,
                CaptchaSid = @params.CaptchaSid
            });
            //ready.
        }
    }
}

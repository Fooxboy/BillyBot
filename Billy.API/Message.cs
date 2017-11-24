using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models.Params;
using Billy.Helpers;

namespace Billy.API
{
    public class Message
    {
        public static void Send(MessageSendParams @params)
        {
            var vk = Data.GetVk();
            string message;
            if(@params.From != 0)
            {
                var user = new User(@params.From);
                user.NewMessage();
                message = $"{user.Name}, {@params.Message}";
            }else
            {
                message = @params.Message;
            }
            vk.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                PeerId = @params.PeerId,
                Message = message,
                CaptchaKey = @params.CaptchaKey,
                CaptchaSid = @params.CaptchaSid
            });
            //ready.
        }
    }
}

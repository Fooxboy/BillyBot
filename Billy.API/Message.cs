using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models.Params;
using Billy.Helpers;
using System.Net;
using System.IO;
using System.Security.Cryptography;

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
        }

        public static void SendPhoto(string resultUpload, MessageSendParams @params)
        {
            var vk = Data.GetVk();
            

            var photo =  vk.Photo.SaveMessagesPhoto(resultUpload);
            vk.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                PeerId = @params.PeerId,
                Message = @params.Message,
                CaptchaKey = @params.CaptchaKey,
                CaptchaSid = @params.CaptchaSid,
                Attachments = photo
            });
        }        
    }
}

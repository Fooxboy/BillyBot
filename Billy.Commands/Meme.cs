using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Meme : ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Meme();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            var vk = API.Data.GetVk();
            long[] groups =
            {
                -142482686,
                -66678575,
                -139939445,
                -45745333
            };
            var rand = new Random();
            var posts = vk.Wall.Get(new VkNet.Model.RequestParams.WallGetParams
            {
                OwnerId = groups[rand.Next(0, groups.Length - 1)],
                Count = 30
            }).WallPosts;
            int index = rand.Next(0, 29);
            var post = posts[index];
            if(post.Attachments.Count  == 0)
            {
                throw new Exception("ууу");
            }else
            {
                var attach = post.Attachment;
                if(attach.Type == typeof(VkNet.Model.Attachments.Photo))
                {
                    var photo = (VkNet.Model.Attachments.Photo)attach.Instance;
                    var url = photo.Photo604;
                    var client = new System.Net.WebClient();
                    var fileName = $"Photo_{photo.Id}.jpg";
                    client.DownloadFile(url, fileName);
                    var urlPhoto = vk.Photo.GetMessagesUploadServer().UploadUrl;
                    var PhotoStr = API.Upload.Photo(fileName, urlPhoto);

                    API.Message.SendPhoto(PhotoStr, new Models.Params.MessageSendParams
                    {
                        PeerId = message.PeerId,
                        Message = "Ваш МЕМ:",
                        From = message.From
                    });
                    
                    System.IO.File.Delete(fileName);
                    
                }else
                {
                    throw new Exception("ууу");
                }
            }
        }
    }
}

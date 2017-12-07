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
            string result = "Неизвестная ошибка.";
            var vk = API.Data.GetVk();
            long[] groups =
            {
                1,
                2,
                4
            };
            var rand = new Random();
            var posts = vk.Wall.Get(new VkNet.Model.RequestParams.WallGetParams
            {
                OwnerId = groups[rand.Next(0, groups.Length)],
                Count = 30
            }).WallPosts;
            int index = rand.Next(0, 29);
            var post = posts[index];
            if(post.Attachments.Count  == 0)
            {
                //хуй саси.
            }else
            {
                var attach = post.Attachment;
                if(attach.Type == typeof(VkNet.Model.Attachments.Photo))
                {
                    var photo = (VkNet.Model.Attachments.Photo)attach.Instance;
                    var url = photo.BigPhotoSrc;
                    var client = new System.Net.WebClient();
                    client.DownloadFile(url, $"Photo_{photo.Id}");
                    //загружаем на сервер.
                    //ббла бла бла
                    //бла бла бла
                    System.IO.File.Delete($"Photo_{photo.Id}");
                    
                }else
                {
                    //хуй саси.
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Story: ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Story();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизветсная ошибка";

            var vk = API.Data.GetVk();
            long[] groups =
            {
                1,
                2,
                4
            };
            var Random = new Random();
            var posts = vk.Wall.Get(new VkNet.Model.RequestParams.WallGetParams
            {
                OwnerId = groups[Random.Next(0,groups.Length)],
                Count =  30       
            });
            var post = GetPost(posts);
            result = post.Text;
            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });
        }

        private VkNet.Model.Post GetPost(VkNet.Model.WallGetObject posts)
        {
            var rand = new Random();
            int index = rand.Next(0, 29);
            var post = posts.WallPosts[index];
            if(post.Attachments.Count == 0)
            {
                return post;
            }else
            {
                GetPost(posts);
            }
            throw new Exception("Ошибка.");
        }
    }
}

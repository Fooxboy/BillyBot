using System;
using Billy.Models;
using System.Text.RegularExpressions;


namespace Billy.Commands
{
    public class Render
    {
        public static void Run(Message message)
        {
            string[] text = Split(message.ExtraFields.Text);
            int countWords = text.Length;
            string name = text[0].ToLower();
            if(name == "билли"||name == "билли," || name == "бил" || name == "бил," || name == "билл" || name == "билл," || name == "billy" || name == "billy,")
            {
                API.Message.Send(new Models.Params.MessageSendParams
                {
                    Message = "хуй",
                    PeerId = message.PeerId
                });
            }
        }

        private static string[] Split(string message)
        {
            string[] response = message.Split(' ');
            return response;
        }
    }
}

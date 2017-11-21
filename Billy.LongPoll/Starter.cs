using System;
using Billy.API;
using Billy.Models.Params;
using Billy.Models;
using Newtonsoft.Json.Linq;
using Billy.Exceptions;
using Billy.Commands;

namespace Billy.LongPoll
{
    public class Starter
    {
        private string Server = null;
        private ulong Ts = 0;
        private string Key = null;
        private ulong? Pts;

        public void Start()
        {
            if(Server == null || Key == null)
            {
                SetKeyAndServer();
            }
            LongPollRoot model;
            try
            {
                model = LongPollModel.Get(new GetLongPollModelParams
                {
                    Server = Server,
                    Ts = Ts,
                    Key = Key,
                    Pts = Pts
                });
            }catch(ErrorLongPollException)
            {
                SetKeyAndServer();
                model = LongPollModel.Get(new GetLongPollModelParams
                {
                    Server = Server,
                    Ts = Ts,
                    Key = Key,
                    Pts = Pts
                });

                if (model.Ts == null)
                {
                    throw new Exception("Ошибка.");
                }
            }          
            Ts = UInt64.Parse(model.Ts);
            var updates = model.Updates;
            if(updates.Count != 0)
            {
                foreach (var update in updates)
                {
                    long code = (long)update[0];          
                    if(code == 4)
                    {
                        var message = new Models.Message();
                        message.MessageId = System.Convert.ToUInt64((long)update[1]);
                        message.Flags = Convert.ToString((long)update[2]);
                        message.ExtraFields = new ExtraFields();
                        message.ExtraFields.PeerId = (long)update[3];
                        message.ExtraFields.Time = System.Convert.ToString((long)update[4]);
                        message.ExtraFields.Text = (string)update[5];
                        var type_attach = (JObject)update[6];
                        message.ExtraFields.Attach = type_attach.ToObject<Attach>();
                        if(message.ExtraFields.Attach.from == null)
                        {
                            message.From = message.ExtraFields.PeerId;
                            message.Type = Enums.LongPoll.TypeMessage.Dialog;
                        }else
                        {
                            message.From = Int64.Parse(message.ExtraFields.Attach.from);
                            message.Type = Enums.LongPoll.TypeMessage.Chat;
                        }
                        message.PeerId = message.ExtraFields.PeerId;
                        Render.Run(message);     
                    }
                }
            }
        }
        
        private void SetKeyAndServer()
        {
            var model = KeyAndServer.Get();
            Server = model.Server;
            Ts = model.Ts;
            Key = model.Key;
            Pts = model.Pts;
        }
    }
}

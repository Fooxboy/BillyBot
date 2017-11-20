using System;
using Billy.API;
using Billy.Models;

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

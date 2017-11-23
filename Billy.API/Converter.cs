using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.API
{
    public class Converter
    {
        public static long ToChatId(long peer_id)
        {    
            var chatId = peer_id - 2000000000;
            return chatId;
        }

        public static long ToPeerId(long chat_id)
        {
            var PeerId = chat_id + 2000000000;
            return PeerId;
        }
    }
}

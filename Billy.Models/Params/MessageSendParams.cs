using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Models.Params
{
    public struct MessageSendParams
    {
        public long PeerId { get; set; }
        public string Message { get; set; }
        public long? CaptchaSid { get; set; }
        public string CaptchaKey { get; set; }
        public long From { get; set; }
    }
}

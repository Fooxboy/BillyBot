using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Models
{
    public class Message
    {
        public ulong MessageId { get; set; }
        public string Flags { get; set; }
        public Enums.LongPoll.TypeMessage Type { get; set; }
        public long From { get; set; }
        public ExtraFields ExtraFields {get;set;}
        public long PeerId { get; set; }
    }

    public class ExtraFields
    {
        public long PeerId { get; set; }
        public string Time { get; set; }
        public string Text { get; set; }
        public Attach Attach { get; set; }
    }

    public class Attach
    {
        public string attach1_type { get; set; }
        public string attach2_type { get; set; }
        public string attach3_type { get; set; }
        public string attach4_type { get; set; }
        public string attach5_type { get; set; }
        public string attach6_type { get; set; }
        public string attach7_type { get; set; }
        public string attach8_type { get; set; }
        public string attach9_type { get; set; }
        public string attach10_type { get; set; }
        public string attach1 { get; set; }
        public string attach2 { get; set; }
        public string attach3 { get; set; }
        public string attach4 { get; set; }
        public string attach5 { get; set; }
        public string attach6 { get; set; }
        public string attach7 { get; set; }
        public string attach8 { get; set; }
        public string attach9 { get; set; }
        public string attach10 { get; set; }
        public string fwd { get; set; }
        public string from { get; set; }
        public string geo { get; set; }
        public string geo_provider { get; set; }
        public string title { get; set; }
        public string attach1_product_id { get; set; }
        public string attach1_photo { get; set; }
        public string attach1_title { get; set; }
        public string attach1_desc { get; set; }
        public string attach1_url { get; set; }
        //public string attach1_url {get;set;}
        public string emoji { get; set; }
        public string from_admin { get; set; }
        public string source_act { get; set; }
        public string sourse_mid { get; set; }
    }
}

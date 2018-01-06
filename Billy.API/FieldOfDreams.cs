using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.API
{
    public class FieldOfDreams : Models.FieldOfDreams
    {
        int id;
        public FieldOfDreams(int idc)
        {
            id = idc;
        }

        Database.Methods method = new Database.Methods("FieldOfDreams");
        public override int Id
        {
            get => id;

        }

        public override string Answer => (string)method.GetFromId(id, "Answer");
        public override string Question => (string)method.GetFromId(id, "Question");
        public override string Proccess { get => (string)method.GetFromId(id, "Proccess");
            set => method.EditField(id,"Proccess", value); }
        public override long Creator => (long)method.GetFromId(id, "Creator");
        public override long DialogId { get => (long)method.GetFromId(id, "DialogId");
            set => method.EditField(id, "DialogId", value); }
        public override bool Complete
        {
            get => Convert.ToBoolean((long)method.GetFromId(id, "Complete"));
            set => method.EditField(id, "Complete", Convert.ToInt32(value));
        }
    }
}

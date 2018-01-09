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

        public static int New(string question, long creator)
        {
            var method = new Database.Methods("FieldOfDreams");
            var id = (long)method.GetFromId(228161, "Creator");
            string fields = @"`Id`, `Question`, `Answer`, `Creator`, `DialogId`, `Complete`, `Proccess`";

            string values = $@"'{id}', '{question}' , 'нет', '{creator}', '0', '0', '[][][][][][]'";
            method.Add(fields, values);
            method.EditField(228161, "Creator", id + 1);
            return Convert.ToInt32(id);
        }

        public static bool Is(int id)
        {
            var method = new Database.Methods("FieldOfDreams");
            return method.Check(id);
        }

        public override string Answer { get => (string)method.GetFromId(id, "Answer");
            set => method.EditField(id, "Answer", value); }
        public override string Question =>(string) method.GetFromId(id, "Question");
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
        public override int CountChar
        {
            get => Convert.ToInt32((long)method.GetFromId(id, "CountChar"));
            set => method.EditField(id, "CountChar", value);
        }
    }
}

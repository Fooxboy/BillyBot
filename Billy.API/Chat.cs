using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.API
{
    public class Chat :Models.Chat
    {
        long id;
        public Chat(long idc)
        {
            id = idc;
        }

        public Chat(long? idc)
        {
            id = idc.Value;
        }
        Database.Methods method = new Database.Methods("Chats");
        public override long Id
        {
            get
            {
                return id;
            }
        }

        public static void New(long id)
        {
            var method = new Database.Methods("Chats");
            string fields = @"`id`, `Name`, `AdminChat`";
            var chat = Data.GetVk().Messages.GetChat(id);
            string name = chat.Title;
            var admin = chat.AdminId;
            string values = $@"'{id}', '{name}' , '{admin}'";
            method.Add(fields, values);
        }

        public override string Name
        {
            get
            {
                return (string)method.GetFromId(id, "Name");
            }set
            {
                method.EditField(id, "Name", value);
            }
        }

        public static bool IsChat(long id)
        {
            Database.Methods method = new Database.Methods("Chats");
            return method.Check(id);
        }

        public override long AdminChat
        {
            get
            {
                return (long)method.GetFromId(id, "AdminChat");
            }set
            {
                method.EditField(id, "AdminChat", value);
            }
        }

        public override long AdminSave
        {
            get
            {
                return (long)method.GetFromId(id, "AdminSave");
            }set
            {
                method.EditField(id, "AdminSave", value);
            }
        }

        public override long Answer
        {
            get
            {
                return (long)method.GetFromId(id, "Answer");
            }set
            {
                method.EditField(id, "Answer", value);
            }
        }

        public override bool Blocked
        {
            get
            {
                return Convert.ToBoolean((long)method.GetFromId(id, "Blocked"));
            }set
            {
                long result = Convert.ToInt64(value);
                method.EditField(id, "Blocked", result);
            }
        }
    }
}

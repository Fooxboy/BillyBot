using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.API
{
    public class Bans : Models.Bans
    {
        long id;
        public Bans(long _id)
        {
            id = _id;
        }
        API.Database.Methods method = new Database.Methods("Bans");

        public static void New(Models.Params.BanAddParams ban)
        {
            var method = new Database.Methods("Bans");
            string fields = @"`Id`, `Time`, `From`, `Title`";
            string values = $@"'{ban.Id}', '{ban.Time}', '{ban.From}', '{ban.Title}'";
            method.Add(fields, values);
        }

        public static void Delete(long id)
        {
            var method = new Database.Methods("Bans");
            method.Delete(id);
        }

        public override long Id
        {
            get
            {
                return id;
            }set
            {
                throw new Exception("невозможно установить значение.");
            }
        }

        public override long Time
        {
            get
            {
                return (long)method.GetFromId(id, "Time");
            } set
            {
                method.EditField(id, "Time", value);
            }
        }

        public override long From
        {
            get
            {
                return (long)method.GetFromId(id, "From");
            } set
            {
                method.EditField(id, "From", value);
            }
        }

        public override string Title
        {
            get
            {
                return (string)method.GetFromId(id, "Title");
            }set
            {
                method.EditField(id, "Title", value);
            }
        }
    }
}

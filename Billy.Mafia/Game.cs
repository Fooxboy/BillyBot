using System;
using System.Collections.Generic;
using System.Text;
using Billy.API;

namespace Billy.Mafia
{
    public class Game:GameModel
    {
        int id;
        public Game(int idc)
        {
            id = idc;
        }

        Database.Methods method = new Database.Methods("Mafia");
        public override int Id
        {
            get
            {
                return id;
            }
        }

        public static bool Is(int id)
        {
            var method = new Database.Methods("Mafia");
            return method.Check(id);
        }

        public static int New(long groupId, long userCreate)
        {
            var method = new Database.Methods("Mafia");
            string fields = @"`Id`, `GroupId`, `FullPlayers`, `PlayPlayers`, `FullRoles`, `PlayRoles`, `UserCreate`";
            var id = (long)method.GetFromId(228161,"GroupId");
            string values = $@"'{id}', '{groupId}', '{userCreate} ' , '{userCreate} ', '0 ', '0 ', '{userCreate}'";
            method.Add(fields, values);
            method.EditField(228161, "GroupId", id + 1);
            return Convert.ToInt32(id);
        }

        public override long GroupId
        {
            get => (long)method.GetFromId(id, "GroupId");
            set => method.EditField(id, "GroupId", value);
        }

        public override List<long> FullPlayers
        {
            get
            {
                List<long> result = new List<long>();
                string[] ids = method.GetFromId(id, "FullPlayers").ToString().Split(' ');
                foreach(var id in ids) result.Add(Int64.Parse(id));
                return result;
            }set
            {
                string result = "";
                foreach (var id in value) result += $"{id} ";
                method.EditField(id, "FullPlayers", result);
            }
        }

        public override List<long> PlayPlayers
        {
            get
            {
                List<long> result = new List<long>();
                string[] ids = method.GetFromId(id, "PlayPlayers").ToString().Split(' ');
                foreach (var id in ids) result.Add(Int64.Parse(id));
                return result;
            }
            set
            {
                string result = "";
                foreach (var id in value) result += $"{id} ";
                method.EditField(id, "PlayPlayers", result);
            }
        }

        public override List<int> FullRoles
        {
            get
            {
                List<int> result = new List<int>();
                string[] ids = method.GetFromId(id, "FullRoles").ToString().Split(' ');
                foreach (var id in ids) result.Add(Int32.Parse(id));
                return result;
            }
            set
            {
                string result = "";
                foreach (var id in value) result += $"{id} ";
                method.EditField(id, "FullRoles", result);
            }
        }

        public override List<int> PlayRoles
        {
            get
            {
                List<int> result = new List<int>();
                string[] ids = method.GetFromId(id, "PlayRoles").ToString().Split(' ');
                foreach (var id in ids) result.Add(Int32.Parse(id));
                return result;
            }
            set
            {
                string result = "";
                foreach (var id in value) result += $"{id} ";
                method.EditField(id, "PlayRoles", result);
            }
        }

        public override long UserCreate
        {
            get => (long)method.GetFromId(id, "UserCreate");
        }

        public override bool isStart { get => (bool)method.GetFromId(id, "IsStart");
            set => method.EditField(id, "IsStart", value); }

        public override bool isEnd
        {
            get => (bool)method.GetFromId(id, "IsEnd");
            set => method.EditField(id, "IsEnd", value);
        }
    }
}

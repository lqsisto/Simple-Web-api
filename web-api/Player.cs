using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web_api
{

    public class Player
    {
        public Guid playerID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int level { get; set; }
        public bool IsBanned { get; set; }
        public DateTime CreationTime { get; set; }
        public List<Item> itemList { get; set; }

        public Player ()
        {
            itemList = new List<Item> ();
        }

    }

    public class NewPlayer
    {
        public string name { get; set; }
        public int level { get; set; }
    }

    public class ModifiedPlayer
    {
        public int Score { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace web_api
{
    public class InMemoryRepository : IRepositery
    {
        List<Player> playersList = new List<Player> ();

        public InMemoryRepository () { }

        public Task<Player> Get (Guid id)
        {
            foreach (Player p in playersList)
            {
                if (p.playerID == id)
                {
                    return Task.FromResult (p);
                }
            }
            return null;
        }
        public Task<Player[]> GetAll ()
        {
            return Task.FromResult (playersList.ToArray ());
        }
        public Task<Player> Create (Player player)
        {
            playersList.Add (player);

            return Task.FromResult (player);
        }
        public Task<Player> Modify (Guid id, ModifiedPlayer player)
        {
            foreach (Player p in playersList)
            {
                if (p.playerID == id)
                {
                    p.Score = player.Score;
                    return Task.FromResult (p);
                }
            }
            return null;
        }
        public Task<Player> Delete (Guid id)
        {
            foreach (Player p in playersList)
            {
                if (p.playerID == id)
                {
                    playersList.Remove (p);
                    return Task.FromResult (p);
                }
            }
            return null;
        }
        public Task<Item> GetItem (Guid playerID, Guid id)
        {
            foreach (Player p in playersList)
            {
                if (p.playerID == playerID)
                {
                    foreach (Item i in p.itemList)
                    {
                        if (i.ID == id)
                        {
                            return Task.FromResult (i);
                        }
                    }
                }
            }
            return Task.FromResult ((Item) null);
        }
        public Task<Item[]> GetAllItems ()
        {
            List<Item> allItems = new List<Item> ();
            foreach (Player p in playersList)
            {
                foreach (Item i in p.itemList)
                {
                    allItems.Add (i);
                }
            }
            return Task.FromResult (allItems.ToArray ());
        }
        public Task<Item> CreateItem (Guid playerID, Item Item)
        {
            foreach (Player p in playersList)
            {
                if (p.playerID == playerID)
                {
                    p.itemList.Add (Item);
                    return Task.FromResult (Item);
                }
            }
            return Task.FromResult ((Item) null);
        }

        public Task<Item> ModifyItem (Guid playerID, Guid itemID, ModifiedItem Item)
        {
            foreach (Player p in playersList)
            {
                if (playerID == p.playerID)
                {
                    foreach (Item i in p.itemList)
                    {
                        if (i.ID == itemID)
                        {
                            i.description = Item.description;
                            i.level = Item.level;
                            i.creationDate = Item.creationDate;

                            return Task.FromResult (i);
                        }
                    }
                }
            }

            return Task.FromResult ((Item) null);
        }
        public Task<Item> DeleteItem (Guid playerID, Guid id)
        {
            foreach (Player p in playersList)
            {
                if (p.playerID == playerID)
                {
                    foreach (Item i in p.itemList)
                    {
                        if (i.ID == id)
                        {
                            p.itemList.ToList ().Remove (i);
                            return Task.FromResult (i);
                        }

                    }

                }
            }
            return Task.FromResult ((Item) null);
        }
    }
}
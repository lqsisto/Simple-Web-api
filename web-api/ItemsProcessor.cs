using System;
using System.Threading.Tasks;

namespace web_api
{
    public class ItemsProcessor
    {
        IRepositery IR;

        public ItemsProcessor (IRepositery iFace)
        {
            IR = iFace;
        }

        public Task<Item> GetItem (Guid playerID, Guid id)
        {
            return IR.GetItem (playerID, id);
        }
        public Task<Item[]> GetAllItems ()
        {
            return IR.GetAllItems ();
        }
        public async Task<Item> CreateItem (Guid playerID, NewItem newItem)
        {
            Player player;
            player = await IR.Get (playerID);

            if (newItem.description == "Sword" && player.level < 3)
            {
                throw new WrongPlayerLevelEx ();
            }

            Item item = new Item ();
            item.level = newItem.level;
            item.creationDate = newItem.creationDate;
            item.description = newItem.description;
            item.ID = Guid.NewGuid ();

            return await IR.CreateItem (playerID, item);
        }
        public Task<Item> ModifyItem (Guid playerID, Guid itemID, ModifiedItem item)
        {
            return IR.ModifyItem (playerID, itemID, item);
        }

        public Task<Item> DeleteItem (Guid playerID, Guid itemID)
        {
            return IR.DeleteItem (playerID, itemID);
        }
    }
}
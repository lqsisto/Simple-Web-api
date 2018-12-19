using System;
using System.Threading.Tasks;

namespace web_api
{
    public interface IRepositery
    {
        Task<Player> Get (Guid id);
        Task<Player[]> GetAll ();
        Task<Player> Create (Player player);
        Task<Player> Modify (Guid id, ModifiedPlayer player);
        Task<Player> Delete (Guid id);

        Task<Item> GetItem (Guid playerID, Guid id);
        Task<Item[]> GetAllItems ();
        Task<Item> CreateItem (Guid playerID, Item item);
        Task<Item> ModifyItem (Guid playerID, Guid itemID, ModifiedItem item);
        Task<Item> DeleteItem (Guid playerID, Guid id);
    }
}
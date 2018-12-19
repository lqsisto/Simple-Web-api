using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace web_api
{
    [Route ("api/players/{playerID}/[controller]")]
    [WrongPlayerLevelException]
    [ApiController]
    public class ItemsController
    {
        ItemsProcessor _IP;

        public ItemsController (ItemsProcessor ip)
        {
            _IP = ip;
        }

        [HttpGet ("{ID}")]
        public Task<Item> Get (Guid playerID, Guid id)
        {
            return _IP.GetItem (playerID, id);
        }

        [HttpGet]
        public Task<Item[]> GetAll ()
        {
            return _IP.GetAllItems ();
        }

        [HttpPost]
        public Task<Item> Create (Guid playerID, [FromBody] NewItem newItem)
        {
            return _IP.CreateItem (playerID, newItem);
        }

        [HttpPatch ("{ID}")]
        public Task<Item> Modify (Guid playerID, Guid id, [FromBody] ModifiedItem mItem)
        {
            return _IP.ModifyItem (playerID, id, mItem);
        }

        [HttpDelete ("{ID}")]
        public Task<Item> Delete (Guid playerID, [FromBody] Guid id)
        {
            return _IP.DeleteItem (playerID, id);
        }
    }
}
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace web_api {
    [Route ("api/[controller]")]
    [ApiController]
    public class PlayersController {

        PlayersProcessor PP;

        public PlayersController (PlayersProcessor PPR) {
            PP = PPR;
        }

        [HttpGet ("{id}")]
        public Task<Player> Get (Guid id) {
            return PP.Get (id);
        }

        [HttpGet]
        public Task<Player[]> GetAll () {
            return PP.GetAll ();
        }

        [HttpPost]
        public Task<Player> Create ([FromBody] NewPlayer player) {
            return PP.Create (player);
        }

        [HttpPatch ("{id}")]
        public Task<Player> Modify (Guid id, [FromBody] ModifiedPlayer player) {
            return PP.Modify (id, player);
        }

        [HttpDelete ("{id}")]
        public Task<Player> Delete (Guid id) {
            return PP.Delete (id);
        }
    }
}
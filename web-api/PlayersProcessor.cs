using System;
using System.Threading.Tasks;

namespace web_api
{
    public class PlayersProcessor
    {

        IRepositery IR;
        public PlayersProcessor (IRepositery ir)
        {
            IR = ir;
        }

        public Task<Player> Get (Guid id)
        {
            return IR.Get (id);
        }
        public Task<Player[]> GetAll ()
        {
            Console.WriteLine ("vidu");
            return IR.GetAll ();

        }
        public Task<Player> Create (NewPlayer player)
        {
            Player p = new Player ();
            p.Name = player.name;
            p.level = player.level;
            p.playerID = Guid.NewGuid ();
            p.CreationTime = DateTime.Now;
            return IR.Create (p);
        }
        public Task<Player> Modify (Guid id, ModifiedPlayer player)
        {
            return IR.Modify (id, player);
        }
        public Task<Player> Delete (Guid id)
        {
            return IR.Delete (id);
        }
    }
}
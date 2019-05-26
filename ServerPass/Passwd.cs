using Smod2.API;
using Smod2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerPass
{
    class Passwd : ICommandHandler
    {
        // COPIED SHIT !! !
        private readonly ServerPass plugin;

        public Passwd(ServerPass plugin) => this.plugin = plugin;

        public string GetCommandDescription()
        {
            return "Password Command";
        }

        public string GetUsage()
        {
            return "passwd <password>";
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
            // Registers the player.

            Player p = sender as Player;

            // Checks if they are already verified.

            if (PlayerJoinHandler.verfied.Contains(p))
                return new string[] { "You are already verified!" };

            // Checks the password

            if (args[0] != null)
                if (args[0] == plugin.GetConfigString("sp_password"))
                {
                    PlayerJoinHandler.verfied.Add(p);
                    return new string[] { "You are verified!" };
                }
                else
                    return new string[] { "Wrong password!" };
            else
                return new string[] { "No password specified!" };
        }
    }
}

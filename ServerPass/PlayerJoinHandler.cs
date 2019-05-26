using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerPass
{
    class PlayerJoinHandler : IEventHandlerPlayerJoin, IEventHandlerWaitingForPlayers
    {
        // Vefified players

        public static List<Player> verfied = new List<Player>();

        // the copied shit bois!

        private readonly ServerPass plugin;

        public PlayerJoinHandler(ServerPass plugin) => this.plugin = plugin;

        // Simple shit right here.

        public void OnPlayerJoin(PlayerJoinEvent ev)
        {
            if (!verfied.Contains(ev.Player))
            {
                ev.Player.PersonalBroadcast(10, "<color=red>Look in your console!</color>", true);
                ev.Player.SendConsoleMessage("You have 10 seconds to type the command `passwd <password>` (replace password with the actual password) to enter the server!", "red");
                new Thread(() =>
                {
                    Thread.Sleep(10000);
                    if (!verfied.Contains(ev.Player))
                        ev.Player.Ban(0);
                }).Start();
            }
        }

        // Check if the plugin should enable.

        public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
        {
            if (!plugin.GetConfigBool("sp_status"))
                plugin.PluginManager.DisablePlugin(plugin);
            // If the default password is present that's a no no
            if (plugin.GetConfigString("sp_password") == "none")
            {
                plugin.Info("YOUR PASSWORD IS `none`; PLEASE CHANGE THE DEFAULT PASSWORD!");
                plugin.Info("This plugin will be disabled until you pick a better password!");
                // So disable the shit ass plugin
                plugin.PluginManager.DisablePlugin(plugin);
            }
        }
    }
}

using Smod2;
using Smod2.Attributes;
using Smod2.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerPass
{
    [PluginDetails(
        author = "Kade",
        name = "Server Pass",
        description = "Protect your server with a password!",
        id = "kade.sp",
        version = "1.0",
        SmodMajor = 3,
        SmodMinor = 4,
        SmodRevision = 1
        )]
    public class ServerPass : Plugin
    {
        public override void OnDisable()
        {
            Info("Disabled!");
        }

        public override void OnEnable()
        {
            Info("\n--------------------\nPlugin created by Kade\nS e r v e r  P a s s\nProtect your server with a password!\n--------------------");
        }

        public override void Register()
        {

            // Add configs.

            AddConfig(new ConfigSetting("sp_password", "none", true, "The password to the server."));
            AddConfig(new ConfigSetting("sp_status", true, true, "If the plugin should activate."));

            // Add the player event.

            AddEventHandlers(new PlayerJoinHandler(this));

            // Add the command

            AddCommand("passwd", new Passwd(this));

        }
    }
}

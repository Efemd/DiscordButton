using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace DiscordButton
{
    public class DiscordButton : RocketPlugin<Configuration>
    {
        protected override void Load()
        {
            U.Events.OnPlayerConnected += Connected;
            UnturnedPlayerEvents.OnPlayerDeath += Death;
            UnturnedPlayerEvents.OnPlayerRevive += Revive;
            EffectManager.onEffectButtonClicked += ButtonClicked;
        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Connected;
            UnturnedPlayerEvents.OnPlayerDeath -= Death;
            UnturnedPlayerEvents.OnPlayerRevive -= Revive;
            EffectManager.onEffectButtonClicked -= ButtonClicked;
        }

        private void Revive(UnturnedPlayer player, Vector3 position, byte angle)
        {
            EffectManager.sendUIEffect(Configuration.Instance.EffectID, 101, player.SteamPlayer().transportConnection, true);
        }

        private void Death(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            EffectManager.askEffectClearByID(Configuration.Instance.EffectID, player.SteamPlayer().transportConnection);
        }

        private void ButtonClicked(Player caller, string buttonName)
        {
            if (buttonName == "Discord")
            {
                caller.sendBrowserRequest(Configuration.Instance.Description, Configuration.Instance.URL);
            }
        }

        private void Connected(UnturnedPlayer player)
        {
            EffectManager.sendUIEffect(Configuration.Instance.EffectID, 101, player.SteamPlayer().transportConnection, true);
        }
    }
}

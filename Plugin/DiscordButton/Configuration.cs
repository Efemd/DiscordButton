using Rocket.API;

namespace DiscordButton
{
    public class Configuration : IRocketPluginConfiguration
    {
        public ushort EffectID;
        public string Description;
        public string URL;
        public void LoadDefaults()
        {
            EffectID = 10300;
            Description = "Description";
            URL = "URL";
        }
    }
}
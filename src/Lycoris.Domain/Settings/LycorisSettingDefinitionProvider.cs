using Volo.Abp.Settings;

namespace Lycoris.Settings
{
    public class LycorisSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(LycorisSettings.MySetting1));
        }
    }
}

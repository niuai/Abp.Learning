using Volo.Abp.Settings;

namespace Jiabin.Settings
{
    public class JiabinSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(JiabinSettings.MySetting1));
        }
    }
}

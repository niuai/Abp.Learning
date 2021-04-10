using Lycoris.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lycoris.Permissions
{
    public class LycorisPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(LycorisPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(LycorisPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LycorisResource>(name);
        }
    }
}

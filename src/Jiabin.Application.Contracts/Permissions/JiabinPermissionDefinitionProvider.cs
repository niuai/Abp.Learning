using Jiabin.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Jiabin.Permissions
{
    public class JiabinPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(JiabinPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(JiabinPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<JiabinResource>(name);
        }
    }
}

using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Jiabin.Web.Menus
{
    public class JiabinMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //if (!MultiTenancyConsts.IsEnabled)
            //{
            //    var administration = context.Menu.GetAdministration();
            //    administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            //}

            //var l = context.GetLocalizer<JiabinResource>();

            //context.Menu.Items.Insert(0, new ApplicationMenuItem("Jiabin.Home", l["Menu:Home"], "~/"));
        }
    }
}

using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Jiabin.Pages
{
    public class Index_Tests : JiabinWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}

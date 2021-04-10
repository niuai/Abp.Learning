using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Lycoris.Pages
{
    public class Index_Tests : LycorisWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}

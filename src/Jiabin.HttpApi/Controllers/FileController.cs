using Microsoft.AspNetCore.Mvc;

namespace Jiabin.Controllers
{
    public class FileController : JiabinController
    {
        public IActionResult Get()
        {
            return Redirect("http://a3.att.hudong.com/14/75/01300000164186121366756803686.jpg");
        }
    }
}

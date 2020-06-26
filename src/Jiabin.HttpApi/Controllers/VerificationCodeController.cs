using Jiabin.VerificationCode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Jiabin.Controllers
{
    public class VerificationCodeController : JiabinController
    {
        private static readonly string _verificationCodeCacheFormat = "vcode_cache_{0}";

        private readonly IVerificationCodeAppService _verificationCodeAppService;
        private IMemoryCache _memoryCache;

        public VerificationCodeController(IVerificationCodeAppService verificationCodeAppService, IMemoryCache memoryCache)
        {
            _verificationCodeAppService = verificationCodeAppService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult ValidateCode()
        {
            var imgBytes = _verificationCodeAppService.Create(out string code);
            code = code.ToLower(); // 验证码不分大小写
            var token = Guid.NewGuid().ToString();
            var cacheKey = string.Format(_verificationCodeCacheFormat, token);

            _memoryCache.Set(cacheKey, code, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10)));

            Response.Cookies.Append("validatecode", token);
            return File(imgBytes, @"image/png");
        }

        [HttpPost]
        [Route("Verify")]
        public bool VerifyUserInputCode(string userToken, string userVerCode)
        {
            var cacheKey = string.Format(_verificationCodeCacheFormat, userToken.ToString());

            if (!_memoryCache.TryGetValue(cacheKey, out string vCode))
                return false;
            if (vCode.ToLower() != userVerCode.ToLower())
                return false;

            _memoryCache.Remove(cacheKey);

            return true;
        }
    }
}

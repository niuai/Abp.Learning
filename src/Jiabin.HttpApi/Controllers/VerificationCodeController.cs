using Jiabin.VerificationCode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Jiabin.Controllers
{
    public class VerificationCodeController : JiabinController
    {
        private readonly string _verificationCodeCacheFormat = "vcode_cache_{0}";
        private readonly IVerificationCodeAppService _verificationCodeAppService;
        private readonly IMemoryCache _memoryCache;

        public VerificationCodeController(IVerificationCodeAppService verificationCodeAppService, IMemoryCache memoryCache)
        {
            _verificationCodeAppService = verificationCodeAppService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult ValidateCode()
        {
            var imgBytes = _verificationCodeAppService.Create(out string code);
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
            var cacheKey = string.Format(_verificationCodeCacheFormat, userToken);

            if (!_memoryCache.TryGetValue(cacheKey, out string vCode))
                throw new BizException("验证码已失效，请重新输入新的验证码");
            if (vCode.ToLower() != userVerCode.ToLower())   // 验证码不分大小写
                return false;

            _memoryCache.Remove(cacheKey);

            return true;
        }
    }
}

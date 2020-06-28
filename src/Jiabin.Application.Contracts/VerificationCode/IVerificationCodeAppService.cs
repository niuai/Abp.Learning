using Volo.Abp.Application.Services;

namespace Jiabin.VerificationCode
{
    public interface IVerificationCodeAppService : IApplicationService
    {
        /// <summary>
        /// 生成随机字符串的图像文件
        /// </summary>
        /// <param name="code">验证码字符串</param>
        /// <param name="length">生成位数（默认4位）</param>
        /// <returns>图像的字节数组</returns>
        byte[] Create(out string code, int length = 4);

        byte[] Create2(out string code, int length = 4);

        byte[] Create3(out string code, int length = 4);
    }
}

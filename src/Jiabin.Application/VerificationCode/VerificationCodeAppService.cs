using SkiaSharp;
using System;
using System.IO;
using System.Linq;
using Volo.Abp.Application.Services;

namespace Jiabin.VerificationCode
{
    public class VerificationCodeAppService : ApplicationService, IVerificationCodeAppService
    {
        /// <inheritdoc />
        public byte[] Create(out string code, int length = 4)
        {
            /*
             SkiaSharp 绘图 API，参考：https://docs.microsoft.com/en-us/dotnet/api/SkiaSharp?view=skiasharp-1.60.3
             博客园：https://www.cnblogs.com/dayang12525/p/10006957.html、https://www.cnblogs.com/DDSkay/p/9032931.html
            */
            code = RndomStr(length);
            var codeChar = code.ToList();
            var bmp = new SKBitmap(80, 30);
            using var canvas = new SKCanvas(bmp);
            canvas.DrawColor(SKColors.White); // 背景色

            using (var sKPaint = new SKPaint())
            {
                sKPaint.TextSize = 16; // 字体大小
                sKPaint.IsAntialias = true; // 开启抗锯齿
                sKPaint.Typeface = SKTypeface.FromFamilyName("微软雅黑", SKFontStyle.Bold); // 字体

                var size = new SKRect();
                sKPaint.MeasureText(codeChar[0].ToString(), ref size); // 计算文字宽度以及高度

                var temp = (bmp.Width / 4 - size.Size.Width) / 2;
                var temp1 = bmp.Height - (bmp.Height - size.Size.Height) / 2;
                var random = new Random();

                for (int i = 0; i < 4; i++)
                {
                    sKPaint.Color = new SKColor((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
                    canvas.DrawText(codeChar[i].ToString(), temp + 20 * i, temp1, sKPaint); // 画文字
                }
                for (int i = 0; i < 5; i++)
                {
                    sKPaint.Color = new SKColor((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
                    canvas.DrawLine(random.Next(0, 40), random.Next(1, 29), random.Next(41, 80), random.Next(1, 29), sKPaint); // 干扰线
                }
            }

            using var img = SKImage.FromBitmap(bmp); // 页面展示图片
            using var p = img.Encode();

            return p.ToArray();
        }

        /// <summary>
        /// 生成指定长度的随机字符串
        /// </summary>
        /// <param name="codeLength">字符串的长度</param>
        /// <returns>返回随机数字符串</returns>
        private string RndomStr(int codeLength)
        {
            // 组成字符串的字符集合 0-9 数字、大小写字母
            var chars = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,P,Q,R,S,T,U,V,W,X,Y,Z";

            var charArray = chars.Split(new char[] { ',' });
            var code = "";
            var temp = -1; // 记录上次随机数值，尽量避避免生产几个一样的随机数
            var rand = new Random();

            // 采用一个简单的算法以保证生成随机数的不同
            for (int i = 1; i < codeLength + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks)); // 初始化随机类
                }
                int t = rand.Next(61);
                if (temp == t)
                {
                    return RndomStr(codeLength); // 如果获取的随机数重复，则递归调用
                }
                temp = t; // 把本次产生的随机数记录起来
                code += charArray[t]; // 随机数的位数加一
            }

            return code;
        }
    }
}

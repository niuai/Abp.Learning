using SkiaSharp;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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

        public byte[] Create2(out string validateNum, int length = 4)
        {
            byte[] result;
            validateNum = RndomStr(length);
            // 生成BitMap图像
            var image = new Bitmap(validateNum.Length * 12 + 12, 22);
            var g = Graphics.FromImage(image);

            try
            {
                // 生成随机生成器
                var random = new Random();
                // 清空图片背景
                g.Clear(Color.White);
                // 画图片的背景噪音线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, x2, y1, y2);
                }
                var font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                var brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateNum, font, brush, 2, 2);
                // 画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));

                }
                // 画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                var ms = new MemoryStream();
                // 将图像保存到指定流
                image.Save(ms, ImageFormat.Bmp);
                result = ms.GetBuffer();
                ms.Close();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }

            return result;
        }

        public byte[] Create3(out string chkCode, int length = 4)
        {
            var codeW = 80;
            var codeH = 30;
            var fontSize = 16;
            chkCode = RndomStr(4);
            // 颜色列表，用于验证码、噪线、噪点 
            var color = new[] { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
            // 字体列表，用于验证码 
            var font = new[] { "Times New Roman" };
            var rnd = new Random();
            // 创建画布
            var bmp = new Bitmap(codeW, codeH);
            var g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            // 画噪线 
            for (int i = 0; i < 3; i++)
            {
                var x1 = rnd.Next(codeW);
                var y1 = rnd.Next(codeH);
                var x2 = rnd.Next(codeW);
                var y2 = rnd.Next(codeH);
                var clr = color[rnd.Next(color.Length)];
                g.DrawLine(new Pen(clr), x1, y1, x2, y2);
            }
            // 画验证码字符串 
            for (int i = 0; i < chkCode.Length; i++)
            {
                var fnt = font[rnd.Next(font.Length)];
                var ft = new Font(fnt, fontSize);
                var clr = color[rnd.Next(color.Length)];
                g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), (float)i * 18, 0);
            }
            // 将验证码图片写入内存流，并将其以 "image/Png" 格式输出 
            var ms = new MemoryStream();
            try
            {
                bmp.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                g.Dispose();
                bmp.Dispose();
            }
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

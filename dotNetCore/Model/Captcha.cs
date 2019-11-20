using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Model
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class Captcha
    {
        /// <summary>
        /// 验证码图片
        /// </summary>
        public Bitmap validatePicture = null;
        /// <summary>
        /// 验证码
        /// </summary>
        public string validateNum = "";

        /// <summary>
        /// 获得n位验证码bytes
        /// </summary>
        /// <param name="num">验证码位数</param>
        /// <returns>返回num位的验证码图片</returns>
        public byte[] GetValidateBytes(int num)
        {
            MemoryStream memoryStream = new MemoryStream();
            GetValidate(num).Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = memoryStream.GetBuffer();
            memoryStream.Close();
            return bytes;
        }

        /// <summary>
        /// 获得n位验证码
        /// </summary>
        /// <param name="num">验证码位数</param>
        /// <returns>返回num位的验证码图片</returns>
        public Bitmap GetValidate(int num)
        {
            return CreateImage(CreateRandomNum(num));
        }

        /// <summary>
        /// 获得n位验证码
        /// </summary>
        /// <param name="NumCount">位数</param>
        /// <returns>验证码字符串</returns>
        public string CreateRandomNum(int NumCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomNum = "";
            int temp = -1;//避免重复随机数
            Random random = new Random();
            for (int i = 0; i < NumCount; i++)
            {
                if (temp != -1)
                {
                    random = new Random(i * temp * DateTime.Now.Millisecond);
                }
                int t = random.Next(35);
                if (t == temp)
                {
                    return CreateRandomNum(NumCount);
                }
                temp = t;
                RandomNum += allCharArray[t];
            }
            validateNum = RandomNum;
            return RandomNum;
        }

        /// <summary>
        /// 获得验证码图片bytes
        /// </summary>
        /// <param name="validateNum">验证码字符串</param>
        /// <returns>返回验证码图片</returns>
        public byte[] CreateImageBytes(string validateNum)
        {
            MemoryStream memoryStream = new MemoryStream();
            CreateImage(validateNum).Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = memoryStream.GetBuffer();
            memoryStream.Close();
            return bytes;
        }

        /// <summary>
        /// 获得验证码图片
        /// </summary>
        /// <param name="validateNum">验证码字符串</param>
        /// <returns>返回验证码图片</returns>
        public Bitmap CreateImage(string validateNum)
        {
            if (validateNum == null || validateNum.Trim() == string.Empty)
            {
                return null;
            }
            Color[] colors = new Color[] { Color.Silver, Color.SlateGray, Color.Wheat, Color.YellowGreen, Color.Pink };
            Bitmap image = new Bitmap(100, 40);
            Graphics graphics = Graphics.FromImage(image);
            try
            {
                Random random = new Random();
                graphics.Clear(Color.White);//清空背景色
                //绘制背景
                for (int i = 0; i < 15; i++)
                {
                    int RandomColor = random.Next(colors.Length - 1);
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    graphics.DrawLine(new Pen(colors[RandomColor]), x1, y1, x2, y2);
                }
                //绘制文字
                Font font = new Font("Arial", 20, FontStyle.Bold | FontStyle.Strikeout | FontStyle.Italic);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.DarkBlue, Color.Red, 1.2f, true);
                graphics.DrawString(validateNum, font, brush, 2, 2);
                //绘制前景
                for (int i = 0; i < 25; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //绘制边框
                graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                graphics.Dispose();
            }
            validatePicture = image;
            return image;
        }


        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns>验证码</returns>
        public string GetValidateNum()
        {
            return validateNum;
        }

        /// <summary>
        /// 获得验证码图片bytes
        /// </summary>
        /// <returns>返回验证码图片</returns>
        public byte[] GetValidatePictureBytes()
        {
            MemoryStream memoryStream = new MemoryStream();
            validatePicture.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = memoryStream.GetBuffer();
            memoryStream.Close();
            return bytes;
        }

        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <returns>验证码图片</returns>
        public Bitmap GetValidatePicture()
        {
            return validatePicture;
        }

        /// <summary>
        /// 更换验证码
        /// </summary>
        /// <returns>更换验证码成功与否</returns>
        public bool ChangeValidate()
        {
            Bitmap bitmap = validatePicture;
            if (GetValidate(4) != bitmap)
            {
                return true;
            }
            return false;
        }
    }
}

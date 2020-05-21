using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WR_EAMS
{
    public partial class Captcha : System.Web.UI.Page
    {

        /*
        一、画图步骤：
         *
            1、System.Drawing.Bitmap bmp = new System.Drawing.Bitmap (长度,高度);
            2、Graphics g = Graphics.FromImage(bmp);//得到长度及高度的值
            3、g.Clear(Color.White);//清空为白色

        二、点、线、矩形及字体：
         * 
            画点：bmp.SetPixel(起点x,起点y,颜色);
            画线：g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);//DrawLine(颜色,起点x,起点y,终点x,终点y);
            画矩形：g.DrawRectangle(new Pen(颜色), 起点x,起点y,宽度,高度);
            字体：Font font = new System.Drawing.Font("字体",字号, (字体样式));
                1、渐变色：LinearGradientBrush 名=new 渐变界限,起始色,终止色,浅变层数,开关"true/false")
                2、画文字：g.DrawString(“字符串”,字体样式,渐变色,x坐标,y坐标);

        三、写入Cookie
         * Response.Cookies.Add(new HttpCookie("Cookies名字", 写入内容));

        四、读取Cookie
         *
            HttpCookie hc = Request.Cookies["Cookies名"];
            string 名字=Server.HtmlEncode(hc.Value);     
        */

        private string uNum()//生成数字及字母的验证码
        {
            int num;
            char code;
            string uCode = "";// String.Empty;
            Random r = new Random();
            for (int i = 0; i < 5; i++)//定义验证码长度
            {
                num = r.Next();//返回一个小于指定最大数的非负随机数
                if (num % 2 == 0)
                    code = (char)('0' + (char)(num % 10));
                else
                    code = (char)('A' + (char)(num % 26));
                uCode += code.ToString();
            }
            Response.Cookies.Add(new HttpCookie("AutoCode", uCode));
            return uCode;
        }
        private void uImg(string uStr)//画图像及线条
        {
            if (uStr == null || uStr.Trim() == String.Empty)//如果传入的参数为空
                return;//则返回
            Bitmap bmp = new Bitmap((int)Math.Ceiling((uStr.Length * 14.5)), 22);//Bitmap(长度,高度)
            Graphics g = Graphics.FromImage(bmp);//得到长度及高度的值
            try
            {
                //生成随机生成器
                Random r = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的背景噪音线
                for (int i = 0; i < 2; i++)
                {
                    int x1 = r.Next(bmp.Width);
                    int x2 = r.Next(bmp.Width);
                    int y1 = r.Next(bmp.Height);
                    int y2 = r.Next(bmp.Height);
                    g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);//DrawLine颜色,
                }
                Font font = new System.Drawing.Font("黑体", 14, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(0, 0, bmp.Width, bmp.Height), Color.Blue, Color.DarkRed, 2, true);
                g.DrawString(uStr, font, lgb, 2, 2);
                //画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = r.Next(bmp.Width);
                    int y = r.Next(bmp.Height);
                    bmp.SetPixel(x, y, Color.FromArgb(r.Next()));//划点
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, bmp.Width - 1, bmp.Height - 1);
                MemoryStream ms = new MemoryStream();//创建内存流
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);//指定图像保存格式
                Response.ClearContent();//清空缓冲区内容
                Response.ContentType = "Image/Gif";//输出图像格式
                Response.BinaryWrite(ms.ToArray());//写入HTTP输出流
            }
            finally
            {
                g.Dispose();//释放资源
                bmp.Dispose();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            uImg(uNum());
        }

    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace Vision.FunctionConfig
{
    public class OCRFunctionClass
    {

        /// <summary>
        /// 根据图片路径返回图片的字节流byte[]
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <returns>返回的字节流</returns>
        public static byte[] GetImageByte(string imagePath)
        {
            FileStream files = new FileStream(imagePath, FileMode.Open);
            byte[] imgByte = new byte[files.Length];
            files.Read(imgByte, 0, imgByte.Length);
            files.Close();
            return imgByte;
        }
        /// <summary>
        /// ByteArrayToHexString
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] data)
        {

            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            return sb.ToString().ToUpper();
        }


        //    public void GeneralBasicDemo()
        //    {

        //        // 设置APPID/AK/SK
        //        var APP_ID = "你的 App ID";
        //        var API_KEY = "你的 Api Key";
        //        var SECRET_KEY = "你的 Secret Key";

        //        var client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
        //        client.Timeout = 60000;  // 修改超时时间


        //        var image = File.ReadAllBytes("图片文件路径");
        //        // 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
        //        var result = client.GeneralBasic(image);
        //        Console.WriteLine(result);
        //        // 如果有可选参数
        //        var options = new Dictionary<string, object>{
        //    {"language_type", "CHN_ENG"},
        //    {"detect_direction", "true"},
        //    {"detect_language", "true"},
        //    {"probability", "true"}
        //};
        //        // 带参数调用通用文字识别, 图片参数为本地图片
        //        result = client.GeneralBasic(image, options);
        //        Console.WriteLine(result);
        //    }
        //    public void GeneralBasicUrlDemo()
        //    {

        //        // 设置APPID/AK/SK
        //        var APP_ID = "你的 App ID";
        //        var API_KEY = "你的 Api Key";
        //        var SECRET_KEY = "你的 Secret Key";

        //        var client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
        //        client.Timeout = 60000;  // 修改超时时间

        //        var url = "http//www.x.com/sample.jpg";

        //        // 调用通用文字识别, 图片参数为远程url图片，可能会抛出网络等异常，请使用try/catch捕获
        //        var result = client.GeneralBasicUrl(url);
        //        Console.WriteLine(result);
        //        // 如果有可选参数
        //        var options = new Dictionary<string, object>{
        //    {"language_type", "CHN_ENG"},
        //    {"detect_direction", "true"},
        //    {"detect_language", "true"},
        //    {"probability", "true"}
        //};
        //        // 带参数调用通用文字识别, 图片参数为远程url图片
        //        result = client.GeneralBasicUrl(url, options);
        //        Console.WriteLine(result);
        //    }
        /// <summary>
        /// 字符串转化为byte数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StringTobyte(string str)
        {

            Byte[] ByteList = System.Text.Encoding.Default.GetBytes(str);
            return ByteList;
        }

        /// <summary>
        /// 图像灰度化
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap ToGray(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //获取该点的像素的RGB的颜色
                    Color color = bmp.GetPixel(i, j);
                    //利用公式计算灰度值
                    int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    Color newColor = Color.FromArgb(gray, gray, gray);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            return bmp;
        }

        /// <summary>
        /// 图片背景改为黑白
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Bitmap ConvertToGrayscale(Bitmap source)
        {
            Bitmap bm = new Bitmap(source.Width, source.Height);
            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    Color c = source.GetPixel(x, y);
                    int luma = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                    bm.SetPixel(x, y, Color.FromArgb(luma, luma, luma));
                }
            }
            return bm;
        }
        /// <summary>
        /// 二值化
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap ConvertTo1Bpp1(Bitmap bmp)
        {
            int average = 0;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    average += color.B;
                }
            }
            average = (int)average / (bmp.Width * bmp.Height);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //获取该点的像素的RGB的颜色
                    Color color = bmp.GetPixel(i, j);
                    int value = 255 - color.B;
                    Color newColor = value > average ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            return bmp;
        }

        /// <summary>
        /// 图像二值化2
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap ConvertTo1Bpp2(Bitmap img)
        {
            int w = img.Width;
            int h = img.Height;
            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format1bppIndexed);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite,

                 PixelFormat.Format1bppIndexed);
            for (int y = 0; y < h; y++)
            {
                byte[] scan = new byte[(w + 7) / 8];
                for (int x = 0; x < w; x++)
                {
                    Color c = img.GetPixel(x, y);
                    if (c.GetBrightness() >= 0.5) scan[x / 8] |= (byte)(0x80 >> (x % 8));
                }
                Marshal.Copy(scan, 0, (IntPtr)((int)data.Scan0 + data.Stride * y), scan.Length);
            }
            return bmp;
        }



        /// <summary>
        /// 获取某目录下的所有文件(包括子目录下文件)的数量
        /// </summary>
        /// <param name="srcPath"></param>
        /// <returns></returns>
        public static int GetFileNum(string srcPath)
        {
            int fileNum = 0;
            try
            {

                string[] fileList = System.IO.Directory.GetFileSystemEntries(srcPath);
                foreach (string file in fileList)
                {
                    if (System.IO.Directory.Exists(file))
                        GetFileNum(file);
                    else
                        fileNum++;
                }

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
            return fileNum;
        }



        /// <summary>
        /// 删除文件夹里的所有文件
        /// </summary>
        /// <param name="srcPath"></param>
        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
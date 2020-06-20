using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoModelMatching
{
    public partial class Form1 : Form
    {

        enum IS_DEPTH
        {
            IS_DEPTH_8U = 0,
            IS_DEPTH_8S = 1,
            IS_DEPTH_16S = 2,
            IS_DEPTH_32S = 3,
            IS_DEPTH_32F = 4,
            IS_DEPTH_64F = 5,
        };

        enum IS_RET
        {
            IS_RET_OK,
            IS_RET_ERR_OUTOFMEMORY,
            IS_RET_ERR_STACKOVERFLOW,
            IS_RET_ERR_NULLREFERENCE,
            IS_RET_ERR_ARGUMENTOUTOFRANGE,
            IS_RET_ERR_PARAMISMATCH,
            IS_RET_ERR_DIVIDEBYZERO,
            IS_RET_ERR_INDEXOUTOFRANGE,
            IS_RET_ERR_NOTSUPPORTED,
            IS_RET_ERR_OVERFLOW,
            IS_RET_ERR_FILENOTFOUND,
            IS_RET_ERR_UNKNOWN
        };


        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct TMatrix
        {
            public int Width;
            public int Height;
            public int WidthStep;
            public int Channel;
            public int Depth;
            public byte* Data;
            public int Reserved;

            public TMatrix(int Width, int Height, int WidthStep, int Depth, int Channel, byte* Scan0)
            {
                this.Width = Width;
                this.Height = Height;
                this.WidthStep = WidthStep;
                this.Depth = Depth;
                this.Channel = Channel;
                this.Data = Scan0;
                this.Reserved = 0;
            }
        };

        public Form1()
        {
            InitializeComponent();
        }
        Bitmap SrcBmp, DstBmp;
        TMatrix SrcImg, DestImg;

        Bitmap SuccessBmp;
        Bitmap FaildBmp;


        /// <summary>
        /// ini方法类
        /// </summary>
        INIClassFunction ini = new INIClassFunction();


        /// <summary>
        /// 最大相似度
        /// </summary>
        double MaxsImilarity = 0;
        /// <summary>
        /// 最小相似度
        /// </summary>
        double MInImilarity = 0;

        [DllImport("ImageProcessing.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe private static extern IS_RET MatchTemplate(ref TMatrix Src, ref TMatrix Template, ref TMatrix* Dest);

        [DllImport("ImageProcessing.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern IS_RET MinMaxLoc(ref TMatrix Src, ref int Min_PosX, ref int Min_PosY, ref int Max_PosX, ref int Max_PosY);

        [DllImport("ImageProcessing.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe private static extern IS_RET IS_FreeMatrix(TMatrix** DstImg);



        private void Form1_Load(object sender, EventArgs e)
        {

            //'判断程序是否打开并只允许一个软件运行
            Process[] _processes = Process.GetProcessesByName("PhotoModelMatching");
            if (_processes.Length > 1)
            {
                Process.GetProcessById(Process.GetCurrentProcess().Id).Kill();
            }

            ///m_img
            SrcBmp = (Bitmap)PicSrc.Image;
            ///d_img
            DstBmp = (Bitmap)PicDest.Image;
        }

        private void bn_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap files (*.Bitmap)|*.Bmp|Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
            saveFileDialog.FilterIndex = 3;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 1)
                    DstBmp.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                else if (saveFileDialog.FilterIndex == 2)
                    DstBmp.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                else if (saveFileDialog.FilterIndex == 3)
                    DstBmp.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        private void bn_check_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files(*.*) |*.*|Bitmap files (*.Bitmap)|*.Bmp|Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap Bmp = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                DstBmp = (Bitmap)Bmp.Clone();
                Bmp.Dispose();
                PicDest.Image = DstBmp;

            }
        }

        private void bn_setSuccess_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files(*.*) |*.*|Bitmap files (*.Bitmap)|*.Bmp|Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap Bmp = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                SuccessBmp = (Bitmap)Bmp.Clone();
                SrcBmp = SuccessBmp;
                Bmp.Dispose();
                PicSrc.Image = SuccessBmp;

                var bit1 = new Bitmap(SuccessBmp);
                string Success_picturePath = Path.GetFullPath("ImgConfig");
                string SuccessTimestr = "\\Success" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".png";
                Success_picturePath += SuccessTimestr;
                bit1.Save(Success_picturePath);
                ini.IniWriteValue("ModelImgPath", "SuccessPath", SuccessTimestr);

            }
        }

        private void bn_setFaild_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files(*.*) |*.*|Bitmap files (*.Bitmap)|*.Bmp|Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap Bmp = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                FaildBmp = (Bitmap)Bmp.Clone();
                Bmp.Dispose();
                PicSrc1.Image = FaildBmp;

                var bit1 = new Bitmap(FaildBmp);
                string FaildBmp_picturePath = Path.GetFullPath("ImgConfig");
                string FaildTimestr = "\\Faild" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".png";
                FaildBmp_picturePath += FaildTimestr;
                bit1.Save(FaildBmp_picturePath);
                ini.IniWriteValue("ModelImgPath", "FaildPath", FaildTimestr);
            }
        }

        unsafe private void bn_operate_Click(object sender, EventArgs e)
        {

            try
            {
                int Min_PosX = 0, Min_PosY = 0, Max_PosX = 0, Max_PosY = 0;
                ///model
                BitmapData SrcBmpData = SrcBmp.LockBits(new Rectangle(0, 0, SrcBmp.Width, SrcBmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                ///D-img
                BitmapData DstBmpData = DstBmp.LockBits(new Rectangle(0, 0, DstBmp.Width, DstBmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                Stopwatch Sw = new Stopwatch();
                Sw.Start();
                ///model
                SrcImg = new TMatrix(SrcBmp.Width, SrcBmp.Height, SrcBmpData.Stride, (int)IS_DEPTH.IS_DEPTH_8U, 3, (byte*)SrcBmpData.Scan0);
                ///D-img
                DestImg = new TMatrix(DstBmp.Width, DstBmp.Height, DstBmpData.Stride, (int)IS_DEPTH.IS_DEPTH_8U, 3, (byte*)DstBmpData.Scan0);
                TMatrix* Dest = null;
                MatchTemplate(ref DestImg, ref SrcImg, ref Dest);

                MinMaxLoc(ref *Dest, ref Min_PosX, ref Min_PosY, ref Max_PosX, ref Max_PosY);
                IS_FreeMatrix(&Dest);
                SrcBmp.UnlockBits(SrcBmpData);
                DstBmp.UnlockBits(DstBmpData);

                Image<Bgr, Byte> SrcimageCV = new Image<Bgr, byte>(SrcBmp); //Image Class from Emgu.CV
                Mat srcmat = SrcimageCV.Mat;
                Image<Bgr, Byte> DstimageCV = new Image<Bgr, byte>(DstBmp); //Image Class from Emgu.CV
                Mat Dstmat = DstimageCV.Mat;
                ///矩阵最大最小相似度
                GetMatchPos(srcmat, Dstmat);

                Pen P = new Pen(Color.Red);
                Graphics G = Graphics.FromImage(DstBmp);
                ///绘制矩形框
                G.DrawRectangle(P, new Rectangle(Min_PosX, Min_PosY, SrcImg.Width, SrcImg.Height));
                P.Dispose();
                G.Dispose();

                LblInfo.Text = "最大相似度：" + MaxsImilarity + "最小相似度：" + MInImilarity + "图像大小: " + PicSrc.Image.Width.ToString() + " X " + PicSrc.Image.Height.ToString() + ",算法处理用时" + Sw.ElapsedMilliseconds.ToString() + "ms." + DateTime.Now.ToString();
                PicDest.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }



        /// <summary>
        /// 获取匹配图像的位置
        /// </summary>
        /// <param name="Src">被匹配的源图像</param>
        /// <param name="Template">模板图像</param>
        /// <returns>匹配位置</returns>
        Rectangle GetMatchPos(Mat Src, Mat Template)
        {
            Mat MatchResult = new Mat();//匹配结果
            CvInvoke.MatchTemplate(Src, Template, MatchResult, Emgu.CV.CvEnum.TemplateMatchingType.CcorrNormed);//使用相关系数法匹配
            Point max_loc = new Point();
            Point min_loc = new Point();
            double max = 0, min = 0;
            CvInvoke.MinMaxLoc(MatchResult, ref min, ref max, ref min_loc, ref max_loc);//获得极值信息
            //this.label1.Text = "\r\nX:" + max_loc.X + " Y:" + max_loc.Y + " 最大相似度:" + max + " 最小相似度:" + min;
            MaxsImilarity = max;
            MInImilarity = min;
            return new Rectangle(max_loc, Template.Size);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ThoughtWorks.QRCode.Codec;

namespace Vision.Controllers
{
    public class TwoWeiMaController : Controller
    {
        // GET: TwoWeiMa
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult CreateImg(string MessageInfo) {

            bool IsTrue = false;
            string Meg = null;
            string path = "";
            try
            {
                string str = MessageInfo;
                Bitmap bt;
                string enCodeString = str;
                //生成设置编码实例
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                //设置二维码的规模，默认4
                qrCodeEncoder.QRCodeScale = 4;
                //设置二维码的版本，默认7
                qrCodeEncoder.QRCodeVersion = 7;
                //设置错误校验级别，默认中等
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //生成二维码图片
                bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
                //二维码图片的名称
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss");
                //保存二维码图片在photos路径下

                path = Server.MapPath("~/photos/") + filename + ".jpg";
                bt.Save(path);
                //图片控件要显示的二维码图片路径
                //this.Image1.ImageUrl = "~/photos/" + filename + ".jpg";

                DeCoder(path);
                path = "photos/" + filename + ".jpg";
                Meg = "二维码生成成功！";
                IsTrue = true;


            }
            catch (Exception ex)
            {

                Meg = ex.ToString();
                IsTrue = false;
            }
            return Json(new { IsTrue = IsTrue, Meg = Meg, path = path });

        }



        /// <summary>
        /// QR二维码解析
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ActionResult QRcodeDECode() {

            bool IsTrue = false;
            string Meg = null;
            try
            {
                string[] FormKey = Request.Form.AllKeys;

                foreach (string upload in Request.Files.AllKeys)
                {
                    var file = Request.Files[upload];
                    string fileExt = "";
                    string name = file.FileName;
                    fileExt = name.Split('.')[1];
                    string FilePath = "UpLoadFile";
                    string fullPath = Server.MapPath("../" + FilePath);

                    String pathstr = fullPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + fileExt;
                    file.SaveAs(pathstr);
                    Meg = DeCoder(pathstr);

                    IsTrue = true;
                }


            }
            catch (Exception ex)
            {
                Meg = ex.ToString();
                IsTrue = false;
            }
            return Json(new { IsTrue = IsTrue, Meg = Meg });


        }

        /// <summary>
        /// 二维码解析
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string DeCoder(string path)
        {
            string result = "";
            try
            {
              
                string strSaveDir = path;
                //if (!Directory.Exists(strSaveDir))
                //{
                //    Directory.CreateDirectory(strSaveDir);
                //}
                string strSavePath = Path.Combine(strSaveDir, "wolfy.png");
                strSavePath = path;
                if (System.IO.File.Exists(strSavePath))
                {
                    QRCodeDecoder decoder = new QRCodeDecoder();


                    result = decoder.decode(new ThoughtWorks.QRCode.Codec.Data.QRCodeBitmapImage(new Bitmap(System.Drawing.Image.FromFile(strSavePath))), Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }




        
   
    }
}
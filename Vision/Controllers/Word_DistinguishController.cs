using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Tesseract;
using Vision.FunctionConfig;

namespace Vision.Controllers
{
    public class Word_DistinguishController : Controller
    {
        // GET: Word_Distinguish
        public ActionResult Index()
        {
            return View();
        }
       /// <summary>
       /// Tesseract-OCR
       /// </summary>
        public ActionResult  Tesseract() {

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

                    string ocrTtxt = "";
                    //chi_sim是中文库
                    //const string language = "chi_sim";
                    const string language = "chi_sim";
                    //Nuget安装的Tessract版本为3.20，tessdata的版本必须与其匹配，另外路径最后必须以"\"或者"/"结尾
                    string TessractData = AppDomain.CurrentDomain.BaseDirectory + @"tessdata\";
                    TesseractEngine test = new TesseractEngine(TessractData, language);
                    //创建一个图片对象
                    Bitmap tmpVal = new Bitmap(pathstr);
                    //灰度化，可以提高识别率
                    var tmpImage = OCRFunctionClass.ToGray(tmpVal);
                    Tesseract.Page tmpPage = test.Process(tmpImage);
                    ocrTtxt = tmpPage.GetText();
                    tmpVal.Dispose();

                    Meg = ocrTtxt;
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

    }
}
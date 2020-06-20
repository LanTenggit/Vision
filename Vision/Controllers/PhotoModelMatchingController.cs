using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vision.Controllers
{
    public class PhotoModelMatchingController : Controller
    {
        // GET: PhotoModelMatching
        public ActionResult Index()
        {
            return View();
        }




      public ActionResult IMgMatching() {
            bool IsTrue = false;
            string Msg = null;

            try
            {
                string[] FormKey = Request.Form.AllKeys;

                HttpPostedFileBase[] FileList = new HttpPostedFileBase[3];
                int i = 0;
                foreach (string upload in Request.Files.AllKeys)
                {
                    FileList[i] = Request.Files[upload];
                    i++;
                }
                var file1 = FileList[0];
                var file2 = FileList[1];


                string fileExt = "";
                string name1 = file1.FileName;
                fileExt = name1.Split('.')[1];
                string FilePath = "UpLoadFile";
                string fullPath = Server.MapPath("../" + FilePath);
                String pathstr1 = fullPath + "\\Model" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + fileExt;
                file1.SaveAs(pathstr1);

                string name2 = file2.FileName;
                String pathstr2 = fullPath + "\\Pipei" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + fileExt;
                file2.SaveAs(pathstr2);

                //模板图片
                Mat temp = new Mat(pathstr1, ImreadModes.AnyColor);
                //被匹配图
                Mat wafer = new Mat(pathstr2, ImreadModes.AnyColor);
                //匹配结果
                Mat result = new Mat();
                //模板匹配
                //Cv2.MatchTemplate(wafer, temp, result, TemplateMatchModes.CCoeffNormed);//最好匹配为1,值越小匹配越差
                //                                                                        //数组位置下x,y
                //Point minLoc = new Point(0, 0);
                //Point maxLoc = new Point(0, 0);
                //Point matchLoc = new Point(0, 0);
                //Cv2.MinMaxLoc(result, out minLoc, out maxLoc);
                //matchLoc = maxLoc;
                //Mat mask = wafer.Clone();
                ////画框显示
                //Cv2.Rectangle(mask, matchLoc, new Point(matchLoc.X + temp.Cols, matchLoc.Y + temp.Rows), Scalar.Green, 2);

                ////新建窗体显示图片
                //using (new Window("temp image", temp))
                //using (new Window("wafer image", wafer))
                //using (new Window("mask image", mask))
                //{
                //    Cv2.WaitKey();
                //}
                
            }
            catch (Exception ex)
            {
                IsTrue = false;
                Msg = ex.ToString();
            }
            return Json((new { IsTrue = IsTrue, Msg= Msg }));
        }
    }
}
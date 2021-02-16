using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

using MyMCE.Models.Repository.Subject;
using MyMCE.Models.IRepository.Subject;
using MyMCE.Models.Domain.Common;
using MyMCE.Models.Domain.Course;
using System.Net;
using MyMCE.Models.IRepository.GlobalLink;
using MyMCE.Models.Repository.GlobalLink;
using MyMCE.Models.Domain.GlobalLink;

namespace MyMCE.Controllers.cGlobalLink
{
    public class GloballinkController : Controller
    {



        IGlobalLink _globallink = new GlobalLink();

        // GET: Subject
        public ActionResult CreateGlobalLinkWithTab()
        {
            var home_Page = new List<DDL_Data>{
                            new DDL_Data() { vchText = "True", vchValue = "True" } ,
                            new DDL_Data() { vchText = "False", vchValue = "False" }
                        };
            ViewBag.home_Page = home_Page.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult CreateGlobalLink()
        {
            var home_Page = new List<DDL_Data>{
                            new DDL_Data() { vchText = "True", vchValue = "True" } ,
                            new DDL_Data() { vchText = "False", vchValue = "False" }
                        };
            ViewBag.home_Page = home_Page.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult CreateGlobalLink(tbl_MCE_GlobalLink mce_globalLink)
        {
            var home_Page = new List<DDL_Data>{
                            new DDL_Data() { vchText = "True", vchValue = "True" } ,
                            new DDL_Data() { vchText = "False", vchValue = "False" }
                        };
            ViewBag.home_Page = home_Page.ToList();

            _globallink.AddGlobalLink(mce_globalLink);

            TempData["Success"] = "Data Inserted Successfully";
            ModelState.Clear();

            return View();

        }
        public ActionResult GlobalLinkDataTable()
        {
            return View();

        }
        [HttpPost]
        public ActionResult GloballinkDetails()
        {
            //Note: Install "System.Linq.Dynamic" from Nuget Packages

            // after this just include namespace in our Controller "using System.Linq.Dynamic;".

            //Draw counter. This is used by DataTables to ensure that the Ajax returns from server-side processing requests are drawn in sequence by DataTables (Ajax requests are asynchronous and thus can return out of sequence).
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            //Paging first record indicator. This is the start point in the current data set (0 index based - i.e. 0 is the first record)
            var start = Request.Form.GetValues("start").FirstOrDefault();
            //Number of records that the table can display in the current draw.
            var length = Request.Form.GetValues("length").FirstOrDefault();

            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;



            var globallinkList = (from a in _globallink.GlobalLinkList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                globallinkList = globallinkList.Where(p => p.vchGLinkName.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.vchIcon.ToLower().Contains(search.ToLower()) ||
                                         p.vchRemarks.ToLower().Contains(search.ToLower())
                                      );
            }


            //SORT
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                globallinkList = globallinkList.OrderBy(sortColumn + " " + sortColumnDir);
            }

            recordsTotal = globallinkList.Count();
            var data = globallinkList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GlobalLinkDetails(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                tbl_MCE_GlobalLink globallink = _globallink.GLDetails((int)id);
                var home_Page = new List<DDL_Data>{
                            new DDL_Data() { vchText = "True", vchValue = "True" } ,
                            new DDL_Data() { vchText = "False", vchValue = "False" }
                        };
                ViewBag.home_Page = home_Page.ToList();





                return View(globallink);
            }







        }

        public ActionResult EditGlobalLink(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_GlobalLink globallink = _globallink.GLDetails((int)id);

            var home_Page = new List<DDL_Data>{
                            new DDL_Data() { vchText = "True", vchValue = "True" } ,
                            new DDL_Data() { vchText = "False", vchValue = "False" }
                        };
            ViewBag.home_Page = home_Page.ToList();

            return View(globallink);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGlobalLink(tbl_MCE_GlobalLink mce_Globallink)
        {
            _globallink.EditGloballink(mce_Globallink);
            var home_Page = new List<DDL_Data>{
                            new DDL_Data() { vchText = "True", vchValue = "True" } ,
                            new DDL_Data() { vchText = "False", vchValue = "False" }
                        };
            ViewBag.home_Page = home_Page.ToList();
            TempData["Success"] = "Data Updated Successfully";
            return RedirectToAction("GlobalLinkDataTable", "Globallink");
        }

        public ActionResult DeleteGlobalLink(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_GlobalLink globallink = _globallink.GLDetails((int)id);

            var home_Page = new List<DDL_Data>{
                            new DDL_Data() { vchText = "True", vchValue = "True" } ,
                            new DDL_Data() { vchText = "False", vchValue = "False" }
                        };
            ViewBag.home_Page = home_Page.ToList();

            return View(globallink);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGlobalLink(tbl_MCE_GlobalLink mce_Globallink)
        {

            _globallink.DeleteGloballink(mce_Globallink);

            var home_Page = new List<DDL_Data>{
                            new DDL_Data() { vchText = "True", vchValue = "True" } ,
                            new DDL_Data() { vchText = "False", vchValue = "False" }
                        };
            ViewBag.home_Page = home_Page.ToList();

            TempData["Success"] = "Data Deleted Successfully";
            return RedirectToAction("GlobalLinkDataTable", "Globallink");
        }


        [HttpPost]
        //This post method calls in View page thorough AJax call to bind the data in JQuery Datatable
        //Server side processing concept used to bind the data in JQuery
        public ActionResult GetGloballinkForSearchPanel(GlobalLinkSearchPanel globallinkSearchPanel)
        {
            //Note: Install "System.Linq.Dynamic" from Nuget Packages
            // after this just include namespace in our Controller "using System.Linq.Dynamic;".

            //Draw counter. This is used by DataTables to ensure that the Ajax returns from server-side processing requests are drawn in sequence by DataTables (Ajax requests are asynchronous and thus can return out of sequence).
            var draw = Request.Form.GetValues("draw").FirstOrDefault();

            //Paging first record indicator. This is the start point in the current data set (0 index based - i.e. 0 is the first record)
            var start = Request.Form.GetValues("start").FirstOrDefault();
            //Number of records that the table can display in the current draw.
            var length = Request.Form.GetValues("length").FirstOrDefault();

            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;


            var globallinkList = (from a in _globallink.GlobalLinkListSP(globallinkSearchPanel) select a);

            //SORT
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                globallinkList = globallinkList.OrderBy(sortColumn + " " + sortColumnDir);
            }

            recordsTotal = globallinkList.Count();
            var data = globallinkList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);


        }

    }
}
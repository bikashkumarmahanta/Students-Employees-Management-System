
using MyMCE.Models.Domain.JoinCategory;
using MyMCE.Models.IRepository.JoinCategory;
using MyMCE.Models.IRepository.Levels;
using MyMCE.Models.Repository.JoinCategory;
using MyMCE.Models.Repository.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyMCE.Controllers.CJoinCategory
{
    public class JoinCategoryController : Controller
    {
        ILevels _levels = new Levels();
        IJoinCategory _JC = new JoinCategory();
        // GET: JoinCategory
        public ActionResult JoinCategoryReport()
        {
            return View();

        }
        [HttpPost]
        public ActionResult JoinCategoryDetails()
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



            var jcList = (from a in _JC.JoinCategoryList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                jcList = jcList.Where(p => p.vchLevelName.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.vchJoinCategoryType.ToLower().Contains(search.ToLower()));
            }


            ////SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    branchList = branchList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = jcList.Count();
            var data = jcList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }



        [HttpGet]
        public ActionResult CreateJoinCategory()
        {
            ViewBag.levelList = _levels.LevelList().ToList();
            return View();
        }


        [HttpPost]
        public ActionResult CreateJoinCategory(tbl_MCE_JoinCategory mce_JoinCategory)
        {
            ModelState.Clear();
            _JC.AddCategory(mce_JoinCategory);
            ViewBag.levelList = _levels.LevelList().ToList();
            TempData["Success"] = "Category Created Successfully";
            ModelState.Clear();
            return View();
        }



        //to show all the data present in the table based on the parameter required.
        public ActionResult JoinCategoryDataTable()
        {
            ViewBag.levelList = _levels.LevelList().ToList();
            return View();
        }


        //method to get data from table based on selected parameter.
        [HttpPost]
        //This post method calls in View page thorough AJax call to bind the data in JQuery Datatable
        //Server side processing concept used to bind the data in JQuery
        public ActionResult GetJoinCategoryForSearchPanel(JoinCategorySearchPanel joincategorySearchPanel)
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



            var joincategoryList = (from a in _JC.JoinCategoryList(joincategorySearchPanel) select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  




            recordsTotal = joincategoryList.Count();
            var data = joincategoryList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }



        public ActionResult EditJoinCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_JoinCategory jc = _JC.JoinCategoryDetails((int)id);

            ViewBag.levelList = _levels.LevelList().ToList();


            ViewBag.DefaultLevel = jc.intLevelID;


            return View(jc);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJoinCategory(tbl_MCE_JoinCategory mce_JoinCategory)
        {
            _JC.EditJoinCategory(mce_JoinCategory);
            TempData["Success"] = "Data Updated Successfully";
            return RedirectToAction("JoinCategoryDataTable", "JoinCategory");
        }


        public ActionResult JoinCategoryDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_JoinCategory jc = _JC.JoinCategoryDetails((int)id);
            ViewBag.levelList = _levels.LevelList().ToList();
            ViewBag.DefaultLevel = jc.intLevelID;
            return View(jc);
        }

        [HttpGet]
        public ActionResult DeleteJoinCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_JoinCategory jc = _JC.JoinCategoryDetails((int)id);

            ViewBag.levelList = _levels.LevelList().ToList();

            ViewBag.DefaultLevel = jc.intLevelID;

            return View(jc);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteJoinCategory(tbl_MCE_JoinCategory mce_JoinCategory)
        {
            _JC.DeleteJoinCategory(mce_JoinCategory);
            TempData["Success"] = "Data Deleted Successfully";
            return RedirectToAction("JoinCategoryDataTable", "JoinCategory");
        }
    }
}
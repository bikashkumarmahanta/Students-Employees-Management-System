using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

using MyMCE.Models.Domain.Levels;
using MyMCE.Models.Repository.Levels;
using MyMCE.Models.IRepository.Levels;
using MyMCE.Models.Domain.Common;
using System.Net;

namespace MyMCE.Controllers.CLevel
{
    public class LevelController : Controller
    {
        ILevels _level = new Levels();
        // GET: Level

        [HttpGet]
        public ActionResult CreateLevel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLevel(tbl_MCE_Levels MCE_Level)
        {
            _level.AddLevel(MCE_Level);
            TempData["Success"] = "Data Inserted Successfully";
            ModelState.Clear();
            return View();
        }

        //Create Level With Tab
        [HttpGet]
        public ActionResult CreateLevelWithTab()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLevelWithTab(tbl_MCE_Levels MCE_Level)
        {
            _level.AddLevel(MCE_Level);
            TempData["Success"] = "Data Inserted Successfully";
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult ViewLevels()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewLevelsDatatableWithTab()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetLevels()
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

            //var subjectList = _subject.SubjectList();



            var levelList = (from a in _level.LevelList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                levelList = levelList.Where(p => p.vchLevelName.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.vchRemarks.ToLower().Contains(search.ToLower()));
            }

            //Sort not working
            //SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    designationList = designationList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = levelList.Count();
            var data = levelList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);



            //  return Json(new { data = subjectList }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public ActionResult LevelDetails()
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

            //var subjectList = _subject.SubjectList();



            var levelList = (from a in _level.LevelList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                levelList = levelList.Where(p => p.vchLevelName.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.vchRemarks.ToLower().Contains(search.ToLower()));
            }

            //Sort not working
            //SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    designationList = designationList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = levelList.Count();
            var data = levelList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);



            //  return Json(new { data = subjectList }, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult EditLevel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Levels level = _level.LevelDetails((int)id);

            return View(level);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLevel(tbl_MCE_Levels mce_Levels)
        {
            _level.EditLevel(mce_Levels);
            TempData["Success"] = "Data Updated Successfully";
            return RedirectToAction("ViewLevelsDatatableWithTab", "Level");
            //return View();
        }

        public ActionResult LevelDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Levels level = _level.LevelDetails((int)id);
            return View(level);
        }

        public ActionResult DeleteLevel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Levels level = _level.LevelDetails((int)id);

            return View(level);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLevel(tbl_MCE_Levels mce_Levels)
        {
            _level.DeleteLevel(mce_Levels);
            TempData["Success"] = "Data Deleted Successfully";
            return RedirectToAction("ViewLevelsDatatableWithTab", "Level");
        }
    }
}
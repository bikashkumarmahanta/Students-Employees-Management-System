using MyMCE.Models.Domain.Common;
using MyMCE.Models.Domain.Function;
using MyMCE.Models.IRepository.Function;
using MyMCE.Models.Repository.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyMCE.Controllers.CFunction
{
    public class FunctionController : Controller
    {
        IFunction _function = new Function();
        // GET: Function
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateFunction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFunction(tbl_MCE_Function MCE_Function)
        {
            _function.AddFunction(MCE_Function);
            TempData["Success"] = "Data Inserted Successfully";
            ModelState.Clear();
            return View();

        }
        [HttpGet]
        public ActionResult CreateFunctionWithTab()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFunctionWithTab(tbl_MCE_Function MCE_Function)
        {
            _function.AddFunction(MCE_Function);
            TempData["Success"] = "Data Inserted Successfully";
            ModelState.Clear();
            return View();

        }
        [HttpPost]
        public ActionResult GetFunction()
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



            var functionList = (from a in _function.FunctionList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                functionList = functionList.Where(p => p.vchFunctionName.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.vchFileName.ToLower().Contains(search.ToLower()));
            }


            ////SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    functionList = functionList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = functionList.Count();
            var data = functionList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);



            //  return Json(new { data = subjectList }, JsonRequestBehavior.AllowGet);


        }
        //To Display List of functions
        public ActionResult FunctionReport()
        {
            return View();

        }

        [HttpPost]
        public ActionResult FunctionDetails()
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



            var functionList = (from a in _function.FunctionList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                functionList = functionList.Where(p => p.vchFunctionName.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.vchFileName.ToLower().Contains(search.ToLower()));


            }


            //SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    functionList = functionList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = functionList.Count();
            var data = functionList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }
        //View subject details with JQuery Datatable
        public ActionResult ViewFunctionDataTableWithSearchPanel()
        {
            return View();
        }
        [HttpPost]
        //This post method calls in View page thorough AJax call to bind the data in JQuery Datatable
        //Server side processing concept used to bind the data in JQuery
        public ActionResult GetFunctionForSearchPanel(FunctionSearchPanel functionSearchPanel)
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


            var functionList = (from a in _function.FunctionList(functionSearchPanel) select a);

            //SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    functionList = functionList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = functionList.Count();
            var data = functionList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);


        }






        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Function function = _function.FunctionDetails((int)id);

            return View(function);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_MCE_Function MCE_Function)
        {
            _function.EditFunction(MCE_Function);
            TempData["Success"] = "Data Updated Successfully";
            return RedirectToAction("FunctionReport", "function");
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Function function = _function.FunctionDetails((int)id);
            return View(function);
        }

        [HttpGet]
        public ActionResult DeleteFunction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Function function = _function.FunctionDetails((int)id);

            return View(function);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFunction(tbl_MCE_Function MCE_Function)
        {
            _function.DeleteFunction(MCE_Function);
            TempData["Success"] = "Data Deleted Successfully";
            return RedirectToAction("FunctionReport", "Function");
        }



    }
}
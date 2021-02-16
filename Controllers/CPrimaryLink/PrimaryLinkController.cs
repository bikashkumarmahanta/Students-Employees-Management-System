using MyMCE.Models.Domain.PrimaryLink;
using MyMCE.Models.IRepository.Function;
using MyMCE.Models.IRepository.GlobalLink;
using MyMCE.Models.IRepository.PrimaryLink;
using MyMCE.Models.Repository.Function;
using MyMCE.Models.Repository.GlobalLink;
using MyMCE.Models.Repository.PrimaryLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace MyMCE.Controllers.CPrimaryLink
{
    public class PrimaryLinkController : Controller
    {

        IPrimaryLink _plinks = new PrimaryLink();
        IGlobalLink _glinks = new GlobalLink();
        IFunction _flinks = new Function();



        // GET: Plinks
        public ActionResult Index()
        {
            return View();
        }
        //FOR CREATE PAGE
        [HttpGet]
        public ActionResult CreatePlink()
        {
            ViewBag.GlinkList = _glinks.GlobalLinkList().ToList();
            ViewBag.FlinkList = _flinks.FunctionList().ToList();

            return View();
        }
        [HttpPost]
        public ActionResult CreatePlink(tbl_MCE_PrimaryLink mce_Primarylink)
        {
            _plinks.AddPlinks(mce_Primarylink);
            //CLEAR THE MODEL
            ModelState.Clear();
            ViewBag.GlinkList = _glinks.GlobalLinkList().ToList();
            ViewBag.FlinkList = _flinks.FunctionList().ToList();

            TempData["Success"] = "Primary Link Created Successfully";
            return View();


        }


        //FOR PRIMARY LINK DATA TABLE PAGE

        public ActionResult ViewPlinkDataTable()
        {

            return View();

        }
        [HttpPost]
        public ActionResult PlinkDetails()
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


            var PlinkList = (from a in _plinks.PlinkList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                PlinkList = PlinkList.Where(p => p.vchGLinkName.ToString().ToLower().Contains(search.ToLower()) ||
                                                 p.vchPLinkName.ToLower().Contains(search.ToLower()) ||
                                                 p.vchFunctionName.ToLower().Contains(search.ToLower())

                                       );
            }


            ////SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    PlinkList = PlinkList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = PlinkList.Count();
            var data = PlinkList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);


        }




        //FOR PRIMARY LINK EDIT PAGE

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_PrimaryLink Primarylink = _plinks.PrimarylinkDetails((int)id);





            //ViewBag.GlinkList = _glinks.GlobalLinkList().ToList();
            //ViewBag.FlinkList = _flinks.FunctionList().ToList();
            //ViewBag.PlinkList = _plinks.PlinkList().ToList();



            return View(Primarylink);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_MCE_PrimaryLink mce_Primarylink)
        {
            _plinks.EditPrimarylink(mce_Primarylink);
            TempData["Success"] = "Data Updated Successfully";
            return RedirectToAction("ViewDataTableWithSearchPanel", "PrimaryLink");
        }

        //FOR PRIMARY LINK  DELETE PAGE

        public ActionResult DeletePrimarylink(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_PrimaryLink Primarylink = _plinks.PrimarylinkDetails((int)id);


            ViewBag.GlinkList = _glinks.GlobalLinkList().ToList();
            ViewBag.FlinkList = _flinks.FunctionList().ToList();


            //ViewBag.DefaultGlink = _plinks.int;
            //ViewBag.DefaultRole = _plinks.intRoleID;

            return View(Primarylink);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePrimarylink(tbl_MCE_PrimaryLink mce_Primarylink)
        {

            _plinks.DeletePrimarylink(mce_Primarylink);
            TempData["Success"] = "Data Deleted Successfully";
            return RedirectToAction("ViewDataTableWithSearchPanel", "PrimaryLink");
        }

        //FOR DETAILS OF PRIMARY LINK TABLE PAGE

        public ActionResult PrimarylinkDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_PrimaryLink Primarylink = _plinks.PrimarylinkDetails((int)id);
            return View(Primarylink);
        }

        public ActionResult ViewDataTableWithSearchPanel()
        {


            return View();
        }
        [HttpPost]
        //This post method calls in View page thorough AJax call to bind the data in JQuery Datatable
        //Server side processing concept used to bind the data in JQuery
        public ActionResult GetPrimaryLinkForSearchPanel(PrimaryLinkSearchPanel primaryLinkSearchPanel)
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


            var primaryLinkList = (from a in _plinks.PrimaryLinkList(primaryLinkSearchPanel) select a);

            ////SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    primaryLinkList = primaryLinkList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = primaryLinkList.Count();
            var data = primaryLinkList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);


        }

    }
}

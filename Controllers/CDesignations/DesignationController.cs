using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMCE.Models.Domain.Designations;
using MyMCE.Models.Repository.Designations;
using MyMCE.Models.IRepository.Designations;
using MyMCE.Models.Domain.Common;
using System.Net;

namespace MyMCE.Controllers.CDesignations
{
    public class DesignationController : Controller
    {
        IDesignations _designation = new Designations();
        // GET: Designation

        [HttpGet]
        public ActionResult CreateDesignation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDesignation(tbl_MCE_Designations MCE_Designation)
        {
            _designation.AddDesignation(MCE_Designation);
            TempData["Success"] = "Data Inserted Successfully";

            //To clear the model
            ModelState.Clear();

            return View();
        }

        //Create Designation With Tab
        [HttpGet]
        public ActionResult CreateDesignationWithTab()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDesignationWithTab(tbl_MCE_Designations MCE_Designation)
        {
            _designation.AddDesignation(MCE_Designation);
            TempData["Success"] = "Data Inserted Successfully";

            //To clear the model
            ModelState.Clear();

            return View();
        }


        [HttpGet]
        public ActionResult ViewDesignations()
        {
            return View();
        }

        //View Designation With Tab
        [HttpGet]
        public ActionResult ViewDesignationDataTableWithTab()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetDesignations()
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



            var designationList = (from a in _designation.DesignationList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                designationList = designationList.Where(p => p.vchDesignation.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.vchDesignationDescription.ToLower().Contains(search.ToLower()));
            }

            //Sort not working
            //SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    designationList = designationList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = designationList.Count();
            var data = designationList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);



            //  return Json(new { data = subjectList }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public ActionResult DesignationDetails()
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



            var designationList = (from a in _designation.DesignationList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                designationList = designationList.Where(p => p.vchDesignation.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.vchDesignationDescription.ToLower().Contains(search.ToLower()));
            }

            //Sort not working
            //SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    designationList = designationList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = designationList.Count();
            var data = designationList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);



            //  return Json(new { data = subjectList }, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult EditDesignation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Designations designation = _designation.DesignationDetails((int)id);

            return View(designation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDesignation(tbl_MCE_Designations mce_Designations)
        {
            _designation.EditDesignation(mce_Designations);
            TempData["Success"] = "Data Updated Successfully";
            return RedirectToAction("ViewDesignationDataTableWithTab", "Designation");
            //return View();
        }

        public ActionResult DesignationDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Designations designation = _designation.DesignationDetails((int)id);
            return View(designation);
        }

        public ActionResult DeleteDesignation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Designations designation = _designation.DesignationDetails((int)id);

            return View(designation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDesignation(tbl_MCE_Designations mce_Designations)
        {
            _designation.DeleteDesignation(mce_Designations);
            TempData["Success"] = "Data Deleted Successfully";
            return RedirectToAction("ViewDesignationDataTableWithTab", "Designation");
        }
    }
}
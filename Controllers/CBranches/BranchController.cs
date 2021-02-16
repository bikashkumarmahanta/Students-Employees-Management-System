using MyMCE.Models.Domain.Branches;
using MyMCE.Models.IRepository.Branches;
using MyMCE.Models.IRepository.Course;
using MyMCE.Models.Repository.Branches;
using MyMCE.Models.Repository.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

using System.Net;


namespace MyMCE.Controllers.Branch
{
    public class BranchController : Controller
    {
        ICourse course = new Course();
        IBranches _branches = new Branches();
        // GET: Branch
        public ActionResult ViewBranchTab()
        {
            var BranchDetails = _branches.BranchL();
            return View(BranchDetails);
        }
        [HttpGet]
        public ActionResult CreateBranch()
        {

            ViewBag.courseList = course.CourseList().ToList();


            return View();
        }
        [HttpPost]
        public ActionResult CreateBranch(tbl_MCE_Branch mce_Branch)
        {
            _branches.AddBranch(mce_Branch);
            ViewBag.courseList = course.CourseList().ToList();
            TempData["Success"] = "Data Inserted Successfully";
            ModelState.Clear();
            return View();

        }

        public ActionResult BranchReport()
        {
            return View();

        }

        public ActionResult ViewBranchDataTableWithSearchPanel()
        {

            ViewBag.courseList = course.CourseList().ToList();
            return View();
        }


        [HttpPost]
        //This post method calls in View page thorough AJax call to bind the data in JQuery Datatable
        //Server side processing concept used to bind the data in JQuery
        public ActionResult GetBranchForSearchPanel(BranchSearchPanel branchSearchPanel)
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


            var branchList = (from a in _branches.BranchList(branchSearchPanel) select a);

            ////SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    branchList = branchList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = branchList.Count();
            var data = branchList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public ActionResult TestData(tbl_MCE_Branch tbl_MCE_Branch)
        {
            return View();
        }

        [HttpPost]
        public ActionResult BranchDetails()
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



            var branchList = (from a in _branches.BranchL() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                branchList = branchList.Where(p => p.vchCourseName.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.vchBranchName.ToLower().Contains(search.ToLower()));
            }


            ////SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    branchList = branchList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = branchList.Count();
            var data = branchList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Branch branch = _branches.BranchDetails((int)id);

            ViewBag.courseList = course.CourseList().ToList();


            ViewBag.DefaultBranch = branch.intCourseID;


            return View(branch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_MCE_Branch mce_Branch)
        {
            _branches.EditBranch(mce_Branch);
            TempData["Success"] = "Data Updated Successfully";
            return RedirectToAction("ViewBranchDataTableWithSearchPanel", "Branch");
        }



        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Branch branch = _branches.BranchDetails((int)id);



            ViewBag.courseList = course.CourseList().ToList();

            ViewBag.DefaultSubject = branch.intCourseID;

            return View(branch);
        }

        [HttpGet]
        public ActionResult DeleteBranch(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Branch branch = _branches.BranchDetails((int)id);

            ViewBag.courseList = course.CourseList().ToList();
            ViewBag.DefaultCourse = branch.intCourseID;


            return View(branch);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBranch(tbl_MCE_Branch mce_Branch)
        {
            _branches.DeleteBranch(mce_Branch);
            TempData["Success"] = "Data Deleted Successfully";
            return RedirectToAction("ViewBranchDataTableWithSearchPanel", "Branch");
        }

    }
}
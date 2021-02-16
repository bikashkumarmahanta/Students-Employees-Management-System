using MyMCE.Models.Domain.Branches;
using MyMCE.Models.Domain.Semester;
using MyMCE.Models.IRepository.Branches;
using MyMCE.Models.IRepository.Course;
using MyMCE.Models.IRepository.Semester;
using MyMCE.Models.Repository.Branches;
using MyMCE.Models.Repository.Course;
using MyMCE.Models.Repository.Semester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyMCE.Controllers.CSemester
{
    public class SemesterController : Controller
    {

        ICourse course = new Course();
        IBranches _branches = new Branches();
        ISemester _semester = new Semester();
        // GET: Semester
        public ActionResult Index()
        {
            return View();
        }


        //to get the branches corresponding to course selected in drop down.
        [HttpPost]
        public ActionResult GetBranch(int intCourseID = 0)
        {
            List<Branch_DDL> branches = new List<Branch_DDL>();

            branches = _branches.BranchList().Where(s => s.intCourseID == intCourseID)
                                .ToList<Branch_DDL>();

            var BranchData = branches.Select(m => new SelectListItem()
            {
                Text = m.vchBranchName.ToString(),
                Value = m.intBranchID.ToString(),
            });
            return Json(BranchData, JsonRequestBehavior.AllowGet);
        }




        //get method for creating new semester. 

        [HttpGet]
        public ActionResult CreateSemester()
        {

            ViewBag.courseList = course.CourseList().ToList();


            return View();
        }
        //method to store new semester details.
        [HttpPost]
        public ActionResult CreateSemester(tbl_MCE_Semester mce_Semester)
        {
            ModelState.Clear();
            _semester.AddSemester(mce_Semester);
            ViewBag.courseList = course.CourseList().ToList();
            TempData["Success"] = "Semester Created Successfully";
            ModelState.Clear();
            return View();
        }


        //to show all the data present in the table based on the parameter required.
        public ActionResult SemesterDataTable()
        {
            ViewBag.courseList = course.CourseList().ToList();
            return View();
        }


        //method to get data from table based on selected parameter.
        [HttpPost]
        //This post method calls in View page thorough AJax call to bind the data in JQuery Datatable
        //Server side processing concept used to bind the data in JQuery
        public ActionResult GetSemesterForSearchPanel(SemesterSearchPanel semesterSearchPanel)
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



            var semesterList = (from a in _semester.SemesterList(semesterSearchPanel) select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  




            recordsTotal = semesterList.Count();
            var data = semesterList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }







        [HttpGet]
        public ActionResult SemesterReport()
        {

            return View();
        }


        [HttpPost]
        public ActionResult SemesterDetails()
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



            var semesterList = (from a in _semester.SemesterList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                semesterList = semesterList.Where(p => p.vchCourseName.ToString().ToLower().Contains(search.ToLower()) ||
                                      p.vchBranchName.ToLower().Contains(search.ToLower()) ||
                                        p.vchAdmissionBatch.ToLower().Contains(search.ToLower()) ||
                                      p.intSemester.ToString().ToLower().Contains(search.ToLower()));
            }


            ////SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    subjectList = subjectList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = semesterList.Count();
            var data = semesterList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult EditSemester(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Semester semester = _semester.SemesterDetails((int)id);



            ViewBag.courseList = course.CourseList().ToList();
            ViewBag.BranchList = _branches.BranchList().ToList();

            ViewBag.DefaultCourse = semester.intCourseID;
            ViewBag.DefaultBranch = semester.intBranchID;

            return View(semester);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSemester(tbl_MCE_Semester mce_Semester)
        {
            _semester.EditSemester(mce_Semester);
            TempData["Success"] = "Data Updated Successfully";
            return RedirectToAction("SemesterDataTable", "Semester");
        }


        public ActionResult DeleteSemester(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Semester semester = _semester.SemesterDetails((int)id);


            ViewBag.courseList = course.CourseList().ToList();
            ViewBag.BranchList = _branches.BranchList().ToList();

            ViewBag.DefaultCourse = semester.intCourseID;
            ViewBag.DefaultBranch = semester.intBranchID;

            return View(semester);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSemester(tbl_MCE_Semester mce_Semester)
        {
            _semester.DeleteSemester(mce_Semester);
            TempData["Success"] = "Data Deleted Successfully";
            return RedirectToAction("SemesterDataTable", "Semester");
        }

        public ActionResult SemesterDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Semester semester = _semester.SemesterDetails((int)id);


            ViewBag.courseList = course.CourseList().ToList();
            ViewBag.BranchList = _branches.BranchList().ToList();

            ViewBag.DefaultCourse = semester.intCourseID;
            ViewBag.DefaultBranch = semester.intBranchID;
            return View(semester);
        }
    }
}
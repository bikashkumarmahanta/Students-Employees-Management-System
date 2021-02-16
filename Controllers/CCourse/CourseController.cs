using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

using MyMCE.Models.Domain.Course;
using MyMCE.Models.Repository.Course;
using MyMCE.Models.IRepository.Course;
using System.Net;

namespace MyMCE.Controllers.CCourse
{
    public class CourseController : Controller
    {

        ICourse course = new Course();
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateCourse()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(tbl_MCE_Course mce_Course)
        {
            course.AddCourse(mce_Course);
            ModelState.Clear();
            TempData["Success"] = "Data Created Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult CourseDataTable()
        {

            return View();
        }

        [HttpPost]
        public ActionResult GetCourse()
        {
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

            var courseList = (from a in course.CourseList() select a);

            string search = Request.Form.GetValues("search[value]")[0];

            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                courseList = courseList.Where(p => p.vchCourseName.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.vchCourseDescription.ToString().ToLower().Contains(search.ToLower()));
            }

            //SORT
            // if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //courseList = courseList.OrderBy(sortColumn + " " + sortColumnDir);
            //}


            recordsTotal = courseList.Count();
            var data = courseList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult EditCourse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Course _course = course.CourseDetails((int)id);
            return View(_course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCourse(tbl_MCE_Course mce_Course)
        {
            course.Editcourse(mce_Course);
          
            TempData["Success"] = "Data Updated Successfully";
            return RedirectToAction("CourseDataTable", "Course");
        }

        public ActionResult CourseDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Course _course = course.CourseDetails((int)id);
            return View(_course);
        }

        [HttpGet]
        public ActionResult DeleteCourse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Course _course = course.CourseDetails((int)id);
            return View(_course);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCourse(tbl_MCE_Course mce_Course)
        {
            course.Deletecourse(mce_Course);
            TempData["Success"] = "Data Deleted Successfully";
            return RedirectToAction("CourseDataTable", "Course");
        }

    }
}
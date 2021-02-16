using MyMCE.Models.Helper;
using MyMCE.Models.Domain.Branches;
using MyMCE.Models.Domain.Common;
using MyMCE.Models.Domain.Student;
using MyMCE.Models.IRepository.Branches;
using MyMCE.Models.IRepository.Course;
using MyMCE.Models.IRepository.JoinCategory;
using MyMCE.Models.IRepository.Student;
using MyMCE.Models.Repository.Branches;
using MyMCE.Models.Repository.Course;
using MyMCE.Models.Repository.JoinCategory;
using MyMCE.Models.Repository.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMCE.Controllers.CStudent
{
    public class StudentController : Controller
    {
        ICourse _course = new Course();
        IBranches _branches = new Branches();
        IStudent _student = new Student();
        IJoinCategory _joincategory = new JoinCategory();

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
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
        [HttpGet]
        public ActionResult CreateStudent()
        {
            var gender_Type = new List<DDL_Data>{
                            new DDL_Data() { vchText = "Male", vchValue = "Male" } ,
                            new DDL_Data() { vchText = "Female", vchValue = "Famale" },
                            new DDL_Data() { vchText = "Others", vchValue = "Others" }
                        };
            ViewBag.gender_Type = gender_Type.ToList();
            ViewBag.courseList = _course.CourseList().ToList();
            ViewBag.joincategoryList = _joincategory.JoinCategoryList().ToList();

            return View();
        }
        [HttpPost]
        public ActionResult CreateStudent(tbl_MCE_Student_Basic MCE_Student_Basic)
        {
            MCE_Student_Basic.vchPassword = Util.GetHashByte("password");



            _student.AddStudent(MCE_Student_Basic);
            ModelState.Clear();

            var gender_Type = new List<DDL_Data>{
                            new DDL_Data() { vchText = "Male", vchValue = "Male" } ,
                            new DDL_Data() { vchText = "Female", vchValue = "Famale" },
                            new DDL_Data() { vchText = "Others", vchValue = "Others" }
                        };
            ViewBag.gender_Type = gender_Type.ToList();
            ViewBag.courseList = _course.CourseList().ToList();
            ViewBag.joincategoryList = _joincategory.JoinCategoryList().ToList();
            TempData["Success"] = "Data Inserted Successfully";


            return View();

        }
    }
}
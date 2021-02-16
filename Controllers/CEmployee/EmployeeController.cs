using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyMCE.Models.Domain.Subject;
using MyMCE.Models.Repository.Subject;
using MyMCE.Models.IRepository.Subject;
using MyMCE.Models.Domain.Common;
using MyMCE.Models.Domain.Course;
using MyMCE.Models.Repository.Course;
using MyMCE.Models.IRepository.Course;
using MyMCE.Models.Domain.Branches;
using MyMCE.Models.IRepository.Branches;
using MyMCE.Models.Repository.Branches;
using MyMCE.Models.Domain.Designations;
using MyMCE.Models.Repository.Designations;
using MyMCE.Models.IRepository.Designations;
using MyMCE.Models.Domain.Role;
using MyMCE.Models.Repository.Role;
using MyMCE.Models.IRepository.Role;
using MyMCE.Models.Domain.JoinCategory;
using MyMCE.Models.IRepository.JoinCategory;
using MyMCE.Models.Repository.JoinCategory;
using MyMCE.Models.Domain.Levels;
using MyMCE.Models.Repository.Levels;
using MyMCE.Models.IRepository.Levels;
using MyMCE.Models.Domain.Employee;
using MyMCE.Models.Repository.Employee;
using MyMCE.Models.IRepository.Employee;
using System.Net;
using MyMCE.Models.Helper;

namespace MyMCE.Controllers.CEmployee
{
    public class EmployeeController : Controller
    {
        ICourse _course = new Course();
        IBranches _branches = new Branches();
        ISubject _subject = new Subject();
        IEmployee _employee = new Employee();
        ILevels _level = new Levels();
        IJoinCategory _joincategory = new JoinCategory();
        IDesignations _designation = new Designations();
        IRole _role = new Role();


        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            var gender = new List<DDL_Data>{
                            new DDL_Data() { vchText = "Male", vchValue = "Male" } ,
                            new DDL_Data() { vchText = "Female", vchValue = "Female" },
                            new DDL_Data() { vchText = "prefer not to say", vchValue = "prefer not to say" }
                        };

            ViewBag.gender = gender.ToList();
            ViewBag.courseList = _course.CourseList1().ToList();
            //ViewBag.branchList = _branches.BranchList().ToList();
            ViewBag.designationList = _designation.DesignationList().ToList();
            ViewBag.joinCategoryList = _joincategory.JoinCategoryList().ToList();
            ViewBag.roleList = _role.RoleList().ToList();
            ViewBag.levelList = _level.LevelList().ToList();
            ViewBag.employeeList = _employee.EmployeeList1().ToList();
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

        [HttpPost]
        public ActionResult CreateEmployee(tbl_MCE_Employee mce_Employee)
        {

            mce_Employee.vchPassword = Util.GetHashByte("password");
            _employee.AddEmployee(mce_Employee);
            ModelState.Clear();

            var gender = new List<DDL_Data>{
                            new DDL_Data() { vchText = "Male", vchValue = "Male" } ,
                            new DDL_Data() { vchText = "Female", vchValue = "Female" },
                            new DDL_Data() { vchText = "prefer not to say", vchValue = "prefer not to say" }
                        };

            ViewBag.gender = gender.ToList();
            ViewBag.courseList = _course.CourseList1().ToList();
            //ViewBag.branchList = _branches.BranchList().ToList();
            ViewBag.designationList = _designation.DesignationList().ToList();
            ViewBag.joinCategoryList = _joincategory.JoinCategoryList().ToList();
            ViewBag.roleList = _role.RoleList().ToList();
            ViewBag.levelList = _level.LevelList().ToList();
            ViewBag.employeeList = _employee.EmployeeList1().ToList();
            TempData["Success"] = "Data Created Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult EmployeeDataTable()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GetEmployee()
        {
            // Draw counter. This is used by DataTables to ensure that the Ajax returns from server - side processing requests are drawn in sequence by DataTables(Ajax requests are asynchronous and thus can return out of sequence).
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

            var employeeList = (from a in _employee.EmployeeList() select a);

            string search = Request.Form.GetValues("search[value]")[0];

            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                employeeList = employeeList.Where(p => p.vchName.ToString().ToLower().Contains(search.ToLower()));
            }

            //SORT
            // if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //courseList = courseList.OrderBy(sortColumn + " " + sortColumnDir);
            //}


            recordsTotal = employeeList.Count();
            var data = employeeList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);


        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Employee employee = _employee.EmployeeDetails((int)id);
            var gender = new List<DDL_Data>{
                            new DDL_Data() { vchText = "Male", vchValue = "Male" } ,
                            new DDL_Data() { vchText = "Female", vchValue = "Female" },
                            new DDL_Data() { vchText = "prefer not to say", vchValue = "prefer not to say" }
                        };

            ViewBag.gender = gender.ToList();
            ViewBag.courseList = _course.CourseList1().ToList();
            //ViewBag.branchList = _branches.BranchList().ToList();
            ViewBag.designationList = _designation.DesignationList().ToList();
            ViewBag.joinCategoryList = _joincategory.JoinCategoryList().ToList();
            ViewBag.roleList = _role.RoleList().ToList();
            ViewBag.levelList = _level.LevelList().ToList();
            ViewBag.employeeList = _employee.EmployeeList1().ToList();

            ViewBag.DefaultSubject = employee.intCourseID;
            ViewBag.DefaultBranch = employee.intBranchID;

            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(tbl_MCE_Employee mce_Employee)
        {
            _employee.Editemployee(mce_Employee);
            TempData["Success"] = "Data Updated Successfully";
            return RedirectToAction("ViewEmployeeDataTable", "Employee");
        }


    }
}
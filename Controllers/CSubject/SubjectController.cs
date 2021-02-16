using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

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
using System.Net;

namespace MyMCE.Controllers.cSubjects
{
    public class SubjectController : Controller
    {
        ICourse course = new Course();
        IBranches _branches = new Branches();
        ISubject _subject = new Subject();


        // GET: Subject
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
        public ActionResult CreateSubject()
        {
            var subject_Type = new List<DDL_Data>{
                new DDL_Data() { vchText = "Theory", vchValue = "Theory" } ,
                            new DDL_Data() { vchText = "Practical", vchValue = "Practical" }

            };

            ViewBag.subject_Type = subject_Type.ToList();

            var subject_Category = new List<DDL_Data>{

                            new DDL_Data() { vchText = "Basic Science Courses", vchValue = "BS" } ,
                            new DDL_Data() { vchText = "Engineering Science Courses", vchValue = "ES" },
                            new DDL_Data() { vchText = "Professional Core Courses", vchValue = "Prof" },
                            new DDL_Data() { vchText = "Humanities and Social Sciences including Management Courses", vchValue = "Humanities" },
                            new DDL_Data() { vchText = "Mandatory Courses", vchValue = "Mandatory" }
                        };

            ViewBag.subject_Category = subject_Category.ToList();
            ViewBag.courseList = course.CourseList().ToList();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubject(tbl_MCE_Subject mce_Subject)
        {
            _subject.AddSubject(mce_Subject);

            var subject_Type = new List<DDL_Data>{
                new DDL_Data() { vchText = "Theory", vchValue = "Theory" } ,
                            new DDL_Data() { vchText = "Practical", vchValue = "Practical" }

            };

            ViewBag.subject_Type = subject_Type.ToList();

            var subject_Category = new List<DDL_Data>{

                           new DDL_Data() { vchText = "Basic Science Courses", vchValue = "BS" } ,
                            new DDL_Data() { vchText = "Engineering Science Courses", vchValue = "ES" },
                            new DDL_Data() { vchText = "Professional Core Courses", vchValue = "Prof" },
                            new DDL_Data() { vchText = "Humanities and Social Sciences including Management Courses", vchValue = "Humanities" },
                            new DDL_Data() { vchText = "Mandatory Courses", vchValue = "Mandatory" }
                        };

            ViewBag.subject_Category = subject_Category.ToList();

            ViewBag.courseList = course.CourseList().ToList();

            TempData["Success"] = "Data Inserted Successfully";
            ModelState.Clear();


            return View();
        }

        [HttpGet]
        public ActionResult SubjectDataTable()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GetSubject()
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



            var subjectList = (from a in _subject.SubjectList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                subjectList = subjectList.Where(p => p.vchCourseName.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.vchBranchName.ToLower().Contains(search.ToLower()) ||
                                         p.vchSubjectName.ToLower().Contains(search.ToLower()) ||
                                       p.vchSubjectType.ToString().ToLower().Contains(search.ToLower()));
            }


            //SORT
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                subjectList = subjectList.OrderBy(sortColumn + " " + sortColumnDir);
            }

            recordsTotal = subjectList.Count();
            var data = subjectList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);



            //  return Json(new { data = subjectList }, JsonRequestBehavior.AllowGet);


        }




        public ActionResult DeleteSubject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Subject subject = _subject.SubjectDetails((int)id);

            var subject_Type = new List<DDL_Data>{
                new DDL_Data() { vchText = "Theory", vchValue = "Theory" } ,
                            new DDL_Data() { vchText = "Practical", vchValue = "Practical" }

            };

            ViewBag.subject_Type = subject_Type.ToList();

            var subject_Category = new List<DDL_Data>{

                           new DDL_Data() { vchText = "Basic Science Courses", vchValue = "BS" } ,
                            new DDL_Data() { vchText = "Engineering Science Courses", vchValue = "ES" },
                            new DDL_Data() { vchText = "Professional Core Courses", vchValue = "Prof" },
                            new DDL_Data() { vchText = "Humanities and Social Sciences including Management Courses", vchValue = "Humanities" },
                            new DDL_Data() { vchText = "Mandatory Courses", vchValue = "Mandatory" }
                        };

            ViewBag.subject_Category = subject_Category.ToList();

            ViewBag.courseList = course.CourseList().ToList();
            ViewBag.BranchList = _branches.BranchList().ToList();

            ViewBag.DefaultSubject = subject.intCourseID;
            ViewBag.DefaultBranch = subject.intBranchID;

            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSubject(tbl_MCE_Subject mce_Subject)
        {
            _subject.DeleteSubject(mce_Subject);
            TempData["Success"] = "Data Deleted Successfully";

            ViewBag.courseList = course.CourseList().ToList();
            ViewBag.BranchList = _branches.BranchList().ToList();

            var subject_Type = new List<DDL_Data>{
                new DDL_Data() { vchText = "Theory", vchValue = "Theory" } ,
                            new DDL_Data() { vchText = "Practical", vchValue = "Practical" }

            };

            ViewBag.subject_Type = subject_Type.ToList();

            var subject_Category = new List<DDL_Data>{

                            new DDL_Data() { vchText = "Basic Science Courses", vchValue = "BS" } ,
                            new DDL_Data() { vchText = "Engineering Science Courses", vchValue = "ES" },
                            new DDL_Data() { vchText = "Professional Core Courses", vchValue = "Prof" },
                            new DDL_Data() { vchText = "Humanities and Social Sciences including Management Courses", vchValue = "Humanities" },
                            new DDL_Data() { vchText = "Mandatory Courses", vchValue = "Mandatory" }
                        };
            ViewBag.subject_Category = subject_Category.ToList();




            return RedirectToAction("SubjectDataTable", "Subject");
        }

        public ActionResult EditSubject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Subject subject = _subject.SubjectDetails((int)id);

            var subject_Type = new List<DDL_Data>{
                new DDL_Data() { vchText = "Theory", vchValue = "Theory" } ,
                            new DDL_Data() { vchText = "Practical", vchValue = "Practical" }

            };

            ViewBag.subject_Type = subject_Type.ToList();

            var subject_Category = new List<DDL_Data>{

                            new DDL_Data() { vchText = "Basic Science Courses", vchValue = "BS" } ,
                            new DDL_Data() { vchText = "Engineering Science Courses", vchValue = "ES" },
                            new DDL_Data() { vchText = "Professional Core Courses", vchValue = "Prof" },
                            new DDL_Data() { vchText = "Humanities and Social Sciences including Management Courses", vchValue = "Humanities" },
                            new DDL_Data() { vchText = "Mandatory Courses", vchValue = "Mandatory" }
                        };

            ViewBag.subject_Category = subject_Category.ToList();

            ViewBag.courseList = course.CourseList().ToList();
            ViewBag.BranchList = _branches.BranchList().ToList();

            ViewBag.DefaultSubject = subject.intCourseID;
            ViewBag.DefaultBranch = subject.intBranchID;

            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubject(tbl_MCE_Subject mce_Subject)
        {
            _subject.EditSubject(mce_Subject);
            TempData["Success"] = "Data Updated Successfully";
            ViewBag.courseList = course.CourseList().ToList();
            ViewBag.BranchList = _branches.BranchList().ToList();

            var subject_Type = new List<DDL_Data>{
                new DDL_Data() { vchText = "Theory", vchValue = "Theory" } ,
                            new DDL_Data() { vchText = "Practical", vchValue = "Practical" }

            };

            ViewBag.subject_Type = subject_Type.ToList();

            var subject_Category = new List<DDL_Data>{

                           new DDL_Data() { vchText = "Basic Science Courses", vchValue = "BS" } ,
                            new DDL_Data() { vchText = "Engineering Science Courses", vchValue = "ES" },
                            new DDL_Data() { vchText = "Professional Core Courses", vchValue = "Prof" },
                            new DDL_Data() { vchText = "Humanities and Social Sciences including Management Courses", vchValue = "Humanities" },
                            new DDL_Data() { vchText = "Mandatory Courses", vchValue = "Mandatory" }
                        };
            ViewBag.subject_Category = subject_Category.ToList();


            return RedirectToAction("SubjectDataTable", "Subject");

        }

        public ActionResult SubjectDetails(int? id)
        {
            tbl_MCE_Subject subject = _subject.SubjectDetails((int)id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var subject_Type = new List<DDL_Data>{
                new DDL_Data() { vchText = "Theory", vchValue = "Theory" } ,
                            new DDL_Data() { vchText = "Practical", vchValue = "Practical" }

            };

            ViewBag.subject_Type = subject_Type.ToList();

            var subject_Category = new List<DDL_Data>{

                           new DDL_Data() { vchText = "Basic Science Courses", vchValue = "BS" } ,
                            new DDL_Data() { vchText = "Engineering Science Courses", vchValue = "ES" },
                            new DDL_Data() { vchText = "Professional Core Courses", vchValue = "Prof" },
                            new DDL_Data() { vchText = "Humanities and Social Sciences including Management Courses", vchValue = "Humanities" },
                            new DDL_Data() { vchText = "Mandatory Courses", vchValue = "Mandatory" }
                        };

            ViewBag.subject_Category = subject_Category.ToList();

            ViewBag.courseList = course.CourseList().ToList();
            ViewBag.BranchList = _branches.BranchList().ToList();

            ViewBag.DefaultSubject = subject.intCourseID;
            ViewBag.DefaultBranch = subject.intBranchID;

            return View(subject);
        }


    }
}
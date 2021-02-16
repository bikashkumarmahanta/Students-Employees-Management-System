using MyMCE.Models.Domain.Role;
using MyMCE.Models.IRepository.Role;
using MyMCE.Models.Repository.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Linq.Dynamic;
using System.Net;

namespace MyMCE.Controllers.cRole
{
    public class RoleController : Controller
    {
        IRole _role = new Role();
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateRole()
        {


            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(tbl_MCE_Role mce_role)
        {


            _role.AddRole(mce_role);
            TempData["Success"] = "Data Inserted Successfully";
            ModelState.Clear();
            return View();

        }
        public ActionResult RoleDataTable()
        {
            return View();

        }
        [HttpPost]
        public ActionResult RoleDtls()
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



            var roleList = (from a in _role.RoleList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                roleList = roleList.Where(p => p.vchRoleName.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.vchDescription.ToLower().Contains(search.ToLower())
                                      );
            }


            //SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    roleList = roleList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = roleList.Count();
            var data = roleList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult RoleDetails(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                tbl_MCE_Role globallink = _role.RoleDetails((int)id);
                return View(globallink);
            }
        }

        public ActionResult EditRole(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Role role = _role.RoleDetails((int)id);



            return View(role);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRole(tbl_MCE_Role mce_Role)
        {
            _role.EditRole(mce_Role);
            TempData["Success"] = "Data Updated Successfully";
            return RedirectToAction("RoleDataTable", "Role");
        }

        public ActionResult DeleteRole(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_Role role = _role.RoleDetails((int)id);



            return View(role);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRole(tbl_MCE_Role mce_Role)
        {

            _role.DeleteRole(mce_Role);
            TempData["Success"] = "Data Deleted Successfully";
            return RedirectToAction("RoleDataTable", "Role");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyMCE.Models.Domain.GroupLinkAccess;
using MyMCE.Models.Repository.GroupLinkAccess;
using MyMCE.Models.IRepository.GroupLinkAccess;
using MyMCE.Models.Domain.Role;
using MyMCE.Models.Repository.Role;
using MyMCE.Models.IRepository.Role;
using MyMCE.Models.Domain.PrimaryLink;
using MyMCE.Models.IRepository.PrimaryLink;
using MyMCE.Models.Repository.PrimaryLink;
using System.Net;

namespace MyMCE.Controllers.CGroupLinkAccess
{
    public class GroupLinkAccessController : Controller

    {
        IPrimaryLink plinks = new PrimaryLink();
        IRole role = new Role();
        IGroupLinkAccess _grouplinkaccess = new GroupLinkAccess();

        // GET: GroupLinkAccess
        public ActionResult Index()
        {
            return View();
        }


        // FOR CREATE GROUP LINK ACCESS TABLE
        [HttpGet]
        public ActionResult CreateGroupLinkAccess()
        {
            ViewBag.RoleList = role.RoleList().ToList();
            ViewBag.PlinkList = plinks.PlinkList().ToList();

            return View();
        }
        [HttpPost]
        public ActionResult CreateGroupLinkAccess(tbl_MCE_GroupLinkAccess MCE_GroupLinkAccess)
        {
            _grouplinkaccess.AddGroupLinkAccess(MCE_GroupLinkAccess);
            ModelState.Clear();
            ViewBag.RoleList = role.RoleList().ToList();
            ViewBag.PlinkList = plinks.PlinkList().ToList();



            TempData["Success"] = "Group Link Access Created Successfully";
            return View();
        }





        //FOR GROUP LINK ACCESS DATA TABLE PAGE

        public ActionResult ViewGroupLinkAccessDataTable()
        {
            return View();

        }
        [HttpPost]
        public ActionResult GroupLinkDetails()
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


            var GroupLinkAccessList = (from a in _grouplinkaccess.GroupLinkAccessList() select a);

            string search = Request.Form.GetValues("search[value]")[0];
            // Verification.  
            if (!string.IsNullOrEmpty(search) &&
                !string.IsNullOrWhiteSpace(search))
            {
                // Apply search  
                GroupLinkAccessList = GroupLinkAccessList.Where(p => p.vchDescription.ToString().ToLower().Contains(search.ToLower()) ||
                                                 p.vchPLinkName.ToLower().Contains(search.ToLower())

                                       );
            }


            ////SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    PlinkList = PlinkList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = GroupLinkAccessList.Count();
            var data = GroupLinkAccessList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);


        }

        //FOR GROUP LINK ACCESS EDIT PAGE

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_GroupLinkAccess GroupLinkAccess = _grouplinkaccess.GroupLinkAccessDetails((int)id);


            ViewBag.RoleList = role.RoleList().ToList();
            ViewBag.PlinkList = plinks.PlinkList().ToList();

            return View(GroupLinkAccess);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_MCE_GroupLinkAccess mce_GroupLinkAccess)

        {
            _grouplinkaccess.EditGroupLinkAccess(mce_GroupLinkAccess);
            TempData["Success"] = "Data Updated Successfully";
            return RedirectToAction("ViewGroupLinkAccessDataTableWithSearchPanel", "GroupLinkAccess");
        }

        //FOR DELETE  GROUP LINK ACCESS

        public ActionResult DeleteGroupLinkAccess(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_GroupLinkAccess GroupLinkAccess = _grouplinkaccess.GroupLinkAccessDetails((int)id);


            ViewBag.RoleList = role.RoleList().ToList();
            ViewBag.PlinkList = plinks.PlinkList().ToList();

            return View(GroupLinkAccess);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGroupLinkAccess(tbl_MCE_GroupLinkAccess mce_GroupLinkAccess)
        {

            _grouplinkaccess.DeleteGroupLinkAccess(mce_GroupLinkAccess);
            TempData["Success"] = "Data Deleted Successfully";
            return RedirectToAction("ViewGroupLinkAccessDataTableWithSearchPanel", "GroupLinkAccess");
        }


        //FOR DETAILS OF  GROUP LINK ACCESS 

        public ActionResult GroupLinkAccessDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MCE_GroupLinkAccess GroupLinkAccess = _grouplinkaccess.GroupLinkAccessDetails((int)id);
            return View(GroupLinkAccess);
        }

        public ActionResult ViewGroupLinkAccessDataTableWithSearchPanel()
        {


            return View();
        }
        [HttpPost]
        //This post method calls in View page thorough AJax call to bind the data in JQuery Datatable
        //Server side processing concept used to bind the data in JQuery
        public ActionResult GetGroupLinkAccessForSearchPanel(GroupLinkAccessSearchPanel groupLinkAccessSearchPanel)
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


            var groupLinkAccessList = (from a in _grouplinkaccess.GroupLinkAccessList(groupLinkAccessSearchPanel) select a);

            ////SORT
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    primaryLinkList = primaryLinkList.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = groupLinkAccessList.Count();
            var data = groupLinkAccessList.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);


        }
    }
}
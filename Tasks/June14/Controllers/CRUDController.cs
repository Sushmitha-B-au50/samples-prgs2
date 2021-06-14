using MVCwithADO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCwithADO.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        // GET: CRUD
        public ActionResult Index()
        {
            CRUDModel md1 = new CRUDModel();
            DataTable dt = md1.DisplayBook();
            return View("Home",dt);
        }

        public ActionResult Insert()
        {
            return View("Create");
        }
        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string Title = frm["txtTitle"];
                int aid = Convert.ToInt32(frm["txtaid"]);
                double Price = Convert.ToDouble(frm["txtPrice"]);
                int rowIns = mdl.NewBook(Title, aid, Price);
                return RedirectToAction("Index");

            }

            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult AuthorIndex()
        {
            CRUDModel md1 = new CRUDModel();
            DataTable dt = md1.DisplayAuthor();
            return View("AuthorIndex", dt);
        }

        public ActionResult NewAuthor()
        {
            return View("CreateAuthor");
        }
        public ActionResult InsertNewAuthor(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string AuthorName= frm["txtname"];
                int rowIns = mdl.NewAuthor(AuthorName);
                return RedirectToAction("AuthorIndex");

            }

            else
            {
                return RedirectToAction("AuthorIndex");
            }
        }
    }
}
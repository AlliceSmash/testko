using System.Web.Mvc;
using TestKo.Models;

namespace TestKo.Controllers
{
    public class SelectOptionController : Controller
    {
        // GET: SelectOption
        public ActionResult Index()
        {
            var model = new TestKo.Models.SelectOptionModel();
            return View(model);
        }

        // GET: SelectOption/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SelectOption/Create
        public ActionResult Create()
        {
            var model = new TestKo.Models.SelectOptionModel();
            return View(model);
        }

        // POST: SelectOption/Create
        [HttpPost]
        public ActionResult Create(SelectOptionModel selectOptionModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                var modelSaved = selectOptionModel;
                return RedirectToAction("Create");
            }

            var model = new SelectOptionModel();
            return View(model);

        }

        // GET: SelectOption/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SelectOption/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SelectOption/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SelectOption/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

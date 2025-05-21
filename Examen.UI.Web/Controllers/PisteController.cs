using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.UI.Web.Controllers
{
    public class PisteController : Controller
    {
        IServicePiste spiste;

        public PisteController(IServicePiste spiste)
        {
            this.spiste = spiste;
        }


        // GET: PisteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PisteController/Details/5
        public ActionResult Details(int id)
        {
            return View(spiste.Get(p => p.PisteId == id));
        }

        // GET: PisteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PisteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PisteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PisteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PisteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PisteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

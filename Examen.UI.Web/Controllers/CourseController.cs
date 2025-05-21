using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.UI.Web.Controllers
{
    public class CourseController : Controller
    {
        IServiceCourse scourse;
        IServicePiste spiste;

        public CourseController(IServiceCourse scourse, IServicePiste spiste)
        {
            this.scourse = scourse;
            this.spiste = spiste;
        }


        // GET: CourseController
        public ActionResult Index(string? nom)
        {
            if(nom != null)
            {
                return View(scourse.GetMany(c => c.NomCourse.Contains(nom)));
            }
            return View(scourse.GetMany());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            ViewBag.lsPiste = new SelectList(spiste.GetMany(), "PisteId", "Nom");
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course collection)
        {
            scourse.Add(collection);
            scourse.Commit();
            return RedirectToAction(nameof(Index));
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
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

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
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

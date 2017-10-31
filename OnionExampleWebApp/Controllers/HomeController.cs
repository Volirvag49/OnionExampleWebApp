using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Data;
using Domain.Model;
using System.Net;

namespace OnionExampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var readers = unitOfWork.ReaderRepository.GetAll();
            return View(readers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reader reader = unitOfWork.ReaderRepository.GetById(id);
            if (reader != null)
            {
                return PartialView("Details", reader);
            }

            return View(reader);
        }

        //Returns Create.cshtml
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reader reader)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ReaderRepository.Create(reader);
                unitOfWork.Commit();
                return RedirectToAction("List");
            }

            return View(reader);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reader reader = unitOfWork.ReaderRepository.GetById(id);
            if (reader != null)
            {
                return View(reader);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reader reader)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ReaderRepository.Update(reader);
                unitOfWork.Commit();

                return RedirectToAction("List");
            }

            return View(reader);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reader reader = unitOfWork.ReaderRepository.GetById(id);
            if (reader != null)
            {
                return View(reader);
            }

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reader reader = unitOfWork.ReaderRepository.GetById(id);
            if (reader != null)
            {
                unitOfWork.ReaderRepository.Delete(reader);
                unitOfWork.Commit();
                return RedirectToAction("List");

            }

            return View(reader);

        }
    }
}
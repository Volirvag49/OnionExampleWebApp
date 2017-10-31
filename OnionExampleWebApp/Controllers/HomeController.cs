using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Data;
using Domain.Model;
using System.Net;
using System.Threading.Tasks;

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

        public async Task<ActionResult> List()
        {
            var readers = await unitOfWork.ReaderRepository.GetAllAsync();
            return View(readers);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reader reader = await unitOfWork.ReaderRepository.GetByIdAsyn(id);

            if (reader != null)
            {
                return View("Details", reader);
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
        public async Task<ActionResult> Create(Reader reader)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ReaderRepository.Create(reader);
                await unitOfWork.CommitAsync();

                return RedirectToAction("List");
            }

            return View(reader);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reader reader = await unitOfWork.ReaderRepository.GetByIdAsyn(id);
            if (reader != null)
            {
                return View(reader);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Reader reader)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ReaderRepository.Update(reader);
                await unitOfWork.CommitAsync();

                return RedirectToAction("List");
            }

            return View(reader);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reader reader = await unitOfWork.ReaderRepository.GetByIdAsyn(id);

            if (reader != null)
            {
                return View(reader);
            }

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reader reader = await unitOfWork.ReaderRepository.GetByIdAsyn(id);
            if (reader != null)
            {
                unitOfWork.ReaderRepository.Delete(reader);
                await unitOfWork.CommitAsync();

                return RedirectToAction("List");
            }

            return View(reader);

        }
    }
}
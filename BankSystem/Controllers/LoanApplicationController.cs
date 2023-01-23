using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    public class LoanApplicationController : Controller
    {
        //[Authorize(Roles = "Client")]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // GET: LoanApplicationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoanApplicationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanApplicationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            return RedirectToAction("Index", "Home");
            //throw new Exception();
            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: LoanApplicationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoanApplicationController/Edit/5
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

        // GET: LoanApplicationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoanApplicationController/Delete/5
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

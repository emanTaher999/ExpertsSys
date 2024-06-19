using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SudaneseExpSYS.Models;
using SudaneseExpSYS.Repository.Base;
using SudaneseExpSYS.Resourses;

namespace SudaneseExpSYS.Controllers
{
    [Authorize(Roles =clcRoles.AdminRole)]
    public class FiledsController : Controller
    {
        private readonly IRepositroy<Filed> repositroy;
        private readonly IToastNotification toastNotification;
        public FiledsController(IRepositroy<Filed> repositroy, IToastNotification toastNotification)
        {
            this.repositroy = repositroy;
            this.toastNotification = toastNotification; 
        }
        public async Task<IActionResult> Index()
        {
            return View(await repositroy.FindAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filed = await repositroy.FindByIdAsyn(id.Value);
            if (filed == null)
            {
                return NotFound();
            }

            return View(filed);
        }


        [HttpGet]
        // GET: Filds/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Filds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Filed filed)
        {
            if (ModelState.IsValid)
            {
                await repositroy.AddOneAsync(filed);
                toastNotification.AddSuccessToastMessage(Resource.CreateMsg);

                return RedirectToAction(nameof(Index));
            }
            return View(filed);
        }

        // GET: Filds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filed = await repositroy.FindByIdAsyn(id.Value);
            if (filed == null)
            {
                return NotFound();
            }
            return View(filed);
        }

        // POST: Filds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FId,FName")] Filed filed)
        {
            if (id != filed.FId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await repositroy.UpdateOneAsync(filed);
                toastNotification.AddSuccessToastMessage(Resource.UpdateMsg);

                return RedirectToAction(nameof(Index));
            }
            return View(filed);
        }

        // GET: Filds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filed = await repositroy.FindByIdAsyn(id.Value);
            if (filed == null)
            {
                return NotFound();
            }

            return View(filed);
        }

        // POST: Filds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filed = await repositroy.FindByIdAsyn(id);
            if (filed != null)
            {
                await repositroy.DeleteOneAsync(filed);

                toastNotification.AddWarningToastMessage(Resource.DeleteMsg);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}

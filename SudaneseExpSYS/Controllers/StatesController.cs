using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SudaneseExpSYS.Models;
using SudaneseExpSYS.Repository.Base;
using SudaneseExpSYS.Resourses;


namespace SudaneseExpSYS.Controllers
{
    [Authorize(Roles =clcRoles.AdminRole)]
    public class StatesController : Controller
    {
        private readonly IRepositroy<State> _repositroy;
        private readonly IToastNotification _toastNotification;


        public StatesController(IRepositroy<State> repositroy, IToastNotification toastNotification)
        {
            _repositroy = repositroy;
            _toastNotification = toastNotification;

        }

        // GET: States
        public async Task<IActionResult> Index()
        {
            return View(await _repositroy.FindAllAsync());
        }

        // GET: States/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await _repositroy.FindByIdAsyn(id.Value);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        [HttpGet]
        // GET: States/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: States/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(State state)
        {
            if (ModelState.IsValid)
            {
                await _repositroy.AddOneAsync(state);
                _toastNotification.AddSuccessToastMessage(Resource.CreateMsg);

                return RedirectToAction(nameof(Index));
            }
            return View(state);
        }

        // GET: States/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var state = await _repositroy.FindByIdAsyn(id.Value);
            if (state == null)
            {
                return NotFound();
            }
            return View(state);
        }

        // POST: States/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SId,SName")] State state)
        {
            if (id != state.SId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _repositroy.UpdateOneAsync(state);
                _toastNotification.AddSuccessToastMessage(Resource.UpdateMsg);


                return RedirectToAction(nameof(Index));
            }
            return View(state);
        }

        // GET: States/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await _repositroy.FindByIdAsyn(id.Value);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var state = await _repositroy.FindByIdAsyn(id);
            if (state != null)
            {
                await _repositroy.DeleteOneAsync(state);
                _toastNotification.AddWarningToastMessage(Resource.DeleteMsg);

            }

            return RedirectToAction(nameof(Index));
        }

       
    }
}

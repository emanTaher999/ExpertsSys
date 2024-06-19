using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using SudaneseExpSYS.Data;
using SudaneseExpSYS.Models;
using SudaneseExpSYS.Repository.Base;
using SudaneseExpSYS.Resourses;

namespace SudaneseExpSYS.Controllers
{
    [Authorize(Roles = clcRoles.AdminRole)]
    public class CountriesController : Controller
    {
        private readonly IRepositroy<Country> _repositroy;
        private readonly IToastNotification _toastNotification;

        public CountriesController(IRepositroy<Country> repositroy, IToastNotification toastNotification)
        {
            _repositroy = repositroy;
            _toastNotification = toastNotification;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            return View(await _repositroy.FindAllAsync());
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _repositroy.FindByIdAsyn(id.Value);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpGet]
        // GET: Countries/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country country)
        {
            if (ModelState.IsValid)
            {
                await _repositroy.AddOneAsync(country);
                
                _toastNotification.AddSuccessToastMessage(Resourses.Resource.CreateMsg);
                //TempData["AlertAdd"] = "success";

                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _repositroy.FindByIdAsyn(id.Value);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CId,CName")] Country country)
        {
            if (id != country.CId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                await _repositroy.UpdateOneAsync(country);
                _toastNotification.AddSuccessToastMessage(Resourses.Resource.UpdateMsg);

                // TempData["AlertEdit"] = "success";


                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _repositroy.FindByIdAsyn(id.Value);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await _repositroy.FindByIdAsyn(id);
            if (country != null)
            {
               await _repositroy.DeleteOneAsync(country);
                _toastNotification.AddWarningToastMessage(Resourses.Resource.DeleteMsg);

               // TempData["AlertDelete"] = "success";
            }

            return RedirectToAction(nameof(Index));
        }

        //private bool CountryExists(int id)
        //{
        //    return _repositroy.Any(id);
        //}
    }
}

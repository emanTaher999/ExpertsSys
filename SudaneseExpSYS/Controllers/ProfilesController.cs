using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SudaneseExpSYS.Data;
using SudaneseExpSYS.Models;
using SudaneseExpSYS.Repository.Base;
using System.Collections.Generic;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using SudaneseExpSYS.Resourses;
using NToastNotify;


namespace SudaneseExpSYS.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly IRepositroy<Profile> repositroy;
        private readonly IToastNotification toastNotification;
        [Obsolete]
        private readonly IHostingEnvironment host;
        private AppDbContext db;

        [Obsolete]
        public ProfilesController(IRepositroy<Profile> repositroy, IHostingEnvironment host, AppDbContext db, IToastNotification toastNotification)
        {
            this.repositroy = repositroy;
            this.host = host;
            this.db = db;
            this.toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            return View(await repositroy.FindAllAsync());
        }
        public async Task<IActionResult> Show()
        {
            return View(await repositroy.FindAllAsync());
        }
        public static List<SelectListItem> GetAchivement()
        {
            var selectList = new List<SelectListItem>
                {
                new SelectListItem {Text = "ماجستير", Value = "Master"},
                new SelectListItem {Text ="دكتوراة", Value = "Phd"},
                new SelectListItem {Text ="استاذية", Value = "Prof"}
            };
            return selectList;
        }

        public static List<SelectListItem> GetGender()
        {
            var selectList = new List<SelectListItem>
                {
                new SelectListItem {Text = "ذكر", Value = "male"},
                new SelectListItem {Text ="انثى", Value = "female"},
              
            };
            return selectList;
        }
        public void GetFilds()
        {
            var FildList = (from fild in db.fileds
                               select new SelectListItem()
                               {
                                   Text = fild.FName,
                                   Value = fild.FId.ToString(),
                               }).ToList();
            FildList.Insert(0, new SelectListItem()
            {
                Text = "---أختر---",
                Value = string.Empty
            });

            ViewBag.FildList = FildList;
        }

        public void GetCountry()
        {
            var CountryList = (from country in db.Countries
                               select new SelectListItem()
                               {
                                   Text = country.CName,
                                   Value = country.CId.ToString(),
                               }).ToList();
            CountryList.Insert(0, new SelectListItem()
            {
                Text = "---أختر---",
                Value = string.Empty
            });

            ViewBag.CountryList = CountryList;
        }

        public void GetState()
        {
            var StateList = (from state in db.states
                               select new SelectListItem()
                               {
                                   Text = state.SName,
                                   Value = state.SId.ToString(),
                               }).ToList();
            StateList.Insert(0, new SelectListItem()
            {
                Text = "---أختر---",
                Value = string.Empty
            });

            ViewBag.StateList = StateList;
        }

        public void ViewBagesList()
        {
            ViewBag.GetAchivment = GetAchivement();
            ViewBag.Gender = GetGender();

            var CountryList = (from country in db.Countries
                               select new SelectListItem()
                               {
                                   Text = country.CName,
                                   Value = country.CId.ToString(),
                               }).ToList();
            CountryList.Insert(0, new SelectListItem()
            {
                Text = "---أختر---",
                Value = string.Empty
            });

            ViewBag.CountryList = CountryList;

            var FildList = (from fild in db.fileds
                            select new SelectListItem()
                            {
                                Text = fild.FName,
                                Value = fild.FId.ToString(),
                            }).ToList();
            FildList.Insert(0, new SelectListItem()
            {
                Text = "---أختر---",
                Value = string.Empty
            });

            ViewBag.FildList = FildList;

            var StateList = (from state in db.states
                             select new SelectListItem()
                             {
                                 Text = state.SName,
                                 Value = state.SId.ToString(),
                             }).ToList();
            StateList.Insert(0, new SelectListItem()
            {
                Text = "---أختر---",
                Value = string.Empty
            });

            ViewBag.StateList = StateList;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBagesList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profile profile)
        {
            if (ModelState.IsValid)
            {
                if (profile.ClientFile != null)
                {
                    MemoryStream stream = new MemoryStream();
                    profile.ClientFile.CopyTo(stream);
                    profile.dbImage = stream.ToArray();
                }
                profile.CreatedDay = DateTime.Now;
                await repositroy.AddOneAsync(profile);
                toastNotification.AddSuccessToastMessage(Resource.CreateMsg);

                return RedirectToAction("Index");
            }
            else
            {
                return View(profile);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var profile =await repositroy.FindByIdAsyn(id);
            ViewBagesList();
            return View(profile);   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Profile profile)
        {
            if (ModelState.IsValid)
            {
                if(profile.ClientFile != null)
                {
                    MemoryStream stream = new MemoryStream();
                    profile.ClientFile.CopyTo(stream);
                    profile.dbImage = stream.ToArray();
                }
                await repositroy.UpdateOneAsync(profile);
                toastNotification.AddSuccessToastMessage(Resource.UpdateMsg);


                return RedirectToAction("Index");
            }
            else
            {
                return View(profile);
            }
           
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var profile = await repositroy.FindByIdAsyn(id);
            ViewBagesList();
            return View(profile);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, Profile profile)
        {
            if (ModelState.IsValid)
            {
                if (profile.ClientFile != null)
                {
                    MemoryStream stream = new MemoryStream();
                    profile.ClientFile.CopyTo(stream);
                    profile.dbImage = stream.ToArray();
                }
                await repositroy.DeleteOneAsync(profile);
                toastNotification.AddSuccessToastMessage(Resource.UpdateMsg);


                return RedirectToAction("Index");
            }
            else
            {
                return View(profile);
            }

        }
    }
}

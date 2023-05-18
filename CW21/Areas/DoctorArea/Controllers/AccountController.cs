using Microsoft.AspNetCore.Mvc;
using CW21.DAL.Entities;
using CW21.Models.ViewModels;
using CW21.Repositories;
using CW21.Repositories.Doctors;

namespace CW21.Areas.DoctorArea.Controllers
{
    [Area("DoctorArea")]
    public class AccountController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;

        public AccountController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IActionResult RegisterDoctor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterDoctor(Doctor doctor)
        {
            int result = _doctorRepository.RegisterDoctor(doctor);
            if (result == 0)
            {
                ViewBag.message = "این کاربر موجود است";
                return View();
            }
            else
            {
                ViewBag.message = "کاربر ثبت شد";
                return View();
            }
        }

        public IActionResult LoginDoctor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginDoctor(LoginViewModel model)
        {
            var result = _doctorRepository.LoginDoctor(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "نام کاربری یا کلمه عبور اشتباه است";
                return View();
            }
        }
    }
}

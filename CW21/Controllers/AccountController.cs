using CW21.DAL.Entities;
using CW21.Models.ViewModels;
using CW21.Repositories;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CW21.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILogger<AccountController> _logger;
        
       public AccountController(IPatientRepository patientRepository, ILogger<AccountController> logger)
        {
            _patientRepository = patientRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                int x = 2;
                int y = 0;
                int z;
               z= x / y ;
            }
            catch (Exception e)
            {

               _logger.LogError($"Salamaleykom: {e.Message}");
                Log.ForContext("CrudState","Test")
                    .ForContext("ProductId",1)
                    .Error($"Dorood bar shoma: {e.Message}");
               return View();
            }
            return View();
        }
        //http://localhost:5341/
        public IActionResult RegisterPatient()
        {

            return View();
        }
        [HttpPost]
        public IActionResult RegisterPatient(Patient patient)
        {

            int result = _patientRepository.RegisterPatient(patient);
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


        public IActionResult LoginPatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPatient(LoginViewModel model)
        {
            var result = _patientRepository.LoginPatient(model);
            if (result)
            {
                return Redirect("/Dashbored/Index");
            }
            else
            {
                ViewBag.message = "نام کاربری یا کلمه عبور اشتباه است";
                return View();
            }
        }

    }
}

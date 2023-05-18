using CW21.DAL.Entities;
using CW21.Repositories.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace CW21.Areas.DoctorArea.Controllers
{
    [Area("DoctorArea")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            ViewBag.DoctorId = id;
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appoinment appointment)
        {
            if (!_appointmentRepository.IsExist(appointment.StartTime))
            {
                _appointmentRepository.Create(appointment);
            }
            else
            {
                ViewBag.Message = "متاسفانه مقادیر ورودی تداخل دارد...";
            }
            
            return View();
        }
    }
}

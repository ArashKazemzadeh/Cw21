using CW21.Repositories.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace CW21.Areas.DoctorArea.Controllers
{
    [Area("DoctorArea")]
    public class DashboredController : Controller
    {
        
        private readonly IDoctorRepository _doctorRepository;

        public DashboredController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        
        
        
        
        
        
        public IActionResult Index()
        {
            var res = _doctorRepository.getAllAppoinmentsById(1);
            
            
            return View(res);
        }
    }
}

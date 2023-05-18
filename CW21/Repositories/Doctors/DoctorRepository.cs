using CW21.DAL.Entities;
using CW21.Models.ViewModels;
using CW21.Models;
using Microsoft.EntityFrameworkCore;
using CW21.DAL.Context;

namespace CW21.Repositories.Doctors
{
    public class DoctorRepository : IDoctorRepository
    {

        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool LoginDoctor(LoginViewModel model)
        {
            var result = _context.Doctors.FirstOrDefault(p => p.UserName == model.UserName && p.PassWord == model.Password);
            if (result == null)
            {
                return false;
            }
            else
            {
                CurrentUser.UserId = result.Id;
                CurrentUser.Role = RoleEnum.Doctor;
                return true;
            }
        }

        public int RegisterDoctor(Doctor doctor)
        {
            var existeddoctor = _context.Doctors.
                FirstOrDefault(p => p.UserName == doctor.UserName);
            if (existeddoctor == null)
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return doctor.Id;
            }
            else
            {
                return 0;
            }
        }

        public List<Appoinment> getAllAppoinmentsById(int id)
        {
            return _context.Appoinments.Where(a => a.DoctorId == id).Include(x=>x.Patient).ToList();
        }
        
        
        
        
        
        
        
    }
}

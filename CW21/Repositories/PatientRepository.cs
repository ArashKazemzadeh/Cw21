using CW21.DAL.Context;
using CW21.DAL.Entities;
using CW21.Models;
using CW21.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CW21.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool LoginPatient(LoginViewModel model)
        {
            var result = _context.Patients.FirstOrDefault(p => p.UserName == model.UserName && p.PassWord == model.Password);
            if (result == null)
            {
                return false;
            }
            else
            {
                CurrentUser.UserId = result.Id;
                CurrentUser.Role = RoleEnum.Patient;
                return true;
            }
        }

        public int RegisterPatient(Patient patient)
        {
            var existedPatient = _context.Patients.FirstOrDefault(p => p.UserName == patient.UserName);
            if (existedPatient != null)
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();
                return patient.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}

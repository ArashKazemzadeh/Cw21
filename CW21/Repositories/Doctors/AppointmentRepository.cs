using CW21.DAL.Context;
using CW21.DAL.Entities;
using System.Runtime.InteropServices;
using NuGet.Configuration;

namespace CW21.Repositories.Doctors
{
    public class AppointmentRepository:IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public int Create(Appoinment appointment)
        {
            Appoinment ap = new Appoinment()
            {

                StartTime = appointment.StartTime,
                EndTime = appointment.StartTime.AddMinutes(30),
                DoctorId = appointment.DoctorId
                
            };
            
            
            
                _context.Appoinments.Add(ap);
                _context.SaveChanges();
                return ap.Id;
            
        }


        public bool IsExist(DateTime startDate)
        {
            return _context.Appoinments.Any(x => x.StartTime == startDate);
        }
        
        
    }
}

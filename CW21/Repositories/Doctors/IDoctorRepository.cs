using CW21.DAL.Entities;
using CW21.Models.ViewModels;

namespace CW21.Repositories.Doctors
{
    public interface IDoctorRepository
    {
        bool LoginDoctor(LoginViewModel model);
        int RegisterDoctor(Doctor doctor);

        List<Appoinment> getAllAppoinmentsById(int id);




    }
}
using CW21.DAL.Entities;
using CW21.Models.ViewModels;

namespace CW21.Repositories
{
    public interface IPatientRepository
    {
        int RegisterPatient(Patient patient);
        bool LoginPatient(LoginViewModel model);
    }
}
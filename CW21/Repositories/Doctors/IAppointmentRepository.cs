using CW21.DAL.Entities;

namespace CW21.Repositories.Doctors;

public interface IAppointmentRepository
{

    int Create(Appoinment appointment);

    bool IsExist(DateTime startDate);

}
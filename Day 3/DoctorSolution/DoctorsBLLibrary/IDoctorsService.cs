using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using DoctorsDALLibrary;
using DoctorModelLibrary;

namespace DoctorsBLLibrary
{
    public interface IDoctorsService
    {
        public Doctor AddDoctor(Doctor doctor);
        public Doctor UpdateDoctorPhoneNumber(int id, string phone);

        public Doctor UpdateDoctorExperience(int id, int experience, string action);

        public Doctor GetDoctor(int id);

        public List<Doctor> GetAllDoctors();

        public Doctor Delete(int id);


    }

}
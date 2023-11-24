
using System;
using System.Collections.Generic;
using DoctorModelLibrary;
using DoctorsDALLibrary;

namespace DoctorsBLLibrary
    {
        public class DoctorsService : IDoctorsService
        {
            IRepository repository;

            public DoctorsService()
            {
                repository = new DoctorsRepository();
            }
            public Doctor AddDoctor(Doctor doctor)
            {
                var res = repository.Add(doctor);
                if (res != null)
                {
                    return res;
                }
                throw new NotAddedException();
            }

            public Doctor Delete(int id)
            {
                var doctor = GetDoctor(id);
                if (doctor != null)
                {
                    repository.Delete(id);
                    return doctor;
                }
                throw new NoDoctorException();
            }
            public Doctor GetDoctor(int id)
            {
                var result = repository.GetById(id);
                if (result != null)
                    return result;
                throw new NoSuchDoctorException();
            }

            public List<Doctor> GetAllDoctors()
            {
                var res = repository.GetAll();
                if (res.Count != 0)
                {
                    return res;
                }
                throw new NotImplementedException();
            }



            public Doctor UpdateDoctorExperience(int id, int experience, string action)
            {
                var res = GetDoctor(id);
                if (res != null)
                {
                    if (action == "add")
                    {
                        res.Experience += experience;

                    }
                    else if (action == "remove")
                    {
                        res.Experience -= experience;
                    }
                    else
                        throw new InValidUpdateActionException();
                    return repository.Update(res);
                }
                throw new NoSuchDoctorException();
            }

            public Doctor UpdateDoctorPhoneNumber(int id, string phone)
            {
                var doctor = GetDoctor(id);
                if (doctor != null)
                {
                    doctor.PhoneNumber = phone;
                    var result = repository.Update(doctor);
                    return result;

                }
                throw new NoSuchDoctorException();
            }
        }
}
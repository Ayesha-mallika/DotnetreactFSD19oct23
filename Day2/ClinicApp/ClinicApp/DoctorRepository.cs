using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    internal class DoctorRepository
    {
        List<Doctor> doctors;

        public DoctorRepository()
        {
            doctors = new List<Doctor>();

        }
        int GetDoctorId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors[doctors.Count - 1].Id;
            return ++id;
        }

        public Doctor AddDoctor(Doctor d)
        {
            int id = GetDoctorId();
            Doctor doctor = new Doctor();
            doctor.Id = id;
            doctors.Add(doctor);
            return doctor;
        }
        public List<Doctor> GetDoctors()
        {
            return doctors;
        }
        public void ModifyDoctorPhone(int id, string phone)
        {
            Doctor doctor = GetDoctorById(id);
            if (doctor != null)
            {
                doctor.Phone = phone;
            }
            else
                Console.WriteLine("Invalid choice:");
        }

        public Doctor ModifyDoctorExperience(int id, int experience)
        {
            Doctor doctor = GetDoctorById(id);
            if (doctor != null)
            {
                doctor.Experience = experience;
            }
            return doctor;
        }

        public Doctor DeleteDoctor(int id)
        {
            Doctor doctor = GetDoctorById(id);
            if (doctor != null)
            {
                doctors.Remove(doctor);
                Console.WriteLine("Doctor deleted");
                return doctor;
            }
            return null;

        }

        public Doctor GetDoctorById(int id)
        {
            foreach (var doctor in doctors)
            {
                if (doctor.Id == id)
                {
                    return doctor;
                }
            }
            return null;
        }
    }
}


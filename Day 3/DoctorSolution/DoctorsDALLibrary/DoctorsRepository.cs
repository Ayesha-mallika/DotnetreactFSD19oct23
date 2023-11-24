using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DoctorsDALLibrary;
using DoctorModelLibrary;
using System.Reflection.Metadata.Ecma335;

namespace DoctorsDALLibrary
{
    public class DoctorsRepository : IRepository
    {
        Dictionary<int, Doctor> d = new Dictionary<int, Doctor>();
        public Doctor Add(Doctor doctor)
        {
            int id = GenerateId();
            try
            {
                doctor.Id = id;
                d.Add(doctor.Id, doctor);
                return doctor;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Doctor already exists");
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public int GenerateId()
        {
            if (d.Count == 0)
                return 1;
            int id = d.Keys.Max();
            return ++id;
        }


        public Doctor Update(Doctor doctor)
        {
            if (d.ContainsKey(doctor.Id))
            {
                d[doctor.Id] = doctor;
                return doctor;
            }
            return null;
        }
        public Doctor Delete(int id)
        {
            if (d.ContainsKey(id))
            {
                var res = d[id];
                d.Remove(id);
                return res;
            }
            return null;
        }
        public Doctor GetById(int id)
        {
            if (d.ContainsKey(id))
            {
                return d[id];
            }
            return null;
        }

        public List<Doctor> GetAll()
        {
            return d.Values.ToList();
        }


    }
}
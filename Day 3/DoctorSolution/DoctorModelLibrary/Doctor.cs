using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }


        public Doctor()
        {
            Id = 0;
            PhoneNumber = null;
            Experience = 0;

        }
        /// <summary>
        /// Construct the doctor object with essential features
        /// </summary>
        /// <param name="id">Doctor's  id</param>
        /// <param name="name">Doctor's Name</param>
        /// <param name="phone">Doctor's Phone number</param>
        /// <param name="specialization">Doctor's specialization</param>
        /// <param name="experience">Doctor's Experience</param>

        public Doctor(int id, string name, string phone, string specialization, int experience)
        {
            Id = id;
            Name = name;
            PhoneNumber = phone;
            Specialization = specialization;
            Experience = experience;
        }




        public override string ToString()
        {
            return $"Doctor id:{Id}\n Doctor Name:{Name} \n Doctor Phone: {PhoneNumber} " +
                $"\nDoctor Specialization:{Specialization}\n Doctor Experience: {Experience}\n";
        }

    }
}
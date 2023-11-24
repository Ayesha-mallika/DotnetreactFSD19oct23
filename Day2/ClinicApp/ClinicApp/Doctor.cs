using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    internal class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String Phone { get; set; }
        public int Experience { get; set; }
        public Doctor()
        {
            Experience = 0;
        }

        public Doctor(int id, string name, string phone, int experience)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Experience = experience;
        }
        public override string ToString()
        {
            return $"Doctor id:{Id}\n Doctor Name:{Name} \n Doctor Phone: {Phone} \n Doctor Experience: {Experience}\n";
        }
    }
}

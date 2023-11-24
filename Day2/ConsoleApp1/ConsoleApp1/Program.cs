using System.Numerics;

namespace ConsoleApp1
{
    internal class Program
    {
        DoctorRepository doctorRepository;

        public Program()
        {
            doctorRepository = new DoctorRepository();
        }

        public void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Modify Doctor Phone");
            Console.WriteLine("3. Modify Doctor Experience");
            Console.WriteLine("4. Delete Doctor");
            Console.WriteLine("5. Print details");
            Console.WriteLine("0. Exit");
        }
        void StartAdminActivities()
        {
            int ch;
            do
            {
                DisplayAdminMenu();
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 0:
                        Console.WriteLine("Exit the application");
                        break;
                    case 1:
                        AddDoctor();
                        break;
                    case 2:
                        ModifyDoctorPhone();
                        break;
                    case 3:
                        ModifyDoctorExperience();
                        break;
                    case 4:
                        DeleteDoctor();
                        break;
                    case 5:
                        PrintDetails();
                        break;



                    default:
                        Console.WriteLine("Invalid choice that you have entered!!");
                        break;
                }

            } while (ch != 0);
        }


        private void AddDoctor()
        {
            Doctor d = new Doctor();
            Console.WriteLine("Enter the name of the doctor:");
            d.Name = Console.ReadLine();
            Console.WriteLine("Enter the phone number :");
            d.Phone = Console.ReadLine();
            Console.WriteLine("Enter the experience :");
            d.Experience = Convert.ToInt32(Console.ReadLine());
            doctorRepository.AddDoctor(d);
            Console.WriteLine("Doctor details  added successfully!!");
            Console.WriteLine("--------------------------------------");
        }


        private void ModifyDoctorPhone()
        {
            Console.WriteLine("Enter the doctor Id you want to modify the phone number: ");

            int id = Convert.ToInt32(Console.ReadLine());

            Doctor doctor = doctorRepository.GetDoctorById(id);

            if (doctor != null)
            {
                Console.WriteLine("Enter the new phone number: ");
                string newph = Console.ReadLine();
                doctorRepository.ModifyDoctorPhone(id, newph);
                Console.WriteLine("new phone number modified successfully!");
                Console.WriteLine("-----------------------");

            }
            else
            {
                Console.WriteLine("Please enter a valid doctor ID.");
            }
        }

        private void ModifyDoctorExperience()
        {
            Console.WriteLine("Enter the doctor id you want to modify the  experience: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Doctor doctor = doctorRepository.GetDoctorById(id);

            if (doctor != null)
            {
                Console.WriteLine("Enterthe new experience: ");
                int newExperience = Convert.ToInt32(Console.ReadLine());
                doctorRepository.ModifyDoctorExperience(id, newExperience);
                Console.WriteLine(" new experience modified successfully!");
                Console.WriteLine("----------");

            }
            else
            {
                Console.WriteLine("Please enter a valid doctor ID.");
            }
        }

        private void PrintDetails()
        {
            var doctors = doctorRepository.GetDoctors();
            Console.WriteLine("Printing all doctor details:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"Doctor ID: {doctor.Id}");
                Console.WriteLine($"Doctor Name: {doctor.Name}");
                Console.WriteLine($"Doctor Phone Number: {doctor.Phone}");
                Console.WriteLine($"Doctor Experience: {doctor.Experience}");
                Console.WriteLine("-------------------------------");
            }
        }


        private void DeleteDoctor()
        {
            Console.WriteLine("Enter the ID of the doctor you want to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Doctor doctor = doctorRepository.GetDoctorById(id);

            if (doctor != null)
            {
                doctorRepository.DeleteDoctor(id);
                Console.WriteLine("Doctor deleted successfully!");
                Console.WriteLine("----------");

            }
            else
            {
                Console.WriteLine(" Please enter a valid doctor ID.");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Clinic App");
            Program home = new Program();
            home.StartAdminActivities();
        }
    }
}
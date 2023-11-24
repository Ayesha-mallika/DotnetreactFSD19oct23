using System;
using System.Collections.Generic;
using DoctorModelLibrary;
using DoctorsBLLibrary;
using DoctorsDALLibrary;

namespace DoctorsApp
{
    internal class Program
    {
        IDoctorsService doctorService;

        public Program()
        {
            doctorService = new DoctorsService();
        }

        void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Doctor:");
            Console.WriteLine("2. Update Doctor Experience:");
            Console.WriteLine("3. Delete Doctor:");
            Console.WriteLine("4. Print All Doctors:");
            Console.WriteLine("5. Update Doctor Phone Number:");
            Console.WriteLine("0. Exit");
        }

        void StartAdminActivities()
        {
            int choice;
            do
            {
                DisplayAdminMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye bye");
                        break;
                    case 1:
                        AddDoctor();
                        break;
                    case 2:
                        UpdateExperience();
                        break;
                    case 3:
                        DeleteDoctor();
                        break;
                    case 4:
                        PrintAllDoctors();
                        break;
                    case 5:
                        UpdatePhoneNumber();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }


        void AddDoctor()
        {
            try
            {
                Doctor doctor = TakeDoctorDetails();
                var result = doctorService.AddDoctor(doctor);
                if (result != null)
                {
                    Console.WriteLine("Doctor added Successfully");
                }
                Console.WriteLine("-------------------------------");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Doctor TakeDoctorDetails()
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("Please enter the doctor's name");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Please enter the doctor's experience");
            doctor.Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the doctor's specialization");
            doctor.Specialization = Console.ReadLine();
            Console.WriteLine("Please enter the doctor's phone number");
            doctor.PhoneNumber = Console.ReadLine();
            return doctor;
        }
        void UpdateExperience()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the updated experience");
            int experience = Convert.ToInt32(Console.ReadLine());
            try
            {
                var result = doctorService.UpdateDoctorExperience(id, experience, "add");
                if (result != null)
                    Console.WriteLine("Update success");
                Console.WriteLine("-------------------------------");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        int GetDoctorIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the doctor's id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

        void DeleteDoctor()
        {
            try
            {
                int id = GetDoctorIdFromUser();
                if (doctorService.Delete(id) != null)
                    Console.WriteLine("Doctor deleted");
                Console.WriteLine("-------------------------------");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void PrintAllDoctors()
        {
            Console.WriteLine("--------------");
            var doctors = doctorService.GetAllDoctors();
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"Doctor Id: {doctor.Id}");
                Console.WriteLine($"Doctor Name: {doctor.Name}");
                Console.WriteLine($"Doctor Experience: {doctor.Experience}");
                Console.WriteLine($"Doctor Specialization: {doctor.Specialization}");
                Console.WriteLine($"Doctor Phone Number: {doctor.PhoneNumber}");
                Console.WriteLine("-------------------------------");
            }

        }
        void UpdatePhoneNumber()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the updated phone number");
            string phoneNumber = Console.ReadLine();
            try
            {
                var result = doctorService.UpdateDoctorPhoneNumber(id, phoneNumber);
                if (result != null)
                    Console.WriteLine("Update success");
                Console.WriteLine("-------------------------------");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.StartAdminActivities();

        }
    }
}

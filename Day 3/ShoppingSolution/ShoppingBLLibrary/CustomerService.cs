using ShoppingDALLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CustomerService : ICustomerService

    {
        IRepository<string, Customer> customerRepository;
        public CustomerService()
        {
            customerRepository = new CustomerRepository();
        }
        public bool Login(string email, string password)
        {
            var customer = customerRepository.GetById(email);
            if (customer != null)
            {
                if (customer.ComparePassword(password))
                    return true;


            }
            else { Console.WriteLine("unsuccess"); }
            return false;
            //throw new NotImplementedException();
        }

        public Customer Register(Customer customer)
        {
            var result = customerRepository.Add(customer);
            if (result != null)
            {
                return result;
            }
            throw new UnableToRegisterCustomerException();
            throw new NotImplementedException();
        }
    }
}
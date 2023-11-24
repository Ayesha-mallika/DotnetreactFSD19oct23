using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public interface ICustomerRepository
    {
        public Customer Add(Customer customer);
        public Customer Update(Customer customer);
        public Customer Delete();
        public Customer GetById();
        public List<Customer> GetAll();
    }
}

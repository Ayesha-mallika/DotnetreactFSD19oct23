using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
namespace ShoppingApp
{
    internal class Program
    {

        IProductService productService;
        ICustomerService customerService;
        //IRepository<int, Product> ProductRepository;
        //IRepository<string,Customer> customerRepository;
        public Program()
        {
            productService = new ProductService();
            customerService = new CustomerService();
        }
        void DisplayCustomerMenu()
        {
            Console.WriteLine("1.Register");
            Console.WriteLine("2.Login");
            Console.WriteLine("0.Exit");

        }
        void StartAppliaction()
        {
            int choice;
            do
            {
                DisplayCustomerMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye bye");
                        break;
                    case 1:
                        RegisterCustomer();
                        break;
                    case 2:
                        LoginCustomer();
                        break;


                }
            } while (choice != 0);
        }
        private void RegisterCustomer()
        {
            Console.WriteLine("Welcome to zomazon");
            Console.WriteLine("Please enter your email");
            Customer customer = new Customer();
            customer.Email = Console.ReadLine();
            Console.WriteLine("Please enter the password");
            customer.Password = Console.ReadLine();
            Console.WriteLine("Please enter your age");
            customer.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your phone number");
            customer.Phone = Console.ReadLine();
            try
            {
                var ressult = customerService.Register(customer);
                if (ressult != null)
                    Console.WriteLine("Congrats. Registration succesfull");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
        private void LoginCustomer()
        {
            string username, password;
            Console.WriteLine("Welcome to zomazon");
            Console.WriteLine("Please enter your email");
            Customer customer = new Customer();
            username = Console.ReadLine();
            Console.WriteLine("Please enter the password");
            password = Console.ReadLine();
            var result = customerService.Login(username, password);
            if (result)
            {
                StartAdminActivities();
            }
            else
                Console.WriteLine("Invalid credentials");
        }

        void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product Price");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Print All Products");
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
                        AddProduct();
                        break;
                    case 2:
                        UpdatePrice();
                        break;
                    case 3:
                        DeleteProduct();
                        break;
                    case 4:
                        PrintAllProducts();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        private void PrintAllProducts()
        {
            Console.WriteLine("***********************************");
            var products = productService.GetProducts();
            foreach (var item in products)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }
        void AddProduct()
        {
            try
            {
                Product product = TakeProductDetails();
                var result = productService.AddProduct(product);
                if (result != null)
                {
                    Console.WriteLine("Product added");
                }
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
        Product TakeProductDetails()
        {
            Product product = new Product();
            Console.WriteLine("Please enter the product name");
            product.Name = Console.ReadLine();
            Console.WriteLine("Please enter the product price");
            product.Price = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Please enter the product quantity");
            product.Quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the product description");
            product.Description = Console.ReadLine();
            Console.WriteLine("Please enter the product discount that you can offer");
            product.Discount = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Please enter the product picture path");
            product.Picture = Console.ReadLine();
            return product;
        }
        int GetProductIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the product id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        private void DeleteProduct()
        {
            try
            {
                int id = GetProductIdFromUser();
                if (productService.Delete(id) != null)
                    Console.WriteLine("Product deleted");
            }
            catch (NoSuchProductException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void UpdatePrice()
        {
            var id = GetProductIdFromUser();
            Console.WriteLine("Please enter the new price");
            float price = Convert.ToSingle(Console.ReadLine());
            Product product = new Product();
            product.Price = price;
            product.Id = id;
            try
            {
                var result = productService.UpdateProductPrice(id, price);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch (NoSuchProductException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static int Main(string[] args)
        {
            Program program = new Program();
            // program.DisplayCustomerMenu();
            program.StartAppliaction();
            return 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp2_ex2.DAL;
using tp2_ex2.Models;

namespace tp2_ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------CATEGORIES-----------------------------------
            Console.WriteLine("Fetching categories...");
            Console.WriteLine();

            UnitOfWork unitOfWork = new UnitOfWork(new OnlineShoppingContext());
            IEnumerable<Category> categories = unitOfWork.CategoryRepository.GetAll(); 


            foreach (Category category in categories)
            {
                Console.WriteLine($"({category})");
                Console.WriteLine();  
            }
            Console.WriteLine("---------------------------------------------------------");


            //------------------------ORDERS-----------------------------------

            IEnumerable<Order> orders = unitOfWork.OrderRepository.GetAll();

            Console.WriteLine("Fetching Orders...");
            Console.WriteLine();

            foreach (Order order in orders)
            {
                Console.WriteLine($"({order})");
                Console.WriteLine();
            }
            Console.WriteLine("---------------------------------------------------------");

            //------------------------PRODUCTS-----------------------------------

            IEnumerable<Product> products = unitOfWork.ProductRepository.GetAll();
            Console.WriteLine("Fetching Products...");
            Console.WriteLine(); 

            foreach (Product product in products)
            {
                Console.WriteLine($"({product})");
            }
            Console.WriteLine("---------------------------------------------------------");

            //------------------------INSERT PRODUCT-----------------------------------


            Console.WriteLine("Adding a New  Product ...");

            Product dress = new Product
            {
                Title = "Dress",
                Price = 250.99,
                Editor = "Brenda",
                Category = unitOfWork.CategoryRepository.GetByName("Clothes"),
            };

            unitOfWork.ProductRepository.Insert(dress);
            unitOfWork.Save(); 

            Console.WriteLine("Fetching products...");
            Console.WriteLine();
            products = unitOfWork.ProductRepository.GetAll();
            foreach (Product product in products)
            {
                Console.WriteLine($"({product})");
            }
            Console.WriteLine("---------------------------------------------------------");

            //------------------------UPDATE PRODUCT-----------------------------------


            Console.WriteLine("Updating new product...");

            dress = unitOfWork.ProductRepository.GetByTitle("Dress");

            dress.Price = 160.99;
            unitOfWork.ProductRepository.Update(dress);
            unitOfWork.Save();


            Console.WriteLine("Fetching products...");
            Console.WriteLine();
            products = unitOfWork.ProductRepository.GetAll();
            foreach (Product product in products)
            {
                Console.WriteLine($"({product})");
            }

            Console.WriteLine("---------------------------------------------------------");

            //------------------------DELETE PRODUCT-----------------------------------

            Console.WriteLine("Deleting the New  Product ...");

            Product dressEntity = unitOfWork.ProductRepository.GetByTitle("Dress");
            unitOfWork.ProductRepository.Delete(dressEntity);
            unitOfWork.Save();

            Console.WriteLine("Fetching products...");
            Console.WriteLine();
            products = unitOfWork.ProductRepository.GetAll();
            foreach (Product product in products)
            {
                Console.WriteLine($"({product})");
            }

            Console.WriteLine("---------------------------------------------------------");

        }
    }
}

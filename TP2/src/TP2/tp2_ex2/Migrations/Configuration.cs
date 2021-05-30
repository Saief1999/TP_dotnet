namespace tp2_ex2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using tp2_ex2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<tp2_ex2.DAL.OnlineShoppingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(tp2_ex2.DAL.OnlineShoppingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            //------------------------ADDING CATEGORIES--------------------------

            var defaultCategories = new List<Category>();



            Category clothesCategory = new Category {  Name = "Clothes", Description = "Things you can wear" };
            Category electronicsCategory = new Category { Name = "Electronics", Description = "Things that need Electricity to work" };
            Category furnitureCategory = new Category { Name = "Furniture", Description = "Things you might need in your House" };

            defaultCategories.Add(clothesCategory);
            defaultCategories.Add(electronicsCategory);
            defaultCategories.Add(furnitureCategory);


            defaultCategories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name,c));


            base.Seed(context);



            //------------------------ADDING ORDERS--------------------------

            var defaultOrders = new List<Order>();

            Order order1 = new Order { Id = 1, Status = 0 }; // Not Delivered
            Order order2 = new Order { Id = 2, Status = 1 }; // Delivered

            defaultOrders.Add(order1);
            defaultOrders.Add(order2);

            defaultOrders.ForEach(c => context.Orders.AddOrUpdate(c)); // We manually specified the Id ( it won't be cloned if it exists)

            base.Seed(context);

            //------------------------ADDING PRODUCTS--------------------------

            var defaultProducts = new List<Product>() ;

            Product computerProduct = new Product {
                Title = "Computer", 
                Price = 1499, 
                Editor = "Mike",
                Category= context.Categories.FirstOrDefault(c => c.Name == "Electronics"),
                Order=context.Orders.FirstOrDefault(o => o.Id==1)};
            Product chairProduct = new Product { 
                Title = "Chair",
                Price = 124.99,
                Editor = "Jack",
                Category= context.Categories.FirstOrDefault(c => c.Name == "Furniture"),
                Order = context.Orders.FirstOrDefault(o => o.Id == 1)
            };
            Product tshirtProduct = new Product { 
                Title = "T-Shirt",
                Price = 25.50,
                Editor = "Maya",
                Category=context.Categories.FirstOrDefault(c => c.Name == "Clothes"),
                Order = context.Orders.FirstOrDefault(o => o.Id == 2)
            };

            defaultProducts.Add(computerProduct);
            defaultProducts.Add(chairProduct);
            defaultProducts.Add(tshirtProduct);
            defaultProducts.ForEach(c => context.Products.AddOrUpdate(p=> p.Title,c)); // "Title" Helps to check if the element exists already


            base.Seed(context);

            //--------------------------------------------------------------
            Console.WriteLine("Seeding Done");

        }
    }
}

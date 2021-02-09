using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sport_shop.Models;

namespace Sport_shop.Data
{
    public class IsLogged
    {
        public bool LoggedIn;
        public IsLogged()
        {
            LoggedIn = false;
        }
    }
    public class DbInitializer
    {
        public static void Initialize(Sport_shopDbContext context)
        {

            context.Database.EnsureCreated();


            //Look for any Bagpacks
            if (context.Bagpacks.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new Product{Name="Bagpack"},
                new Product{Name="Bicycle"},
                new Product{Name="Football"},
                new Product{Name="Shoe"},
            };
            foreach (Product product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();


            var bagpacks = new Bagpack[]
            {
                new Bagpack{Name="Model 1", Price=30, ProductID=1},
                new Bagpack{Name="Model 2", Price=40, ProductID=1},
                new Bagpack{Name="Model 3", Price=50, ProductID=1},
                new Bagpack{Name="Model 4", Price=60, ProductID=1},
            };
            foreach(Bagpack bagpack in bagpacks)
            {
                context.Bagpacks.Add(bagpack);
            }
            context.SaveChanges();

            var bicycles = new Bicycle[]
            {
                new Bicycle{Name="Model 1", Price=530, ProductID=2},
                new Bicycle{Name="Model 2", Price=540, ProductID=2},
                new Bicycle{Name="Model 3", Price=550, ProductID=2},
                new Bicycle{Name="Model 4", Price=560, ProductID=2},
            };
            foreach (Bicycle bicycle in bicycles)
            {
                context.Bicycles.Add(bicycle);
            }
            context.SaveChanges();

            var footballs = new Football[]
            {
                new Football{Name="Model 1", Price=70, ProductID=3},
                new Football{Name="Model 2", Price=80, ProductID=3},
                new Football{Name="Model 3", Price=90, ProductID=3},
                new Football{Name="Model 4", Price=100, ProductID=3},
            };
            foreach (Football football in footballs)
            {
                context.Footballs.Add(football);
            }
            context.SaveChanges();

            var shoes = new Shoe[]
            {
                new Shoe{Name="Model 1", Price=70, ProductID=4},
                new Shoe{Name="Model 2", Price=80, ProductID=4},
                new Shoe{Name="Model 3", Price=90, ProductID=4},
                new Shoe{Name="Model 4", Price=100, ProductID=4},
            };
            foreach (Shoe shoe in shoes)
            {
                context.Shoes.Add(shoe);
            }
            context.SaveChanges();

            
        }
    }
}

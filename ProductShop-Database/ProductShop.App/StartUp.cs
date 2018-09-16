namespace ProductShop.App
{
    using AutoMapper;

    using Data;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            var mapper = config.CreateMapper();

            var context = new ProductShopContext();


            // D:\DataFundamentalsSoftuni\ProductShop-Database\ProductShop.App\Json

            var categoryString = File.ReadAllText(@"D:\DataFundamentalsSoftuni\ProductShop-Database\ProductShop.App\Json\categories.json");
             var userString = File.ReadAllText("../../../users.json");
             var productString= File.ReadAllText("../../../products.json");

            List<Product> productsToBeAdded = new List<Product>();
            List<User> usersToBeAdded = new List<User>();
            List<Category> categoriesToBeAdded = new List<Category>();
            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            var products = JsonConvert.DeserializeObject<Product[]>(productString);
            var users = JsonConvert.DeserializeObject<User[]>(userString);
            var categories = JsonConvert.DeserializeObject<Category[]>(categoryString);

            int counter = 0;

            foreach (var product in products)
            {
                bool isValid = IsValid(product);
                int boughtId = new Random().Next(561, 591);
                int soldId = new Random().Next(591,615);
                product.BuyerId = boughtId;
                product.SellerId = soldId;

                if(counter==4)
                {
                    product.BuyerId = null;
                    counter = 0;
                } 

                if (isValid)
                {
                    
                    productsToBeAdded.Add(product);
                }

                counter++;

            }

            foreach (var user in users)
            {
                bool isValid = IsValid(user);

                if(isValid)
                {
                    usersToBeAdded.Add(user);
                }
            }

            foreach (var category in categories)
            {
                bool isValid = IsValid(category);

                if(isValid)
                {
                    categoriesToBeAdded.Add(category);
                }

            }

            for (int i = 0; i < 11; i++)
            {
                int categoryID = new Random().Next(111, 120);
                int productID= new Random().Next(2001, 2200);

                var currentCattegoryProducts = new CategoryProduct()
                {
                   CategoryId=categoryID,
                   ProductId=productID
                };
                categoryProducts.Add(currentCattegoryProducts);
            }


            using (context)
            {
              //  context.Users.AddRange(usersToBeAdded);
              //  context.Categories.AddRange(categoriesToBeAdded);
              //  context.Products.AddRange(productsToBeAdded);
               context.CategoryProducts.AddRange(categoryProducts);

                context.SaveChanges();
            }


            
                
        }
        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var result = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, result, true);
        }

    }
}

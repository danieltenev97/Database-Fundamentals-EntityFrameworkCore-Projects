using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductShop.Data;
using System;
using System.IO;
using System.Linq;

namespace Querrying
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Task1();

            // Task2();
            // Task3();

            Task4();
        }

        private static void Task1()
        {
            var context = new ProductShopContext();


            using (context)
            {
                var products = context.Products.
                    Where(x => x.Price >= 500 && x.Price <= 1000 && x.Seller != null)
                    .OrderBy(x => x.Price)
                    .Select(x => new
                    {
                        name = x.Name,
                        price = x.Price,
                        seller = x.Seller.FirstName + " " + x.Seller.LastName ?? x.Seller.LastName

                    }).ToArray();

                var jsonProduct = JsonConvert.SerializeObject(products, Formatting.Indented);

                File.WriteAllText(@"products1.json", jsonProduct);
            }

        }


        private static void Task2()
        {
            var context = new ProductShopContext();

            using (context)
            {
                var users = context.Users
                    .Where(x => x.ProductsSold.Count >= 1)
                    .OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                    .Select(x => new
                    {
                        firstName = x.FirstName,
                        lastName = x.LastName,
                        soldProduct = x.ProductsSold.Where(e => e.Buyer != null)
                        .Select(e => new
                        {
                            name = e.Name,
                            price = e.Price,
                            buyerFirstName = e.Buyer.FirstName,
                            buyerLastName = e.Buyer.LastName
                        }).ToArray()
                        
                    }).ToArray();

                var jsonUsers = JsonConvert.SerializeObject(users,Formatting.Indented);

                File.WriteAllText("../../../users.json",jsonUsers);
            }

        }

        private static void Task3()
        {
            var context = new ProductShopContext();


            using (context)
            {

                var categories = context.Categories.Where(x => x.CategoryProducts != null)
                    .Select(x => new
                    {
                        category = x.Name,
                        productsCount = x.CategoryProducts.Count(),
                        averagePrice = x.CategoryProducts.Select(e => e.Product.Price).DefaultIfEmpty(0).Average(),
                        totalRevenue = x.CategoryProducts.Sum(e => e.Product.Price)
                    })
                    .OrderByDescending(x => x.productsCount)
                    .ToArray();

                var JsonCategory = JsonConvert.SerializeObject(categories, Formatting.Indented);

                File.WriteAllText("../../../categories.json",JsonCategory);
            }
        }

        

        private static void Task4()
        {
            var context = new ProductShopContext();

            using (context)
            {

                var users = new UserDto()
                {
                    usersCount = context.Users.Where(x => x.ProductsSold.Count >= 1).Count(),
                    users = context.Users.Where(x => x.ProductsSold.Count >= 1)
                    .Select(x => new UserInfoDto
                    {
                        firstName = x.FirstName,
                        lastName = x.LastName,
                        age = x.Age,
                        soldProducts = new SoldProductsDto()
                        {
                            count = x.ProductsSold.Count,
                            products = x.ProductsSold.Select(e => new ProductsDto()
                            {
                                name = e.Name,
                                price = e.Price
                            }).ToArray()
                        }
                    }).OrderByDescending(x=>x.soldProducts.count)
                    .ThenBy(x=>x.lastName).ToArray()

                };

                var JsonCategory = JsonConvert.SerializeObject(users, Formatting.Indented);

                File.WriteAllText("../../../usersSold.json", JsonCategory);
            }
        }
    }
}

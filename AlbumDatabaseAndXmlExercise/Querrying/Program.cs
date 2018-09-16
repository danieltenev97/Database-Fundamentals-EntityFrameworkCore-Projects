using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AlbumDatabaseAndXmlExercise.Data;
using Microsoft.EntityFrameworkCore;
using Querrying.Dtos;

namespace Querrying
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();

            // Task3();

            Task4();
         }
        private static void Task1()
        {
            var context = new AlbumDatabaseContext();

            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            using (context)
            {
                var products = context.Products.Include(x => x.Bought)
                     .Where(x => x.Price >= 1000 && x.Price <= 2000 && x.Bought != null).OrderBy(x => x.Price)
                  .Select(x => new ProductInRangeDto
                  {
                      Name = x.Name,
                      Price = x.Price.ToString(),
                      BuyerName = x.Bought.FirstName + " " + x.Bought.LastName ?? " " + x.Bought.LastName

                  })
                  .ToArray();

            var serializer = new XmlSerializer(typeof(ProductInRangeDto[]), new XmlRootAttribute("products"));

                var sb = new StringBuilder();


                serializer.Serialize(new StringWriter(sb), products, namespaces);

                File.WriteAllText("../../../products-in-range.xml", sb.ToString());
            }

        }

        private static void Task2()
        {
            var context = new AlbumDatabaseContext();

            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            using (context)
            {
                var users = context.Users.Include(x => x.Sold)
                       .Where(x => x.Sold.Count > 1)
                       .OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                       .Select(x => new UsersSoldDto
                       {
                           FirstName = x.FirstName,
                           LastName = x.LastName,
                           productSolds = x.Sold.Select(e => new ProductSoldDto
                           {
                               Name = e.Name,
                               Price = e.Price
                           }).ToArray()
                       }).ToArray();

                var serializer = new XmlSerializer(typeof(UsersSoldDto[]), new XmlRootAttribute("users"));

                var usersFile = new StreamWriter("../../../usersSoldItems");

                using (usersFile)
                {
                    serializer.Serialize(usersFile, users, namespaces);
                }
            }
        }

        private static void Task3()
        {
            var context = new AlbumDatabaseContext();

            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            using (context)
            {
                var categoryInfo = context.Categories
                    .Select(x => new CategoriesByProductsCountDto()
                    {
                        Name = x.Name,
                        ProductsCount = x.categoryProducts.Count(),
                        AveragePrice = x.categoryProducts.Select(e => e.products.Price)
                        .DefaultIfEmpty(0).Average(),
                        TotalRevenue = x.categoryProducts.Sum(e => e.products.Price)
                    })
                    .OrderByDescending(x => x.ProductsCount).ToArray();

                var serializer = new XmlSerializer(typeof(CategoriesByProductsCountDto[]), new XmlRootAttribute("categories"));

                var usersFile = new StreamWriter("../../../categoriesProducts.xml");

                using (usersFile)
                {
                    serializer.Serialize(usersFile, categoryInfo, namespaces);
                }
            }
        }

        private static void Task4()
        {
            var context = new AlbumDatabaseContext();

            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            using (context)
            {

                var users = new UserProductRootDto()
                {
                    Count = context.Users.Count(),
                    Users = context.Users
                    .Where(x => x.Sold.Count >= 1).Select(x => new UserDto()
                    {
                        Firstname = x.FirstName,
                        Lastname = x.LastName,
                        Age = x.Age.ToString(),
                        soldProducts = new SoldProductsDto
                        {
                            Count = x.Sold.Count(),
                            Products = x.Sold.Select(e => new ProductDto
                            {
                                Name = e.Name,
                                Price = e.Price
                            }).ToArray()
                        }
                    }).OrderByDescending(x=>x.soldProducts.Count).ToArray()
                };

                var serializer = new XmlSerializer(typeof(UserProductRootDto));

                var usersFile = new StreamWriter("../../../soldProducts1.xml");

                using (usersFile)
                {
                    serializer.Serialize(usersFile, users, namespaces);
                }


            }

        }
    }
}

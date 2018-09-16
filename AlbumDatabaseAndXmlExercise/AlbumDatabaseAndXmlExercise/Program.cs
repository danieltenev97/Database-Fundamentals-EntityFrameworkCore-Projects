using AlbumDatabaseAndXmlExercise.Data;
using AlbumDatabaseAndXmlExercise.Dtos;
using AlbumDatabaseAndXmlExercise.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml.Serialization;

namespace AlbumDatabaseAndXmlExercise
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<Users> users = new List<Users>();
            List<Categories> categories = new List<Categories>();
            List<Products> products = new List<Products>();

            string readstring = File.ReadAllText("users.xml");
            string categorystring = File.ReadAllText("categories.xml");
            string productstring = File.ReadAllText("products.xml");


          //  var serializer1 = new XmlSerializer(typeof(UserDto[]),new XmlRootAttribute("users"));
            var serializer2 = new XmlSerializer(typeof(CategoriesDto[]), new XmlRootAttribute("categories"));
            var serializer = new XmlSerializer(typeof(ProductsDto[]), new XmlRootAttribute("products"));


           // var desirializer1 = (UserDto[])serializer1.Deserialize(new StringReader(readstring));
            var desirializer2 = (CategoriesDto[])serializer2.Deserialize(new StringReader(categorystring));
            var desirializer = (ProductsDto[])serializer.Deserialize(new StringReader(productstring));


            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
                cfg.CreateMap<UserDto, Users>();
                cfg.CreateMap<CategoriesDto, Categories>();
                cfg.CreateMap<ProductsDto, Products>();
            });

           

            var mapper = config.CreateMapper();

            /*    foreach (var user in desirializer1)
                {

                 bool Valid = isValid(user);

                   if (Valid == false)
                   {
                       continue;
                   }

                    var currentUser = mapper.Map<Users>(user);

                   users.Add(currentUser);
                } 

                 foreach (var category in desirializer2)
                 {
                     bool Valid = isValid(category);

                   if (Valid == false)
                   {
                       continue;
                   } 

                   var currentCategory = mapper.Map<Categories>(category);


                     categories.Add(currentCategory);
                 }

        */
            int counter = 1;
           
            foreach (var product in desirializer)
            {
                
                bool Valid = isValid(product);

                if (Valid == false)
                {
                    continue;
                } 

                var currentproduct = mapper.Map<Products>(product);
                
                int boughtId = new Random().Next(57, 87);
                int soldId = new Random().Next(87, 112);
                currentproduct.Sellerid = soldId;
                currentproduct.BuyerId = boughtId;

                if(counter==4)
                {
                    currentproduct.BuyerId = null;
                    counter = 1;
                }

              
                counter++;
                products.Add(currentproduct);
            }


            var context = new AlbumDatabaseContext();
            List<CategoryProducts> categoryProducts = new List<CategoryProducts>();

          

            for (int i = 0; i < 11; i++)
            {
                int categoryID = new Random().Next(1, 10);
                int productID = new Random().Next(3662, 3697);

                var currentCattegoryProducts = new CategoryProducts()
                {
                    CategoryId = categoryID,
                    ProductId = productID
                };
                categoryProducts.Add(currentCattegoryProducts);
            }


         using (context)
            {
                // context.Users.AddRange(users);
                // context.Products.AddRange(products);
                //  context.Categories.AddRange(categories);

                context.CategoryProducts.AddRange(categoryProducts);

                context.SaveChanges();
            } 

        }

        public static bool isValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var result = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, result, true);
        }

    }
}

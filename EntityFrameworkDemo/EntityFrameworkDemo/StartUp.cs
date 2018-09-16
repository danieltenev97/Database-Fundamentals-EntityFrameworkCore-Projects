using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;

namespace P02_DatabaseFirst
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var dbContext = new SoftUniContext();

            using (dbContext)
            {
                // var employees = dbContext.Employees.Where(x => x.Salary > 50000).OrderBy(x => x.FirstName)
                //     .Select(x => x.FirstName).ToArray();

                // var employees = dbContext.Employees.OrderBy(x => x.EmployeeId);

               /* var employees = dbContext.Employees.Include(x => x.Department)
                    .Where(x => x.Department.Name == "Research and Development")
                    .Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        x.Department.Name,
                        x.Salary
                    }).OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName).ToArray(); */

             /*   var address = new Addresses()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

            
                var nakov = dbContext.Employees.FirstOrDefault(x => x.LastName == "Nakov");
                dbContext.Addresses.Add(address);
                nakov.Address = address;
                dbContext.SaveChanges();
                */
                var employees = dbContext.Employees.OrderByDescending(x => x.AddressId)
                    .Select(x => x.Address.AddressText).Take(10).ToArray();
                 using(var sw=new StreamWriter("AddressText.txt"))
                 {
                 foreach (var x in employees)
                 {

                        // Console.WriteLine($"{x.FirstName} {x.LastName} {x.MiddleName} {x.JobTitle} {x.Salary:f2}");
                        // sw.WriteLine($"{x.FirstName} {x.LastName} {x.MiddleName} {x.JobTitle} {x.Salary:f2}");

                        //         sw.WriteLine($"{x.FirstName} {x.LastName} from {x.Name} - ${x.Salary:f2}");
                        //sw.WriteLine(x);
                        Console.WriteLine(x);
                     }
             } 
            }
        }
    }
}
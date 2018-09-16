using System;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Globalization;


namespace AddressByTown
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbcontext = new SoftUniContext();

            using (dbcontext)
            {
                /*   var addresses = dbcontext.Addresses.OrderByDescending(s=>s.Employees.Count)
                       .ThenBy(x=>x.Town.Name).ThenBy(x=>x.AddressText)
                       .Select(x => new
                   {
                      address=x.AddressText,
                      townname=x.Town.Name,
                      x.Employees.Count

                   })
                   .Take(10).ToList();

                   using (var sw = new StreamWriter("EmployeesAddress.txt"))
                   {
                       foreach (var e in addresses)
                       {
                           sw.WriteLine($"{e.address}, {e.townname} - {e.Count} employees");
                       }
                   }
                */

                /*  var empoyee = dbcontext.Employees
                      .Where(x => x.EmployeeId == 147).Select(x => new
                      {
                          name = x.FirstName + " " + x.LastName,
                          job = x.JobTitle,
                          projects = x.EmployeesProjects.OrderBy(s => s.Project.Name)
                          .Select(s => s.Project.Name).ToList()
                      }).ToList();


                  using (var sw = new StreamWriter("EmployeeProjects.txt"))
                  {
                      foreach (var e in empoyee)
                      {
                          sw.WriteLine($"{e.name} - {e.job}");

                          foreach (var p in e.projects)
                          {
                              sw.WriteLine(p);
                          }
                      }
                  } */

                /*   var projects = dbcontext.Projects.OrderByDescending(x => x.StartDate).
                           Select(x => new
                           {
                               name = x.Name,
                               description = x.Description,
                               startdate = x.StartDate
                           }).Take(10).ToList();

                   using (var sw = new StreamWriter("Last10Projects.txt"))
                   {
                       foreach (var p in projects.OrderBy(x=>x.name))
                       {

                           sw.WriteLine($"{p.name}");
                           sw.WriteLine(p.description);
                           sw.WriteLine(p.startdate.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture));

                       }

                   }*/



                /*    var employees = dbcontext.Employees.Include(x => x.Department)
                            .Where(x =>x.Department.Name == "Information Services"
                            || x.Department.Name == "Marketing" || x.Department.Name == "Engineering"
                            || x.Department.Name == "Tool Design").ToList();


                    foreach (var e in employees)
                    {
                        e.Salary+= e.Salary*0.12m;

                    }

                   dbcontext.SaveChanges(); 

                    using(var sw =new StreamWriter("EmployeesIncreaseSalary.txt"))
                    {
                    foreach (var item in employees.OrderBy(x=>x.FirstName).ThenBy(x=>x.LastName))
                    {
                            sw.WriteLine($"{item.FirstName} {item.LastName} (${item.Salary:f2})");
                    }
                } */

         
                var employees = dbcontext.Employees.Where(x => x.FirstName.Substring(0, 2) == "Sa").ToList();


                using (var sw = new StreamWriter("file.txt"))
                {
                    foreach (var e in employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                    {
                        sw.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
                    }
                }
              


            }
        }
    }
}

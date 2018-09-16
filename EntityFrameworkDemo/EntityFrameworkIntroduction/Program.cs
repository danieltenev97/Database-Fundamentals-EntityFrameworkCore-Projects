using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Globalization;

namespace EntityFrameworkIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new SoftUniContext();

          

            using (dbContext)
            {
                var employees = dbContext.Employees
                    .Where(x => x.EmployeesProjects
                    .Any(s => s.Project.StartDate.Year >= 2001 && s.Project.StartDate.Year <= 2003))
                    .Select(x => new
                    {
                        EmployeeName = x.FirstName + " " + x.LastName,
                        ManagerName = x.Manager.FirstName + " " + x.Manager.LastName,
                        projects = x.EmployeesProjects.Select(s => new
                        {
                            name = s.Project.Name,
                            startdate = s.Project.StartDate,
                            enddate = s.Project.EndDate
                        }).ToArray()
             })
                    .Take(30)
                    .ToArray();


                using (var sw = new StreamWriter("Projects.txt"))
                {

                    foreach (var e in employees)
                    {

                        sw.WriteLine($"{e.EmployeeName} - Manager: {e.ManagerName}");

                        foreach (var project in e.projects)
                        {

                            var endDate = project.enddate is null
                         ? "not finished"
                         : project.enddate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                            sw.WriteLine($"--{project.name} - {project.startdate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");
                        }

                    }

                }
            }
        }
    }
}

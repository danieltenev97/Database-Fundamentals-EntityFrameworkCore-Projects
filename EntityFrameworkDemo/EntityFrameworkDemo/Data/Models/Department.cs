﻿using System;
using System.Collections.Generic;

namespace P02_DatabaseFirst.Data.Models
{
    public  class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }

        public Employee Manager { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}

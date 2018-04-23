using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_assignment3_final_edition.Models
{
    public class FtEmployee : EmployeeClass
    {
        public Nullable<double> Bouns { get; set; }
        public Nullable<double> Salary { get; set; }
        public FtEmployee(int id, string name, int age, double? salary, double? bouns) : base(id, name, age)
        {
            Bouns = bouns;
            Salary = salary;
        }
        
        public override double? calcEarnings()
        {
            return Bouns + Salary;
        }
    }
}
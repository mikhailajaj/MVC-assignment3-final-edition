using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_assignment3_final_edition.Models
{
    public class ptEmployee : EmployeeClass
    {
        public Nullable <double> HoursWorked { get; set; }
        public Nullable<double> Rate { get; set; }
        public ptEmployee(int id, string name, int age, double? rate, double? hoursWorked) : base(id, name, age)
        {
            HoursWorked = hoursWorked;
            Rate = rate;
        }
        
        public override double? calcEarnings()
        {
            return HoursWorked * Rate;
        }
    }
}
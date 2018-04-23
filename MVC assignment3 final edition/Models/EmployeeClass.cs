using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_assignment3_final_edition.Models
{
    abstract public class EmployeeClass
    {
        public static List<EmployeeClass> EmployeeList;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public EmployeeClass(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
        
        public int calcBirthYears()
        {
            return (2018 - this.Age);
        }
        public abstract double? calcEarnings();
        public static void AddEmployeeToList(EmployeeClass emp)
        {
            EmployeeList.Add(emp);

        }
    }
}

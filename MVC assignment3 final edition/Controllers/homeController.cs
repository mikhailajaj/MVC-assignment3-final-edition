using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_assignment3_final_edition.Models;

namespace MVC_assignment3_final_edition.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        const string NL = "<br/>";
        const string SPACES = "&nbsp;&nbsp;&nbsp;&nbsp;";
        private List<EmployeeClass> elist = new List<EmployeeClass>();
        //private double totalEarnings = 0;
        public ActionResult index()
        {
            ViewBag.message = result();
            return View();
        }
        public string result()
        {
            string output = "";
            DB db = new DB();
            List<tbl_status> slist = db.GetStatus();
            foreach (tbl_status status in slist)
            {
                output += status.employee_status + NL;
                output += ShowEmployeesInStatus(db, status);
            }
            output += "TOTAL EARNINGS OF ALL THE EMPLOYEE IS:" + SPACES + TotalEarnings(elist);
            
            return output;
            
        }

        private string ShowEmployeesInStatus(DB db, tbl_status status)
        {
            string output = "";
            List<tbl_employee> elist = db.GetEmployees(status);
            foreach (tbl_employee emp in elist)
            {
                output += SPACES + "Employee ID" + SPACES + emp.Id + NL
                    + SPACES + "Employee Name" + SPACES + emp.employeeName + NL
                    + SPACES + "Employee Age" + SPACES + emp.employeeAge + NL
                    + SPACES + "Earning:" + SPACES + CalcEarnings(db,emp) + NL;
                output += ShowVehicleInEmployee(db, emp);
            }
            
            return output;
        }
        private string ShowVehicleInEmployee (DB db, tbl_employee emp)
        {
            string output = "";
            List<tbl_vehicle> vlist = db.GetVehicles(emp);
            if (vlist.Count > 0)
            {
                foreach (tbl_vehicle vehicle in vlist)
                {
                    output += SPACES + "PLate Number" + SPACES + vehicle.plateNumber + NL
                        + SPACES + "Make" + SPACES + vehicle.make + NL
                        + SPACES + "Modle" + SPACES + vehicle.model + NL;

                }
            }
            else
            {
                output += "Employee Does Not have a vehicle"+NL;
            }
            output += "-------------------------------"+NL;
            return output;

        }
        private double? CalcEarnings(DB db,tbl_employee emp)
        {
            if (emp.rate != null && emp.hoursWorked != null)
            {
                ptEmployee ptemp = new ptEmployee(emp.Id, emp.employeeName, emp.employeeAge, emp.rate, emp.hoursWorked);
                elist.Add(ptemp);
                return emp.rate*emp.hoursWorked;
            }
            else if (emp.salary != null && emp.bouns != null)
            {
                FtEmployee ftemp = new FtEmployee(emp.Id, emp.employeeName, emp.employeeAge, emp.bouns, emp.salary);
                elist.Add(ftemp);
                return emp.salary + emp.bouns;
            }
            return 0;
        }
        private double? TotalEarnings(List<EmployeeClass> elist)
        {
            double? totalEarnigs = 0.0;
            foreach (EmployeeClass emp in elist)
            {
                totalEarnigs += emp.calcEarnings();
            }
            return totalEarnigs;
        }
    }
    
}
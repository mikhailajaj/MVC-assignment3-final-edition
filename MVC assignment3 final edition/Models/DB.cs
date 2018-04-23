using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_assignment3_final_edition.Models
{
    
    public class DB
    {
        private db_employeesEntities1 context;
        public DB()
        {
            context = new db_employeesEntities1();
        }
        public List<tbl_status> GetStatus()
        {
            List<tbl_status> slist = new List<tbl_status>();
            foreach (tbl_status status in context.tbl_status)
                slist.Add(status);
            return slist;
        }
        public List<tbl_employee> GetEmployees(tbl_status status)
        {
            List<tbl_employee> elist = new List<tbl_employee>();
            foreach (tbl_employee emp in status.tbl_employee)
                elist.Add(emp);
            return elist;
        }
        public List<tbl_vehicle> GetVehicles(tbl_employee emp)
        {
            List<tbl_vehicle> vlist = new List<tbl_vehicle>();
            foreach (tbl_vehicle vehicle in emp.tbl_vehicle)
                vlist.Add(vehicle);
            return vlist;
        }
        

    }
}
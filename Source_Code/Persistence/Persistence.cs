using System;

namespace persistence.Models
{

    public class Employees
    {
        public int emp_id { get; set; }

        public string emp_first_name { get; set; }

        public string emp_last_name { get; set; }

        public Employees() { }

        public Employees(int id, string firstname, string lastname)
        {
            emp_id = id;
            emp_first_name = firstname;
            emp_last_name = lastname;
        }
    }
}
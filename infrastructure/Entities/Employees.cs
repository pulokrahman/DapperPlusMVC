using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Employees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int DeptId { get; set; }

        // navigation property: used to help reference values from related table
        public Departments departments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Belatrix.Final.WebApi.Models
{
    public class Employee
    {
        public Employee()
        {
            Customers = new HashSet<Customer>();
            EmployeesReportsTo = new HashSet<Employee>();
        }
        [Key]
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public Employee ReportsTo { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Employee> EmployeesReportsTo { get; set; }
    }

}

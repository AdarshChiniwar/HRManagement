using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Models
{
    /// <summary>
    /// User Table
    /// </summary>
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class Employee 
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public DateTime DOJ { get; set; }
    }

    public class InterViewDetails
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public int ExpectedSalary { get; set; }
    }
}

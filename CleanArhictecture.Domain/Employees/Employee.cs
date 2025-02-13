using CleanArhictecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArhictecture.Domain.Employees
{
    public sealed class Employee:Entity
    {
        
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string FullName => string.Join(" ", FirstName, LastName); // veritabanında kaydetmez ön tarafta ikisini birlikte gösterebilmemize olanak tanır
        public DateOnly BirthfDate { get; set; }
        public decimal Salary { get; set; }
        public PersonelInformation? PersonelInformation { get; set; }
        public Address? Address { get; set; }
        
    }
}

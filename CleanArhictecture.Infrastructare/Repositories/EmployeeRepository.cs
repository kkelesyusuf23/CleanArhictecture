using CleanArhictecture.Domain.Employees;
using CleanArhictecture.Infrastructare.Context;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArhictecture.Infrastructare.Repositories
{
    internal sealed class EmployeeRepository : Repository<Employee, ApplicationDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

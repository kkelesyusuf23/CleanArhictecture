using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArhictecture.Domain.Employees
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
    }
}

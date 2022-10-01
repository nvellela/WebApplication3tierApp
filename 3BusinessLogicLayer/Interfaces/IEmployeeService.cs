using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeModel?> GetById(int EmployeeId);
        Task<List<EmployeeModel>> GetAll();

        Task<int> CreateEmployee(EmployeeModel Employee);
        Task UpdateEmployee(EmployeeModel Employee);
        Task DeleteEmployee(int EmployeeId);     

        
    }
}

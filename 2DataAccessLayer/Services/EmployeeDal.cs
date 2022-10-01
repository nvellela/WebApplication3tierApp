using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Services
{
    public class EmployeeDal : IEmployeeDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public EmployeeDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<EmployeeModel> GetAll()
        {
            var result = _db.Employees.ToList();

            var returnObject = new List<EmployeeModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToEmployeeModel());
            }

            return returnObject;
        }

        public EmployeeModel? GetById(int EmployeeId)
        {
            var result = _db.Employees.SingleOrDefault(x => x.EmployeeId == EmployeeId);
            return result?.ToEmployeeModel();
        }


        public int CreateEmployee(EmployeeModel Employee)
        {
            var newEmployee = Employee.ToEmployee();
            _db.Employees.Add(newEmployee);
            _db.SaveChanges();
            return newEmployee.EmployeeId;
        }


        public void UpdateEmployee(EmployeeModel Employee)
        {
            var existingEmployee = _db.Employees
                .SingleOrDefault(x => x.EmployeeId == Employee.EmployeeId);

            if (existingEmployee == null)
            {
                throw new ApplicationException($"Employee {Employee.EmployeeId} does not exist.");
            }
            Employee.ToEmployee(existingEmployee);

            _db.Update(existingEmployee);
            _db.SaveChanges();
        }

        public void DeleteEmployee(int EmployeeId)
        {
            var efModel = _db.Employees.Find(EmployeeId);
            _db.Employees.Remove(efModel);
            _db.SaveChanges();


        }

    }

}

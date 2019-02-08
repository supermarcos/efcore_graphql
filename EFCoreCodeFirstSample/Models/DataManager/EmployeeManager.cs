using EFCoreCodeFirstSample.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class EmployeeManager : IEmployeeRepository<Employee>
    {
        readonly EmployeeContext _employeeContext;

        public EmployeeManager(EmployeeContext context)
        {
            _employeeContext = context;
        }

        public Employee Add(Employee entity)
        {
            _employeeContext.Employees.Add(entity);
            _employeeContext.SaveChanges();
            return entity;
        }

        public Employee Delete(Employee entity)
        {
            _employeeContext.Employees.Remove(entity);
            _employeeContext.SaveChanges();
            return entity;
        }

        public Employee Get(long id)
        {
            return _employeeContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees.ToList();
        }

        public Employee Update(Employee employee, Employee entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Email = entity.Email;
            employee.DateOfBirth = entity.DateOfBirth;
            employee.MobilePhone = entity.MobilePhone;

            _employeeContext.SaveChanges();
            return entity;
        }
    }
}

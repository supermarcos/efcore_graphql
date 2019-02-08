using EFCoreCodeFirstSample.Models.Repository;
using GraphQL.Types;
using System.Linq;

namespace EFCoreCodeFirstSample.Models
{
    public class EmployeesQuery : ObjectGraphType
    {
        public EmployeesQuery(IEmployeeRepository<Employee> employeeRepository)
        {
            Field<EmployeeType>(
                "employee",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "employeeId" }),
                resolve: context => employeeRepository.Get(context.GetArgument<long>("employeeId")));

            Field<ListGraphType<EmployeeType>>(
                "employees",
                resolve: context => employeeRepository.GetAll());
        }
    }
}

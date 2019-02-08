using EFCoreCodeFirstSample.Models.Repository;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Models
{
    public class EmployeesMutation : ObjectGraphType
    {
        public EmployeesMutation(IEmployeeRepository<Employee> employeeRepository)
        {
            Name = "CreateEmployeeMutation";

            Field<EmployeeType>(
                "createEmployee",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee" }
                ),
                resolve: context =>
                {
                    var employee = context.GetArgument<Employee>("employee");
                    return employeeRepository.Add(employee);
                });
        }
    }
}

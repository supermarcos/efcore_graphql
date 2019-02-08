using EFCoreCodeFirstSample.Models.Repository;
using GraphQL.Types;

namespace EFCoreCodeFirstSample.Models
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType(IEmployeeRepository<Employee> employeeRepository)
        {
            Field(x => x.EmployeeId);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.Active);
            Field(x => x.MobilePhone);
            Field<StringGraphType>("dateOfBirth", resolve: context => context.Source.DateOfBirth.ToShortDateString());
            Field<ListGraphType<EmployeeType>>("skaterSeasonStats",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "employeeId" }),
                resolve: context => employeeRepository.Get(context.Source.EmployeeId), description: "employee details");
        }
    }
}
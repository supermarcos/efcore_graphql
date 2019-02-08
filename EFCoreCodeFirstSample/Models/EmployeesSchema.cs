using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Models
{
    public class EmployeesSchema : Schema
    {
        public EmployeesSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<EmployeesQuery>();
            Mutation = resolver.Resolve<EmployeesMutation>();
        }
    }
}

using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Models
{
    public class EmployeeInputType: InputObjectGraphType
    {
        public EmployeeInputType()
        {
            Name = "EmployeeInput";
            Field < NonNullGraphType < StringGraphType > > ("firstName");
            Field < StringGraphType > ("lastName");
            Field < StringGraphType > ("mobilePhonme");
            Field < StringGraphType > ("email");
            Field < BooleanGraphType > ("active");
            Field < DateGraphType > ("dateOfBirth");
        }
    }
}
